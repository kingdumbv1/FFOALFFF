using UnityEngine;

public class FindMedian : MonoBehaviour
{
    [SerializeField] Transform foundPlayer;
    [SerializeField] Transform foundPlayer2;
    [SerializeField] Vector3 foundPlayerPosition;
    [SerializeField] Vector3 foundPlayer2Position;

    private void Start()
    {
        foundPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        foundPlayer2 = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    private void Update()
    {
        foundPlayerPosition = new Vector3(foundPlayer.position.x + 1.5f, foundPlayer.position.y + 1.5f, -10);
        foundPlayer2Position = new Vector3(foundPlayer2.position.x + 1.5f, foundPlayer2.position.y + 1.5f, -10);
        transform.position = (foundPlayerPosition + foundPlayer2Position)/ 2.0f;
    }

}
