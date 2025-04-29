using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArrayOfHealthbars : MonoBehaviour
{
    [SerializeField] GameObject[] healthbars;
    [SerializeField] Transform[] healthbarSpawnAreas;
    [SerializeField] FindMedian cameraMedian;

    private void Start()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForEndOfFrame();
        cameraMedian = FindAnyObjectByType<FindMedian>();


        //Characters: prototype, raven, rockstar, dj, outlaw.
        Player player = cameraMedian.foundPlayer.GetComponent<Player>();
        if (player.chosenCharacter == "rockstar")
        {
            GameObject playerhealthbar = Instantiate(healthbars[0], healthbarSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer.GetComponent<PlayerHealthBar>();
            playerHealth.health = playerhealthbar.GetComponent<Image>();
            playerhealthbar.transform.SetParent(transform);
            playerhealthbar.name = "Player Health";

        }
        if (player.chosenCharacter == "raven")
        {
            GameObject playerhealthbar = Instantiate(healthbars[1], healthbarSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer.GetComponent<PlayerHealthBar>();
            playerHealth.health = playerhealthbar.GetComponent<Image>();
            playerhealthbar.transform.SetParent(transform);
            playerhealthbar.name = "Player Health";
        }
        if (player.chosenCharacter == "outlaw")
        {
            GameObject playerhealthbar = Instantiate(healthbars[2], healthbarSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer.GetComponent<PlayerHealthBar>();
            playerHealth.health = playerhealthbar.GetComponent<Image>();
            playerhealthbar.transform.SetParent(transform);
            playerhealthbar.name = "Player Health";
        }
        if (player.chosenCharacter == "dj")
        {
            GameObject playerhealthbar = Instantiate(healthbars[3], healthbarSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer.GetComponent<PlayerHealthBar>();
            playerHealth.health = playerhealthbar.GetComponent<Image>();
            playerhealthbar.transform.SetParent(transform);
            playerhealthbar.name = "Player Health";
        }
        // Player 2
        Player player2 = cameraMedian.foundPlayer2.GetComponent<Player>();
        if (player2.chosenCharacter == "rockstar")
        {
            GameObject player2healthbar = Instantiate(healthbars[0], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.health = player2healthbar.GetComponent<Image>();
            player2healthbar.transform.SetParent(transform);
            player2healthbar.name = "Enemy Health";
        }
        if (player2.chosenCharacter == "raven")
        {
            GameObject player2healthbar = Instantiate(healthbars[1], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.health = player2healthbar.GetComponent<Image>();
            player2healthbar.transform.SetParent(transform);
            player2healthbar.name = "Enemy Health";
        }
        if (player2.chosenCharacter == "outlaw")
        {
            GameObject player2healthbar = Instantiate(healthbars[2], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.health = player2healthbar.GetComponent<Image>();
            player2healthbar.transform.SetParent(transform);
            player2healthbar.name = "Enemy Health";
        }
        if (player2.chosenCharacter == "dj")
        {
            GameObject player2healthbar = Instantiate(healthbars[3], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.health = player2healthbar.GetComponent<Image>();
            player2healthbar.transform.SetParent(transform);
            player2healthbar.name = "Enemy Health";
        }
    }
}
