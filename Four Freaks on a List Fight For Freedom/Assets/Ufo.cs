using UnityEngine;

public class Ufo : MonoBehaviour
{
    Animator anim;
    float startLerp;
    float endLerp;
    int randomInt;
    LayerMask layer;
    void Start()
    {
        anim = GetComponent<Animator>();
        layer = 3;
        randomInt = Random.Range(1, 3);
    }
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 20, layer);

        if (ray && randomInt == 1)
        {
            anim.SetTrigger("Attack");
            randomInt = Random.Range(1, 3);
        }
    }
}
