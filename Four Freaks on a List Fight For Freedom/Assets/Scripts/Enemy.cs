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
    public float isBlocking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        distance = transform.position.x - player.position.x;

        if (distance < 0) transform.rotation = Quaternion.identity;
        if (distance > 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine("HitIndicated", 0.2f);
    }
    IEnumerator HitIndicated(float seconds)
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(seconds);
        spriteRend.color = Color.white;
    }
}
