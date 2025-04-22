using UnityEngine;
using System.Collections;

public class Lasso : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform enemy;
    [SerializeField] Player player;
    bool wrangled;
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

}
