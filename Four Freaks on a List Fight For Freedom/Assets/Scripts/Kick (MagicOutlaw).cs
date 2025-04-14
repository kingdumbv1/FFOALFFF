using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class KickMagicOutlaw : MonoBehaviour
{
    [SerializeField] Player parent;
    public void InheritParent(Player player)
    {
        parent = player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (parent.CompareTag("Player"))
        {
            if (collision.CompareTag("Enemy"))
            {
                Player enemy = collision.GetComponent<Player>();
                Vector3 playerPos = parent.transform.position;
                Vector3 enemyPos = enemy.transform.position;
                enemy.rb.AddForceY(8, ForceMode2D.Impulse);
                StartCoroutine(Teleport());
            }
        }
        if (parent.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Player"))
            {
                Player enemy = collision.GetComponent<Player>();
                Vector3 playerPos = parent.transform.position;
                Vector3 enemyPos = enemy.transform.position;
                enemy.rb.AddForceY(8, ForceMode2D.Impulse);
                StartCoroutine(Teleport());
            }
        }
    }
    IEnumerator Teleport()
    {
        Vector3 playerPos = parent.transform.position;
        parent.animator.SetTrigger("IsTeleporting");
        yield return new WaitForSeconds(0.3f);
        parent.transform.Translate(Vector3.up * 3);
    }
}
