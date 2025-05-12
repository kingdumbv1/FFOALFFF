using UnityEngine;

public class HurtScript : MonoBehaviour
{
    [SerializeField] float damage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage(damage, 5);
        }
    }
}
