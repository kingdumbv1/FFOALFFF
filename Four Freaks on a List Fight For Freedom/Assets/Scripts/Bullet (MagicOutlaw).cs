using System.Collections;
using UnityEngine;

public class BulletMagicOutlaw : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform enemy;
    [SerializeField] float t;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool switched;
    public void InheritParents(Player playerInherited, Transform enemyInherited)
    {
        player = playerInherited;
        enemy = enemyInherited;
    }
    public void InheritSwitch(bool trufalse)
    {
        switched = trufalse;
    }
    private void Start()
    {
        int distanceCheck()
        {
            if (player.distance < 0) return 1;
            if (player.distance > 0) return -1;
            return 1;
        }
        rb = GetComponent<Rigidbody2D>();
        //random 0 - 180
        int randomDegree = Random.Range(135, 225);
        Debug.Log(gameObject.name + " " + randomDegree);
        rb.linearVelocityX = Mathf.Cos(randomDegree * Mathf.Deg2Rad) * 5 * -distanceCheck();
        rb.linearVelocityY = Mathf.Sin(randomDegree * Mathf.Deg2Rad) * 5;
        StartCoroutine(TheSwitch());
    }
    private void Update()
    {
        if (switched)
        {
            t += Time.deltaTime / 2;
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, enemy.position.x, t), Mathf.Lerp(transform.position.y, enemy.position.y, t), -5);
        }
    }
    
    IEnumerator TheSwitch()
    {
        yield return new WaitForSeconds(0.5f);
        switched = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (switched && collision.CompareTag(enemy.tag))
        {
            Destroy(gameObject);
        }
    }
}
