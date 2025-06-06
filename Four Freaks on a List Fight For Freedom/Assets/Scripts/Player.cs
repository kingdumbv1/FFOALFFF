using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // For Players 1 and 2, Player 1 must have "Player" Tag and player 2 must have
    // "Enemy" tag. The Layer for p1 must be "Player1" and p2 must be "Player2"


    // Health
    [Header("Health")]
    public float currentHealth;
    public float currentMaxHealth;
    // Posture
    public float currentMaxPassive;
    public float currentPassive;
    // Self
    [Header("Self")]
    [SerializeField] Player player;
    // edit in inspector for choice. Characters: prototype, raven, rockstar, dj, outlaw.
    public string chosenCharacter;
    // 
    [Header("Movement")]
    public float moveSpeed = 2.8f;
    public float jumpHeight = 2f;
    int jump = 0;
    bool jumpAdding;
    public float distance;
    public Rigidbody2D rb;
    [Header("Animator / Sprites")]
    [SerializeField] SpriteRenderer spriteRend;
    public Animator animator;
    public Transform enemy;
    [Header("Misc")]
    public FindMedian cam;
    public EventSystem eventSystem;
    // Pause stuff
    public GameObject pauseMenu;
    public GameObject UI;
    public bool isPaused;
    public bool pauseFrame;
    public bool canClickAgain;
    //
    public float multiplier = 1;
    public bool isHit;
    public bool invulnerable;
    public bool isGrounded;
    public bool canAttack;
    public float instantiatedDamage;
    public Vector2 currentDirection;
    public Test abilityDatabase;
    public GameManager game;
    public AnimatorReference animatorReference;
    [SerializeField] ParticleSystem killEffect;
    [SerializeField] ParticleSystem hitEffect;
    public float knockback;
    [Header("Light Attack / Blocking")]
    // Light Attacks - Blocking
    public float attackClickedFrame;
    public bool isAttacking;
    public float isBlocking;
    public float lightDamage;
    public bool canBlock;
    // Movement
    [Header("Other Movement")]
    public bool canMove = true;
    public bool isStaggered = false;
    public bool xMovementPossible = true;
    public bool canDashAgain = true;
    public bool isDashing;
    public float dashCooldown = 1f;
    // Heavy Attacks 
    [Header("Heavy Attack")]
    public float heavyAttackClickedFrame;
    public bool isHeavyAttacking;
    public float heavyDamage;
    // Block Break Type
    public bool blockBreak;

    // use FindObjectOfType<AudioManager>().Play("___");
    void Start()
    {
        StartCoroutine(LoadEnemyOfPlayer());

        cam = Camera.main.GetComponent<FindMedian>();
        eventSystem = FindFirstObjectByType<EventSystem>();
        pauseMenu = GameObject.Find("UI").GetComponent<ArrayOfHealthbars>().pauseMenu;
        UI = GameObject.Find("UI");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animatorReference = GetComponent<AnimatorReference>();
        abilityDatabase = new Test(player, chosenCharacter, animatorReference);
        spriteRend = GetComponent<SpriteRenderer>();
        distance = 10;
        if (CompareTag("Player"))
        {
            cam.InheritParent(transform);
        }
    }
    IEnumerator LoadEnemyOfPlayer()
    {
        yield return new WaitForEndOfFrame();
        if (gameObject.tag == "Player") enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (gameObject.tag == "Enemy") enemy = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (enemy != null) distance = transform.position.x - enemy.transform.position.x;
        currentDirection.y = Mathf.RoundToInt(currentDirection.y);
        if (xMovementPossible || !xMovementPossible && isBlocking == 1)
        {
            if (distance < 0) transform.rotation = Quaternion.identity;
            if (distance > 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (currentHealth <= 0)
        {
            if (CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
            }
            Destroy(gameObject);
        }
        currentPassive = Mathf.Clamp(currentPassive, -5, currentMaxPassive);
        currentHealth = Mathf.Clamp(currentHealth, 0, currentMaxHealth);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            moveSpeed = 2.8f;
            animator.SetBool("IsBlockBreaking", false);
            if (!isStaggered) canAttack = true;
            isAttacking = false;
            isHeavyAttacking = false;
            blockBreak = false;
            if (!isStaggered) xMovementPossible = true;
            invulnerable = false;
        }

        // Pausing
        Pause();

        //Directional Combat Input
        switch (currentDirection.y)
        {
            case 0:
                // neutral light
                if (attackClickedFrame == 1 && canAttack)
                {
                    abilityDatabase.LightMiddle();
                }
                // neutral heavy
                if (heavyAttackClickedFrame == 1 && canAttack)
                {
                    abilityDatabase.HeavyMiddle(rb);
                }
                break;
            case 1:
                //up light
                if (attackClickedFrame == 1 && canAttack)
                {
                    abilityDatabase.LightHigh();
                }
                // up heavy
                if (heavyAttackClickedFrame == 1 && canAttack)
                {
                    abilityDatabase.HeavyHigh();
                }
                break;
        
            case -1:
                // down light
                if (attackClickedFrame == 1 && canAttack)
                {
                    abilityDatabase.LightLow();
                }
                // down heavy
                if (heavyAttackClickedFrame == 1 && canAttack)
                {
                    abilityDatabase.HeavyLow();
                }
                break;
        }

        // Jumping
        if (currentDirection.y == 1) AddJump();
        if (currentDirection.y == 0) jumpAdding = false;
        if (jump == 2 && isGrounded)
        {
            rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            AudioManager.Instance.Play(8);
            jump = 0;
        }

        //turn around
        if (distance < 0)
        {
            animator.SetFloat("IfRunning", Mathf.RoundToInt(currentDirection.x));
        }
        else if (distance > 0) animator.SetFloat("IfRunning", Mathf.RoundToInt(-currentDirection.x));

        //Blocking 
        if (!isStaggered) animator.SetFloat("IfBlocking", isBlocking);

        if (isBlocking == 1)
        {
            canAttack = false;
            moveSpeed = 1.5f; 
        }

        //movement
        if (xMovementPossible)
        {
            rb.linearVelocityX = currentDirection.x * moveSpeed;
        }
        if (currentHealth <= 0) Destroy(Instantiate(killEffect, transform.position, Quaternion.identity), 1);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0) 
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0)
        isGrounded = false;
    }

    void Pause()
    {
        if (pauseFrame)
        {
            Debug.Log("Pausing");
            if (!isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);

                GameObject playButton = pauseMenu.transform.GetChild(3).gameObject;
                PauseScript pauseScript = pauseMenu.GetComponent<PauseScript>();
                pauseScript.TransferPlayer(this);
                UI.SetActive(false);
                Time.timeScale = 0f;
                if (playButton ==  null)
                {
                    Debug.Log(pauseMenu.transform.GetChild(3).gameObject);
                }
                else if (playButton != null) eventSystem.SetSelectedGameObject(playButton);
                isPaused = true;
            }
            else if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                UI.SetActive(true);
                Time.timeScale = 1f;
            }
        }

    }
    
    void AddJump()
    {
        if (!jumpAdding)
        {
            StartCoroutine(ResetJump());
            jumpAdding = true;
            jump++;
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.5f);
        jump = 0;
    }
    public void TakeDamage(float damage, float knockback)
    {
        isHit = true;
        if (!invulnerable && isBlocking != 1)
        {
            currentHealth -= damage;
            if (gameObject !=null)
            StartCoroutine(Hurt(0.2f, knockback));
            
        }
        StartCoroutine(HitIndicated(0.2f));
    }

    IEnumerator Hurt(float seconds, float knockback)
    {
        int roundedDistanceKnockback()
        {
            if (distance > 0) return 1;
            if (distance < 0) return -1;
            return 0;
        }
        spriteRend.color = Color.red;
        Destroy(Instantiate(hitEffect, transform.position, Quaternion.identity), 1f);
        isStaggered = true;
        xMovementPossible = false;
        AudioManager.Instance.Play(7);
        rb.AddForce(Vector2.right * knockback * roundedDistanceKnockback(), ForceMode2D.Impulse);
        yield return new WaitForSeconds(seconds);
        xMovementPossible = true;
        isStaggered = false;
        spriteRend.color = Color.white;
    }
    IEnumerator HitIndicated(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isHit = false;
    }
    public void BlockBroke(bool isBlockBreaking)
    {
        animator.SetTrigger("BlockBroke");
        animator.SetBool("IsBlockBreaking", isBlockBreaking);
        isBlocking = 0;
    }

    // Inputs
    public void TestInput(InputAction.CallbackContext context)
    {
        if (canMove) currentDirection = context.ReadValue<Vector2>();
        else currentDirection = Vector2.zero;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        attackClickedFrame = context.ReadValue<float>();
        
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        float currentPause = context.ReadValue<float>();
        if (currentPause > 0 && canClickAgain) StartCoroutine(PauseWait());
        if (currentPause < 1) canClickAgain = true;
    }
    IEnumerator PauseWait()
    {
        pauseFrame = true;
        yield return new WaitForEndOfFrame();
        pauseFrame = false;
        canClickAgain = false;
    }
    public void HeavyAttack(InputAction.CallbackContext context)
    {
        heavyAttackClickedFrame = context.ReadValue<float>();
    }
    public void Block(InputAction.CallbackContext context)
    {
        isBlocking = context.ReadValue<float>();
    }

    
}
