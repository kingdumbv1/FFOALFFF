using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Multiplayer : MonoBehaviour
{
    CharacterArray characters;
    GameObject player1;
    GameObject player2;
    bool p1Selected;
    bool p2Selected;
    [SerializeField] Button[] p1Buttons;
    [SerializeField] Button[] p2Buttons;
    PlayerInputManager inputManager;
    CharacterArray characterArray;
    int mapSelection;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        inputManager = GetComponent<PlayerInputManager>();
        characterArray = GameObject.FindFirstObjectByType<CharacterArray>();
    }

    public void SelectPlayer1(string selectedCharacter)
    {
        switch (selectedCharacter)
        {
            case "raven":
                GameObject raven = characterArray.Characters[2];
                raven.GetComponent<Player>().enabled = false;
                raven.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = raven;
                p1Selected = true;
                break;
            case "dj":
                GameObject dj = characterArray.Characters[0];
                dj.GetComponent<Player>().enabled = false;
                dj.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = dj;
                p1Selected = true;
                break;
            case "outlaw":
                GameObject outlaw = characterArray.Characters[1];
                outlaw.GetComponent<Player>().enabled = false;
                outlaw.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = outlaw;
                break;
            case "rockstar":
                GameObject rockstar = characterArray.Characters[3];
                rockstar.GetComponent<Player>().enabled = false;
                rockstar.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = rockstar;
                p1Selected = true;
                break;
        }
    }
    public void SelectPlayer2(string selectedCharacter)
    {
        switch (selectedCharacter)
        {
            case "raven":
                GameObject raven = characterArray.Characters[2];
                raven.GetComponent<Player>().enabled = false; 
                raven.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = raven;
                p2Selected = true;
                break;
            case "dj":
                GameObject dj = characterArray.Characters[0];
                dj.GetComponent<Player>().enabled = false;
                dj.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = dj;
                p2Selected = true;
                break;
            case "outlaw":
                GameObject outlaw = characterArray.Characters[1];
                outlaw.GetComponent<Player>().enabled = false;
                outlaw.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = outlaw;
                p2Selected = true;
                break;
            case "rockstar":
                GameObject rockstar = characterArray.Characters[3];
                rockstar.GetComponent<Player>().enabled = false;
                rockstar.GetComponent<SpriteRenderer>().enabled = false;
                inputManager.playerPrefab = rockstar;
                p2Selected = true;
                break;
        }
    }
    public void Ready(int playerReadied)
    {
       if (playerReadied == 1 && p1Selected)
        {
            foreach (Button b in p1Buttons)
            {
                b.enabled = false;
                b.GetComponent<Image>().color = Color.gray;
            }
        }
        if (playerReadied == 2 && p2Selected)
        {
            foreach (Button b in p2Buttons)
            {
                b.enabled = false;
                b.GetComponent<Image>().color = Color.gray;
            }
        }
    }
}
