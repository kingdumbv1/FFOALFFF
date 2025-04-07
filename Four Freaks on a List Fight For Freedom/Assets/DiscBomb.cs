using UnityEngine;

public class DiscBomb : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Explode");
    }
}
