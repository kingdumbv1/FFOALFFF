using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Player player;
    int distanceCheck()
    {
        if (player.distance < 0) return 1;
        if (player.distance > 0) return -1;
        return 1;
    }
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
                Player enemy = collision.GetComponent<Player>();
                if (enemy != null)
                {
                    if (enemy.isBlocking == 0)
                    {
                        if (player.isAttacking) enemy.TakeDamage(player.lightDamage * player.multiplier, player.knockback); 
                        if (player.isHeavyAttacking) enemy.TakeDamage(player.heavyDamage * player.multiplier, player.knockback);
                    }
                    if (enemy.isBlocking == 1 && player.isAttacking)
                    {
                        Debug.Log("Called");
                        enemy.xMovementPossible = false;
                        enemy.rb.AddForce(Vector2.right * 1.5f * distanceCheck(), ForceMode2D.Impulse);
                    }
                    if (player.isHeavyAttacking && enemy.isBlocking == 1 && player.blockBreak == true)
                    {
                        enemy.BlockBroke(true);
                        enemy.TakeDamage(player.heavyDamage * player.multiplier / 2, player.knockback / 1.5f);
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
                    if (enemy.isBlocking == 0) // hitting an unblocked
                    {
                        if (player.isAttacking) enemy.TakeDamage(player.lightDamage * player.multiplier, player.knockback);
                        if (player.isHeavyAttacking) enemy.TakeDamage(player.heavyDamage * player.multiplier, player.knockback);
                    }
                    if (enemy.isBlocking == 1 && player.isAttacking) // Hitting a blocked person
                    {
                        Debug.Log("Called");
                        enemy.xMovementPossible = false;
                        enemy.rb.AddForce(Vector2.right * 1.5f * Mathf.Clamp(enemy.distance, -1, 1), ForceMode2D.Impulse);
                    }
                    if (player.isHeavyAttacking && enemy.isBlocking == 1 && player.blockBreak == true) // blockbreaking
                    {
                        enemy.BlockBroke(true);
                        enemy.TakeDamage(player.heavyDamage * player.multiplier/ 2, player.knockback / 1.5f);
                    }
                }

            }
        }

        if (gameObject.CompareTag("PlayerInstantiated"))
        {
            if (collision.CompareTag("Enemy"))
            {
                Player enemy = collision.GetComponent<Player>();
                if (enemy != null)
                {
                    if (enemy.isBlocking == 0) // hitting an unblocked
                    {
                        enemy.TakeDamage(player.instantiatedDamage * player.multiplier, player.knockback);
                    }
                    if (enemy.isBlocking == 1 && player.isAttacking) // Hitting a blocked person
                    {
                        enemy.xMovementPossible = false;
                        enemy.rb.AddForce(Vector2.right * 1.5f / 2 * Mathf.Clamp(enemy.distance, -1, 1), ForceMode2D.Impulse);
                    }
                    if (player.isHeavyAttacking && enemy.isBlocking == 1 && player.blockBreak == true) // blockbreaking
                    {
                        enemy.BlockBroke(true);
                        enemy.TakeDamage(player.heavyDamage * player.multiplier / 2, player.knockback / 1.5f);
                    }
                }
            }
        }

        if (gameObject.CompareTag("EnemyInstantiated"))
        {
            Debug.Log("Triggered");
            if (collision.CompareTag("Player"))
            {
                Player enemy = collision.GetComponent<Player>();
                if (enemy != null)
                {
                    if (enemy.isBlocking == 0) // hitting an unblocked
                    {
                        enemy.TakeDamage(player.instantiatedDamage * player.multiplier, player.knockback);
                    }
                    if (enemy.isBlocking == 1 && player.isAttacking) // Hitting a blocked person
                    {
                        enemy.TakeDamage(0, 0);
                        enemy.xMovementPossible = false;
                        enemy.rb.AddForce(Vector2.right * 1.5f / 2 * Mathf.Clamp(enemy.distance, -1, 1), ForceMode2D.Impulse);
                    }
                    if (player.isHeavyAttacking && enemy.isBlocking == 1 && player.blockBreak == true) // blockbreaking
                    {
                        enemy.BlockBroke(true);
                        enemy.TakeDamage(player.heavyDamage * player.multiplier / 2, player.knockback / 1.5f);
                    }
                }
            }
        }
    } 
    public void InheritParent(Player playerInherited)
    {
        player = playerInherited;
    }
}