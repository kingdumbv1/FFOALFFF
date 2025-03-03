using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Vector2 currentDirection;
    [SerializeField] float isAttacking;
    [SerializeField] float isBlocking;
    [SerializeField] bool canAttack;
    [SerializeField] float jumpHeight = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) canAttack = true;
        switch (currentDirection.y)
        {
            case -1:
                if (isAttacking == 1 && canAttack)
                {
                    canAttack = false;
                    rb.linearVelocityY = currentDirection.y * jumpHeight;
                    animator.SetTrigger("LowPrimary");
                }
                break;
            case 0:
                if (isAttacking == 1 && canAttack)
                { 
                    canAttack = false;
                    animator.SetTrigger("MiddlePrimary");
                }
                break;
            case 1:
                if (isAttacking == 1 && canAttack)
                {
                    canAttack = false;
                    animator.SetTrigger("HighPrimary");
                }
                break;
        }

        animator.SetFloat("IfRunning", currentDirection.x);
        rb.linearVelocityX = currentDirection.x * moveSpeed;
    }

    public void TestInput(InputAction.CallbackContext context)
    {
        currentDirection = context.ReadValue<Vector2>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Debug.Log(isAttacking);
        isAttacking = context.ReadValue<float>();
    }
    public void Block(InputAction.CallbackContext context)
    {
        isBlocking = context.ReadValue<float>();
    }
}
