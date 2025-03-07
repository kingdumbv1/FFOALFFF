using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Triggered");
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null && enemy.isBlocking == 0) enemy.TakeDamage(5);
        }
    }
}
