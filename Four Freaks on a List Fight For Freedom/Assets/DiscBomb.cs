using UnityEngine;

public class DiscBomb : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        animator.SetTrigger("Explode");
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
        if (collision.gameObject.CompareTag("Player") )
        {

        }
    }
}
