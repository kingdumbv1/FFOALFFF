using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float interval;
    int direction = 1;

    void Update()
    {
        interval += Time.deltaTime;
        if (interval > 8)
        {
            interval = 0;
            direction *= -1;
        }
        rb.linearVelocityX += (2 * direction) * Time.deltaTime;
    }
}