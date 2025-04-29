using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] DataSave data;
    [SerializeField] GameManager gameManager;
    private void Start()
    {
        data = FindFirstObjectByType<DataSave>();
        gameManager = FindFirstObjectByType<GameManager>();

        if (data != null && data.player != null)
        {
            Instantiate(data.player, transform.position, Quaternion.identity);
        }
    }
}
