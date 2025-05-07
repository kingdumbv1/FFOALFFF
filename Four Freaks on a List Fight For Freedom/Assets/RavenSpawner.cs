using UnityEngine;

public class RavenSpawner : MonoBehaviour
{
    [SerializeField] GameObject raven;
    float start = -15f;
    float end = 19f;
    float randomInterval;
    float randomX;
    int randomAmountOfRavens;
    Vector3 randomPosition = Vector3.zero;

    private void Start()
    {
        randomInterval = Random.Range(1f, 2.5f);
        randomX = Random.Range(start, end);
    }
    private void Update()
    {
        randomInterval -= Time.deltaTime;
        if (randomInterval <= 0)
        {
            GameObject Iraven = Instantiate(raven, Vector3.zero, Quaternion.identity);
            Iraven.transform.SetParent(null);
            Iraven.transform.position = new Vector3(randomX, 4.5f, -5);
            randomInterval = Random.Range(0.1f, 1.1f);
            randomX = Random.Range(start, end);
        }
    }
}
