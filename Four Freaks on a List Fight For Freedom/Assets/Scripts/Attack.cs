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
                if (enemy != null && enemy.isBlocking == 0)
                {
                    if (player.isAttacking) enemy.TakeDamage(player.lightDamage);


                }
                if (enemy != null && player.isAttacking && enemy.isBlocking == 1 && player.blockBreak == true)
                {
                    enemy.BlockBroke();
                }

            }
        }
        
        
    }
    
}