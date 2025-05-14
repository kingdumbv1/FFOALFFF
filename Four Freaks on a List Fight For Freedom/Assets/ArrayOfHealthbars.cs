using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArrayOfHealthbars : MonoBehaviour
{
    [SerializeField] GameObject[] healthbars;
    [SerializeField] GameObject[] passives;
    [SerializeField] Transform[] healthbarSpawnAreas;
    [SerializeField] Transform[] passiveSpawnAreas;
    [SerializeField] FindMedian cameraMedian;
    public Player player;
    public Player player2;
    public GameObject pauseMenu;
    private void Start()
    { 
        player2 = GameObject.FindWithTag("Enemy").GetComponent<Player>();
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForEndOfFrame();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        cameraMedian = FindAnyObjectByType<FindMedian>();


        //Characters: prototype, raven, rockstar, dj, outlaw.
        if (player.chosenCharacter == "rockstar")
        {
            GameObject instantiatedHealthBar = Instantiate(healthbars[0], healthbarSpawnAreas[0].position, Quaternion.identity);
            GameObject instantiatedPassive = Instantiate(passives[0], passiveSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = FindFirstObjectByType<DataSave>().player.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive.GetComponent<Child>().image;
            instantiatedHealthBar.transform.SetParent(transform);
            instantiatedHealthBar.name = "Player Health";
            instantiatedPassive.transform.SetParent(transform);
            instantiatedPassive.name = "Player Passive";

        }
        if (player.chosenCharacter == "raven")
        {
            GameObject instantiatedHealthBar = Instantiate(healthbars[1], healthbarSpawnAreas[0].position, Quaternion.identity);
            GameObject instantiatedPassive = Instantiate(passives[1], passiveSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = FindFirstObjectByType<DataSave>().player.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive.GetComponent<Child>().image;
            instantiatedHealthBar.transform.SetParent(transform);
            instantiatedHealthBar.name = "Player Health";
            instantiatedPassive.transform.SetParent(transform);
            instantiatedPassive.name = "Player Passive";
        }
        if (player.chosenCharacter == "outlaw")
        {
            GameObject instantiatedHealthBar = Instantiate(healthbars[2], healthbarSpawnAreas[0].position, Quaternion.identity);
            GameObject instantiatedPassive = Instantiate(passives[2], passiveSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = FindFirstObjectByType<DataSave>().player.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive.GetComponent<Child>().image;
            instantiatedHealthBar.transform.SetParent(transform);
            instantiatedHealthBar.name = "Player Health";
            instantiatedPassive.transform.SetParent(transform);
            instantiatedPassive.name = "Player Passive";
        }
        if (player.chosenCharacter == "dj")
        {
            GameObject instantiatedHealthBar = Instantiate(healthbars[3], healthbarSpawnAreas[0].position, Quaternion.identity);
            GameObject instantiatedPassive = Instantiate(passives[3], passiveSpawnAreas[0].position, Quaternion.identity);
            PlayerHealthBar playerHealth = FindFirstObjectByType<DataSave>().player.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive.GetComponent<Child>().image;
            instantiatedHealthBar.transform.SetParent(transform);
            instantiatedHealthBar.name = "Player Health";
            instantiatedPassive.transform.SetParent(transform);
            instantiatedPassive.name = "Player Passive";
        }
        // Player 2
        if (player2.chosenCharacter == "rockstar")
        {
            GameObject instantiatedHealthBar2 = Instantiate(healthbars[0], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            GameObject instantiatedPassive2 = Instantiate(passives[0], passiveSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar2.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive2.GetComponent<Child>().image;
            instantiatedHealthBar2.transform.SetParent(transform);
            instantiatedHealthBar2.name = "Enemy Health";
            instantiatedPassive2.transform.SetParent(transform);
            instantiatedPassive2.name = "Enemy Passive";
        }
        if (player2.chosenCharacter == "raven")
        {
            GameObject instantiatedHealthBar2 = Instantiate(healthbars[1], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            GameObject instantiatedPassive2 = Instantiate(passives[1], passiveSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar2.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive2.GetComponent<Child>().image;
            instantiatedHealthBar2.transform.SetParent(transform);
            instantiatedHealthBar2.name = "Enemy Health";
            instantiatedPassive2.transform.SetParent(transform);
            instantiatedPassive2.name = "Enemy Passive";
        }
        if (player2.chosenCharacter == "outlaw")
        {
            GameObject instantiatedHealthBar2 = Instantiate(healthbars[2], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            GameObject instantiatedPassive2 = Instantiate(passives[2], passiveSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar2.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive2.GetComponent<Child>().image;
            instantiatedHealthBar2.transform.SetParent(transform);
            instantiatedHealthBar2.name = "Enemy Health";
            instantiatedPassive2.transform.SetParent(transform);
            instantiatedPassive2.name = "Enemy Passive";
        }
        if (player2.chosenCharacter == "dj")
        {
            GameObject instantiatedHealthBar2 = Instantiate(healthbars[3], healthbarSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            GameObject instantiatedPassive2 = Instantiate(passives[3], passiveSpawnAreas[1].position, Quaternion.Euler(0, 180, 0));
            PlayerHealthBar playerHealth = cameraMedian.foundPlayer2.GetComponent<PlayerHealthBar>();
            playerHealth.healthFillImage = instantiatedHealthBar2.GetComponent<Image>();
            playerHealth.passiveFillImage = instantiatedPassive2.GetComponent<Child>().image;
            instantiatedHealthBar2.transform.SetParent(transform);
            instantiatedHealthBar2.name = "Enemy Health";
            instantiatedPassive2.transform.SetParent(transform);
            instantiatedPassive2.name = "Enemy Passive";
        }
    }
}
