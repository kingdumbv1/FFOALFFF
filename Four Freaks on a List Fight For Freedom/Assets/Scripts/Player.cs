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
    //
    [SerializeField] float moveSpeed = 2.8f;
    [SerializeField] float jumpHeight = 4f;
    [SerializeField] float distance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Transform enemy;
    [SerializeField] Vector2 currentDirection;
    // Light Attacks - Blocking
    public float attackClickedFrame;
    public bool isAttacking;
    [SerializeField] float isBlocking;
    public float lightDamage;
    [SerializeField] bool canAttack;
    [SerializeField] bool canBlock;
    // Movement
    [SerializeField] bool canMove = true;
    [SerializeField] bool xMovementPossible = true;
    [SerializeField] bool canDashAgain = true;
    [SerializeField] bool isDashing;
    [SerializeField] float dashCooldown = 2f;
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
            xMovementPossible = true;
        }
        //Directional Combat Input
        switch (currentDirection.y)
        {
            case -1:
                // down light
                if (attackClickedFrame == 1 && canAttack)
                {
                    canAttack = false;
                    isAttacking = true;
                    animator.SetTrigger("LowPrimary");
                }
                // down heavy
                if (heavyAttackClickedFrame == 1 && canAttack)
                {
                    isAttacking = true;
                    HeavyLow();
                }
                break;
            case 0:
                // neutral light
                if (attackClickedFrame == 1 && canAttack)
                {
                    isAttacking = true;
                    canAttack = false;
                    animator.SetTrigger("MiddlePrimary");
                }
                // neutral heavy
                if (heavyAttackClickedFrame == 1 && canAttack)
                {
                    isAttacking = true;
                    blockBreak = true;
                    HeavyMiddle();
                }
                break;
            case 1:
                //up light
                if (attackClickedFrame == 1 && canAttack)
                {
                    isAttacking = true;
                    canAttack = false;
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetTrigger("HighPrimary");
                }
                // up heavy
                if (heavyAttackClickedFrame == 1 && canAttack)
                {
                    isAttacking = true;
                    HeavyHigh();
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
    void HeavyHigh()
    {
        xMovementPossible = false;
        canAttack = false;

    }
    void HeavyMiddle()
    {
        xMovementPossible = false;
        canAttack = false;
        rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-distance, -1, 1), ForceMode2D.Impulse);
        animator.SetTrigger("HeavyMiddle");
    }

    void HeavyLow()
    {
        xMovementPossible = false;
        canAttack = false;

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
