using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) enemy.TakeDamage(5);
    }
}
