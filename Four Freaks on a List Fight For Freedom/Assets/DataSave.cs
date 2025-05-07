using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DataSave : MonoBehaviour
{
    [SerializeField] Transform playerSpawner; 
    [SerializeField] GameObject[] Characters;
    [SerializeField] TMP_InputField[] playerInfo;
    [SerializeField] TMP_InputField[] moves;
    [SerializeField] GameObject[] animations;
    public GameObject player;
    [SerializeField]
    List<int> Stages = new List<int>
    {0, 1, 2, 3};
    [SerializeField] string chosenCharacter;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void charInfo()
    {
        //Characters: prototype, raven, rockstar, dj, outlaw.
        string playerCharacter = player.GetComponent<Player>().chosenCharacter;
        switch (playerCharacter)
        {
            case "raven":
                playerInfo[0].text = "Raven Fencer"; // name
                playerInfo[1].text = "The Raven Fencer is a class for fast paced players who prefer " +
                "quicker strikes and quickly thought counters."; // description
                playerInfo[2].text = "The higher the passive the faster he swings";

                foreach (GameObject i in animations)
                {
                    i.gameObject.SetActive(false);
                    if (i.name == "RFAnim")
                    {
                        i.gameObject.SetActive(true);
                    }
                }
                break;
            case "rockstar":
                playerInfo[0].text = "Rockstar Alien";
                playerInfo[1].text = "The Rockstar Alien is a rounded out character who excels at " +
                "being a <jack> of all trades with his combo passive.";
                playerInfo[2].text = "Higher passive makes larger sound waves";

                foreach (GameObject i in animations)
                {
                    i.gameObject.SetActive(false);
                    if (i.name == "RAAnim")
                    {
                        i.gameObject.SetActive(true);
                    }
                }
                break;
            case "dj":
                playerInfo[0].text = "DJ Vampire";
                playerInfo[1].text = "DJ Vampire is a blood sucking life stealer whos attacks are " +
                "strong and heavy hitting while also being smoother at the cost of lower health.";
                playerInfo[2].text = "Higher passive steals more health from opponents";

                foreach (GameObject i in animations)
                {
                    i.gameObject.SetActive(false);
                    if (i.name == "DJAnim")
                    {
                        i.gameObject.SetActive(true);
                    }
                }
                break;
            case "outlaw":
                playerInfo[0].text = "Magic Outlaw";
                playerInfo[1].text = "The Magic Outlaw is a class made for players who enjoy " +
                "surprising their opponents with unexpected combos and out of the ordinary techniques.";
                playerInfo[2].text = "Damage boost when taking damage while blocking";

                foreach (GameObject i in animations)
                {
                    i.gameObject.SetActive(false);
                    if (i.name == "MOAnim")
                    {
                        i.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }
    public void SetPlayerCharacter_DJ()
    {
        player = Characters[0];
        Stages.Clear();
        for (int i = 0; i < 4; i++)
        {
            Stages.Add(i);
        }
        Stages.Remove(0);
        
    }
    public void SetPlayerCharacter_MO()
    {
        player = Characters[1];
        Stages.Clear();
        for (int i = 0; i < 4; i++)
        {
            Stages.Add(i);
        }
        Stages.Remove(1);
       
    }
    public void SetPlayerCharacter_RF()
    {
        player = Characters[2];
        Stages.Clear();
        for (int i = 0; i < 4; i++)
        {
            Stages.Add(i);
        }
        Stages.Remove(2);
        
    }
    public void SetPlayerCharacter_RA()
    {
        player = Characters[3];
        Stages.Clear();
        for (int i = 0; i < 4; i++)
        {
            Stages.Add(i);
        }
        Stages.Remove(3);
        
    }
    public void StartGame()
    {
        int Stage = Random.Range(0, 4);
        if (Stage == 0) chosenCharacter = "Dj Vampire";
        if (Stage == 1) chosenCharacter = "Magic Outlaw";
        if (Stage == 2) chosenCharacter = "Raven Fencer";
        if (Stage == 3) chosenCharacter = "Rockstar Alien";
        if (!Stages.Contains(Stage))
        {
            Stage = Random.Range(0, 4);
            Debug.Log("Could not load " + player.name + " vs " + chosenCharacter);
        }
        if (Stages.Contains(Stage))
        {
            SceneManager.LoadScene(Stage + 2);
            Debug.Log("Loaded " + Stage);
            Debug.Log(player.name + " vs " + chosenCharacter);
        }
    }

    IEnumerator NextStage()
    {
        yield return new WaitForSeconds(2);
        //Stages.Remove();
    }
}
