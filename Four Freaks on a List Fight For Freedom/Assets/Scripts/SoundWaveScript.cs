using UnityEngine;
using UnityEngine.UIElements;

public class SoundWaveScript : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }
    private void Update()
    {
        if (player.distance > 0)
        {
            rb.transform.Translate(-transform.right * Time.deltaTime * 2);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (player.distance < 0)
        {
            transform.rotation = Quaternion.identity;
            rb.transform.Translate(transform.right * Time.deltaTime * 2);
        }
    }
    private void OnDestroy()
    {
        player.instantiatedDamage = 0;
    }

}
