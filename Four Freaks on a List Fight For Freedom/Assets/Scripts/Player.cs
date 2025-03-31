using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // For Players 1 and 2, Player 1 must have "Player" Tag and player 2 must have
    // "Enemy" tag. The Layer for p1 must be "Player1" and p2 must be "Player2"


    // Health
    [Header("Health")]
    public float currentHealth;
    public float currentMaxHealth;
    // Posture
    public float currentMaxPosture;
    public float currentPosture;
    // Self
    [Header("Self")]
    [SerializeField] Player player;
    // edit in inspector for choice. Characters: prototype, raven, rockstar, dj, outlaw.
    [SerializeField] string chosenCharacter;
    // 
    [Header("Movement")]
    public float moveSpeed = 2.8f;
    public float jumpHeight = 2f;
    public float distance;
    public Rigidbody2D rb;
    [Header("Animator / Sprites")]
    [SerializeField] SpriteRenderer spriteRend;
    public Animator animator;
    public Transform enemy;
    [Header("Misc")]
    public float instantiatedDamage;
    public Vector2 currentDirection;
    public Test abilityDatabase;
    public GameManager game;
    public AnimatorReference animatorReference;
    [Header("Light Attack / Blocking")]
    // Light Attacks - Blocking
    public float attackClickedFrame;
    public bool isAttacking;
    public float isBlocking;
    public float lightDamage;
    public bool canAttack;
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


    void Start()
    {
        Debug.Log(chosenCharacter);

        if (gameObject.tag == "Player") enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (gameObject.tag == "Enemy") enemy = GameObject.FindGameObjectWithTag("Player").transform;


        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animatorReference = GetComponent<AnimatorReference>();
        abilityDatabase = new Test(player, chosenCharacter, animatorReference);
        spriteRend = GetComponent<SpriteRenderer>();
        game = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        distance = transform.position.x - enemy.transform.position.x;
        currentDirection.y = Mathf.RoundToInt(currentDirection.y);
        abilityDatabase.Update(Time.deltaTime);

        if (xMovementPossible || !xMovementPossible && isBlocking == 1)
        {
            if (distance < 0) transform.rotation = Quaternion.identity;
            if (distance > 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetBool("IsBlockBreaking", false);
            if (!isStaggered) canAttack = true;
            isAttacking = false;
            isHeavyAttacking = false;
            blockBreak = false;
            if (!isStaggered) xMovementPossible = true;
        }

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

        

        //turn around
        if (distance < 0)
        {
            animator.SetFloat("IfRunning", currentDirection.x);
        }
        else if (distance > 0) animator.SetFloat("IfRunning", -currentDirection.x);

        //Blocking 
        if (!isStaggered) animator.SetFloat("IfBlocking", isBlocking);

        if (isBlocking == 1)
        {
            canAttack = false;
            moveSpeed = 1.5f; 
        } else moveSpeed = 2.8f;

        //movement
        if (xMovementPossible)
        {
            rb.linearVelocityX = currentDirection.x * moveSpeed;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        float dashfloat = context.ReadValue<float>();
        if (dashfloat == 0) isDashing = false;
        if (dashfloat == 1) isDashing = true;

        StartCoroutine("Dashing", dashCooldown);
    }

    public IEnumerator Dashing(float seconds)
    {
        if (canDashAgain && isDashing)
        {
            xMovementPossible = false;
            rb.AddForce(Vector2.right * 5 * currentDirection, ForceMode2D.Impulse);
            canDashAgain = false;
            yield return new WaitForSeconds(seconds);
            canDashAgain = true;
            xMovementPossible = true;
        }
    }

    public void TakeDamage(float damage, float knockback)
    {
        currentHealth -= damage;
        StartCoroutine("HitIndicated", 0.2f);
    }

    IEnumerator HitIndicated(float seconds)
    {
        spriteRend.color = Color.red;
        isStaggered = true;
        xMovementPossible = false;
        rb.AddForce(Vector2.right * 3.5f * Mathf.Clamp(distance, -1, 1), ForceMode2D.Impulse);
        yield return new WaitForSeconds(seconds);
        xMovementPossible = true;
        isStaggered = false;
        spriteRend.color = Color.white;
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
    public void HeavyAttack(InputAction.CallbackContext context)
    {
        Debug.Log(heavyAttackClickedFrame);
        heavyAttackClickedFrame = context.ReadValue<float>();
    }
    public void Block(InputAction.CallbackContext context)
    {
        isBlocking = context.ReadValue<float>();
    }

}
