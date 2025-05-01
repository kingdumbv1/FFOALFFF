using UnityEngine;

public class Multipklayer : MonoBehaviour
{
    CharacterArray characters;
    GameObject player1;
    GameObject player2;
    int mapSelection;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelectPlayer1(string selectedCharacter)
    {
        switch (selectedCharacter)
        {
            case "raven":
                //player1 = 
                break;
            case "dj":
                //characters.Characters[0]
                break;
            case "outlaw":

                break;
            case "rockstar":

                break;
        }
    }
    public void SelectPlayer2(string selectedCharacter)
    {
        switch (selectedCharacter)
        {
            case "raven":

                break;
            case "dj":

                break;
            case "outlaw":

                break;
            case "rockstar":

                break;
        }
    }
}
