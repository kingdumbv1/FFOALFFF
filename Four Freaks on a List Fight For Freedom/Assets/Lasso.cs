using UnityEngine;
using System.Collections;

public class Lasso : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform enemy;
    [SerializeField] Player player;
    [SerializeField] bool wrangled;
    void OnEnable()
    {
        if (line == null && player == null)
        {
            line = GetComponent<LineRenderer>();
            player = GetComponentInParent<Player>();
        }
    }
    void LateUpdate()
    {
        if (line != null && line.enabled == true)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, player.animatorReference.hitBoxes[1].transform.position);
        }
    }
    private void Update()
    {
        if (wrangled)
        {
            
            player.animator.SetBool("IsWrangled", true);
            player.enemy.gameObject.layer = 8;
            player.enemy.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(player.enemy.tag))
        {
            Debug.Log("Wrangled!");
            wrangled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(player.enemy.tag))
        {
            Debug.Log(collision.tag);
            Debug.Log("Exit");
            wrangled = false;
            player.animator.SetBool("IsWrangled", false);
            if (player.CompareTag("Player")) player.enemy.gameObject.layer = 6;
            if (player.CompareTag("Enemy")) player.enemy.gameObject.layer = 3;
        }
    }
}
