using UnityEngine;

public class HandPortal : MonoBehaviour
{
    Player player;

    public void InheritParent(Player parent)
    {
        player = parent;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(player.enemy.tag))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            enemy.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        }
    }
}
