using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [SerializeField] GameObject skeleton;
    Animator animator;
    float randomFloat;

    private void Start()
    {
        animator = GetComponent<Animator>();
        randomFloat = Random.Range(5, 21);
    }

    private void Update()
    {
        randomFloat -= Time.deltaTime;
        if (0 >= randomFloat)
        {
            animator.SetTrigger("Spawn");
            randomFloat = Random.Range(10, 21);
        }
    }
    public void InstantiateSkeleton()
    {
        Vector3 zAxisFix = new Vector3(transform.position.x, transform.position.y, -5);
        Instantiate(skeleton, zAxisFix, Quaternion.identity);
    }
}
