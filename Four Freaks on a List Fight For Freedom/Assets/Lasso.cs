using UnityEngine;
using System.Collections;

public class Lasso : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform enemy;
    [SerializeField] Player player;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] bool wrangled;
    void OnEnable()
    {
        if (line == null && player == null)
        {
            line = GetComponent<LineRenderer>();
            player = GetComponentInParent<Player>();
        }
        if (rend == null)
        {
            rend = GetComponentInParent<SpriteRenderer>();
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
        if (wrangled && rend.enabled)
        {
            player.animator.SetBool("IsWrangled", true);
        }

        if (rend.enabled == false)
        {
            wrangled = false;
            player.animator.SetBool("IsWrangled", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(player.enemy.tag) && rend.enabled)
        {
            Debug.Log("Wrangled!");
            wrangled = true;
        }
    }
   
}
