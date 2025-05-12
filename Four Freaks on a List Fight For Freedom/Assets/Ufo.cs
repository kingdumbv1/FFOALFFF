using UnityEngine;

public class Ufo : MonoBehaviour
{
    Animator anim;
    bool isLerping;
    float startLerp;
    float endLerp;
    float t;
    LayerMask pLayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        startLerp = -19.37f;
        endLerp = 22.53f;
        isLerping = true;
    }
    void Update()
    {
        LayerMask pLayer = LayerMask.GetMask("Player1");
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 50, pLayer);
        if (isLerping)
        {
            t += 0.1f * Time.deltaTime;
            transform.position = new Vector3(Mathf.Lerp(startLerp, endLerp, t), 0, -5);
        }
        if (t > 1.0f)
        {
            float temp = endLerp;
            endLerp = startLerp;
            startLerp = temp;
            t = 0.0f;
        }
        if (ray)
        {
            isLerping = false;
            anim.SetTrigger("Attack");
        }
        if (!ray) isLerping = true;
    }
}
