using System.Collections;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform enemy;
    bool enemyCanTakeDmg;
    Player enemyScript;
    private void Start()
    {
        enemyCanTakeDmg = true;
        line = GetComponent<LineRenderer>();
        enemy = GetComponentInParent<Player>().enemy;
        enemyScript = enemy.GetComponent<Player>();
    }

    private void LateUpdate()
    {
        if (line != null && line.enabled == true && enemy != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, enemy.position);
            if (enemyCanTakeDmg) StartCoroutine("Siphon", 0.1);
        }
        
    }
    IEnumerator Siphon(float seconds)
    {
        enemyCanTakeDmg = false;
        while (line != null && line.enabled == true && enemy != null)
        {
            yield return new WaitForSeconds(seconds);
            enemyScript.TakeDamage(2, 0);
        }
    }

    private void OnDisable()
    {
        enemyCanTakeDmg = true;
    }
}
