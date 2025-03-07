using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.8f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float distance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Transform enemy;
    [SerializeField] Vector2 currentDirection;
    // Light Attacks - Blocking
    [SerializeField] float isAttacking;
    [SerializeField] float isBlocking;
    public float lightDamage;
    [SerializeField] bool canAttack;
    [SerializeField] bool canBlock;
    [SerializeField] bool xMovementPossible = true;
    // Heavy Attacks 
    [SerializeField] float isHeavyAttacking;
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

        if (distance < 0) transform.rotation = Quaternion.identity;
        if (distance > 0) transform.rotation = Quaternion.Euler(0, 180, 0);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            canAttack = true;
            xMovementPossible = true;
        }
        //Directional Combat Input
        switch (currentDirection.y)
        {
            case -1:
                if (isAttacking == 1 && canAttack)
                {
                    canAttack = false;
                    animator.SetTrigger("LowPrimary");
                }
                if (isHeavyAttacking == 1 && canAttack)
                {
                    
                }
                break;
            case 0:
                if (isAttacking == 1 && canAttack)
                { 
                    canAttack = false;
                    animator.SetTrigger("MiddlePrimary");
                }
                if (isHeavyAttacking == 1 && canAttack)
                {
                    xMovementPossible = false;
                    canAttack = false;
                    //StartCoroutine("Dash", 3);
                    rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-distance, -1, 1), ForceMode2D.Impulse);
                    animator.SetTrigger("HeavyMiddle");
                }
                break;
            case 1:
                if (isAttacking == 1 && canAttack)
                {
                    canAttack = false;
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetTrigger("HighPrimary");
                }
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

    public void TestInput(InputAction.CallbackContext context)
    {
        currentDirection = context.ReadValue<Vector2>();
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

    IEnumerator Dash(float seconds)
    {
        transform.position += Vector3.right * 5f * Time.deltaTime;
        yield return new WaitForSeconds(seconds);
    }
}
