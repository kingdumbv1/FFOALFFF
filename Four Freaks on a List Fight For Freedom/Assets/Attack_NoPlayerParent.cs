using System.Collections;
using UnityEngine;

public class Attack_NoPlayerParent : MonoBehaviour
{
    Collider2D col;
    public bool canAttack;
    bool canAttackAgain = true;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (canAttack && canAttackAgain)
        { 
            Debug.Log(canAttack && canAttackAgain);
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        col.enabled = true;
        canAttackAgain = false;
        yield return new WaitForSeconds(1);
        col.enabled = false;
        yield return new WaitForSeconds(1);
        canAttackAgain = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage(2, 0);
        }
    }
}
