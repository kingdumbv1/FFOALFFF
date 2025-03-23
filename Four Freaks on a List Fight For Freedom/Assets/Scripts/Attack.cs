using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Player player;
    private void Start()
    {
        player = GetComponentInParent<Player>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.CompareTag("Player"))
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log("Triggered");
                Player enemy = collision.GetComponent<Player>();
                if (enemy != null)
                {
                    if (enemy.isBlocking == 0)
                    {
                        if (player.isAttacking) enemy.TakeDamage(player.lightDamage); 
                        if (player.isHeavyAttacking) enemy.TakeDamage(player.heavyDamage);
                    }
                    if (player.isHeavyAttacking && enemy.isBlocking == 1 && player.blockBreak == true)
                    {
                        enemy.BlockBroke(true);
                        enemy.TakeDamage(player.heavyDamage / 2);
                    }
                }

            }
        }
        if (player.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Triggered");
                Player enemy = collision.GetComponent<Player>();
                if (enemy != null)
                {
                    if (enemy.isBlocking == 0)
                    {
                        if (player.isAttacking) enemy.TakeDamage(player.lightDamage);
                        if (player.isHeavyAttacking) enemy.TakeDamage(player.heavyDamage);
                    }
                    if (player.isHeavyAttacking && enemy.isBlocking == 1 && player.blockBreak == true)
                    {
                        enemy.BlockBroke(true);
                        enemy.TakeDamage(player.heavyDamage / 2);
                    }
                }

            }
        }

    }
    
}