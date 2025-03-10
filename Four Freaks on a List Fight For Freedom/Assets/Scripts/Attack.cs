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
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Triggered");
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null && enemy.isBlocking == 0)
            {
                if (player.isAttacking) enemy.TakeDamage(player.lightDamage);
                //if (player.isAttacking) enemy.TakeDamage(player.heavyDamage);
            }
        }
    }
    void BlockBreak()
    {
        //
    }
}