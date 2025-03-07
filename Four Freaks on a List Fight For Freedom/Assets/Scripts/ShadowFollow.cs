using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    [SerializeField] Transform parent;

    private void Awake()
    {
        parent = GetComponentInParent<Transform>();
    }
    void Update()
    {
        //transform.position =  
    }
}
