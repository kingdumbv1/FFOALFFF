using System.Collections;
using UnityEngine;

public class FindMedian : MonoBehaviour
{
    public Transform foundPlayer;
    public Transform foundPlayer2;
    [SerializeField] Vector3 foundPlayerPosition;
    [SerializeField] Vector3 foundPlayer2Position;

    public void InheritParent(Transform player)
    {
        player = foundPlayer;
    }
    private void Start()
    {
        foundPlayer2 = GameObject.FindWithTag("Enemy").transform;
    }
    private void Update()
    {
        if (foundPlayer != null && foundPlayer2 != null)
        {
            foundPlayerPosition = new Vector3(foundPlayer.position.x, foundPlayer.position.y + 1, -10);
            foundPlayer2Position = new Vector3(foundPlayer2.position.x, foundPlayer2.position.y + 1, -10);
            transform.position = (foundPlayerPosition + foundPlayer2Position) / 2.0f;
        } else
            foundPlayer = GameObject.FindWithTag("Player").transform;
    }
}
