using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Triggered");
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null && enemy.isBlocking == 0) enemy.TakeDamage(player.lightDamage);
            //else if()
        }
    }
}
