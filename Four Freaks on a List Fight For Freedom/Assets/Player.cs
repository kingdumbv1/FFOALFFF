using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 currentDirection;
    [SerializeField] float isAttacking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (currentDirection.y >= 0f && isAttacking == 1f)
        {

        }

        rb.linearVelocityX = currentDirection.x * moveSpeed;
    }

    public void TestInput(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        currentDirection = context.ReadValue<Vector2>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        isAttacking = context.ReadValue<float>();
    }
}
