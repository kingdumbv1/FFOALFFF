using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
    Attack_NoPlayerParent attack;
    SpriteRenderer sprite;
    [SerializeField] ParticleSystem deathEffect;
    int direction;
    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] float health = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        attack = GetComponentInChildren<Attack_NoPlayerParent>();
        sprite = GetComponent<SpriteRenderer>();
        speed = 5;
    }
    void Update()
    {
        distance = transform.position.x - player.transform.position.x;
        if (health <= 0)
        {
            Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 1);
            Destroy(gameObject);
        }
        if (distance < 0)
        {
            direction = 1;
            transform.rotation = Quaternion.identity;
        }
        if (distance > 0)
        {
            direction = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Mathf.Abs(distance) < 1)
        {
            attack.canAttack = true;
            speed = 0;
        }
        else if (Mathf.Abs(distance) > 1)
        {
            attack.canAttack = false;
            speed = 5;
        }
        
        rb.linearVelocityX += (speed * direction) * Time.deltaTime;
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -1.5f, 1.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player playerscript = collision.GetComponent<Player>();
            if (playerscript.isAttacking)
            {
                StartCoroutine(HitIndicated(playerscript.lightDamage));
            }
            if (playerscript.isHeavyAttacking)
            {
                StartCoroutine(HitIndicated(playerscript.heavyDamage));
            }
        }
    }
    IEnumerator HitIndicated(float damage)
    {
        health -= damage;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
