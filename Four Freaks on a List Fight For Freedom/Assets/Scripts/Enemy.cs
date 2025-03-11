using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float distance;
    [SerializeField] float maxHealth;
    [SerializeField] Transform player;
    [SerializeField] SpriteRenderer spriteRend;
    [SerializeField] Animator animator;
    public float isBlocking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = transform.position.x - player.position.x;

        if (distance < 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (distance > 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("Blocking");
            isBlocking = 1;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            animator.SetTrigger("Idle");
            isBlocking = 0;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger("Attacking");
            isBlocking = 0;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine("HitIndicated", 0.2f);
    }

    public void BlockBroke()
    {
        animator.SetTrigger("BlockBroke");
        isBlocking = 0;
    }
    IEnumerator HitIndicated(float seconds)
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(seconds);
        spriteRend.color = Color.white;
    }
}
