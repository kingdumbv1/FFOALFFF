using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.8f;
    [SerializeField] float jumpHeight = 4f;
    [SerializeField] float distance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Transform enemy;
    [SerializeField] Vector2 currentDirection;
    // Light Attacks - Blocking
    public float isAttacking;
    [SerializeField] float isBlocking;
    public float lightDamage;
    [SerializeField] bool canAttack;
    [SerializeField] bool canBlock;
    // Movement
    [SerializeField] bool canMove = true;
    [SerializeField] bool xMovementPossible = true;
    // Heavy Attacks 
    public float isHeavyAttacking;
    public float heavyDamage;


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
            xMovementPossible = true;
        }
        //Directional Combat Input
        switch (currentDirection.y)
        {
            case -1:
                // down light
                if (isAttacking == 1 && canAttack)
                {
                    canAttack = false;
                    animator.SetTrigger("LowPrimary");
                }
                // down heavy
                if (isHeavyAttacking == 1 && canAttack)
                {
                    
                }
                break;
            case 0:
                // neutral light
                if (isAttacking == 1 && canAttack)
                { 
                    canAttack = false;
                    animator.SetTrigger("MiddlePrimary");
                }
                // neutral heavy
                if (isHeavyAttacking == 1 && canAttack)
                {
                    NeutralMiddle();
                }
                break;
            case 1:
                //up light
                if (isAttacking == 1 && canAttack)
                {
                    canAttack = false;
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetTrigger("HighPrimary");
                }
                // up heavy
                if (isHeavyAttacking == 1 && canAttack)
                {
                    
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
    void NeutralMiddle()
    {
        xMovementPossible = false;
        canAttack = false;
        rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-distance, -1, 1), ForceMode2D.Impulse);
        animator.SetTrigger("HeavyMiddle");
    }

    // Inputs

    public void TestInput(InputAction.CallbackContext context)
    {
        if (canMove) currentDirection = context.ReadValue<Vector2>();
        else currentDirection = Vector2.zero;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Debug.Log(isAttacking);
        isAttacking = context.ReadValue<float>();
    }
    public void HeavyAttack(InputAction.CallbackContext context)
    {
        Debug.Log(isHeavyAttacking);
        isHeavyAttacking = context.ReadValue<float>();
    }
    public void Block(InputAction.CallbackContext context)
    {
        isBlocking = context.ReadValue<float>();
    }

}
