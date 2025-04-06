using UnityEngine;

public class DiscBomb : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] DiscBombHolder holder;

    private void Awake()
    {
        holder = GetComponentInParent<DiscBombHolder>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Explode");
        gameObject.layer = 0;
    }
    private void OnDestroy()
    {
        holder.destroy = true;
    }
}
