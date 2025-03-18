using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Health
    public float currentHealth;
    public float currentMaxHealth;
    // Posture
    public float currentMaxPosture;
    public float currentPosture;
    // Self
    [SerializeField] Player playerOne;
    // edit in inspector for choice. Characters: prototype, raven, rockstar, dj, outlaw.
    [SerializeField] string chosenCharacter;
    // 
    public float moveSpeed = 2.8f;
    public float jumpHeight = 4f;
    public float distance;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform enemy;
    public Vector2 currentDirection;
    public Test abilityDatabase;
    // Light Attacks - Blocking
    public float attackClickedFrame;
    public bool isAttacking;
    public float isBlocking;
    public float lightDamage;
    public bool canAttack;
    public bool canBlock;
    // Movement
    public bool canMove = true;
    public bool xMovementPossible = true;
    public bool canDashAgain = true;
    public bool isDashing;
    public float dashCooldown = 1f;
    // Heavy Attacks 
    public float heavyAttackClickedFrame;
    public float heavyDamage;
    // Block Break Type
    public bool blockBreak;


    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        abilityDatabase = new Test(playerOne, chosenCharacter);
    }
    void Update()
    {
        distance = transform.position.x - enemy.transform.position.x;

        if (xMovementPossible)
        {
            if (distance < 0) transform.rotation = Quaternion.identity;
            if (distance > 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            canAttack = true;
            isAttacking = false;
            blockBreak = false;
            if (canDashAgain) xMovementPossible = true;
        }
        //Directional Combat Input
        switch (currentDirection.y)
        {
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
        }

        if (distance < 0)
        {
            animator.SetFloat("IfRunning", currentDirection.x);
        }
        else if (distance > 0) animator.SetFloat("IfRunning", -currentDirection.x);

        //Blocking 
        animator.SetFloat("IfBlocking", isBlocking);

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
        if (canDashAgain && isDashing && currentDirection != Vector2.zero)
        {
            canDashAgain = false;
            xMovementPossible = false;
            rb.AddForce(Vector2.right * currentDirection, ForceMode2D.Impulse);
            yield return new WaitForSeconds(seconds);
            canDashAgain = true;
            xMovementPossible = true;
        }
    }

    // Inputs

    public void TestInput(InputAction.CallbackContext context)
    {
        if (canMove) currentDirection = context.ReadValue<Vector2>();
        else currentDirection = Vector2.zero;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Debug.Log(attackClickedFrame);
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
