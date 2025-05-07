using System.Collections;
using UnityEngine;

public class Raven : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyOnInstantiate());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage(1, 0);
        }
        
    }

    IEnumerator DestroyOnInstantiate()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
