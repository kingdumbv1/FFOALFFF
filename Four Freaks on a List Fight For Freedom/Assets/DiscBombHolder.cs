using UnityEngine;

public class DiscBombHolder : MonoBehaviour
{
    public bool destroy;
    private void Update()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
}
