using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] string[] currentText;
    //int amountOfHits()
    //{

    //    return 1;
    //    return 0;
    //    return -1;
    //}
    Player player;
    
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        //currentText = new string[]
        //{
        //    "Welcome to Four Freaks! For the tutorial, I'm " +
        //   "going to show you the basic inputs for how all characters are structured. " +
        //    "To start off, try clicking your light attack button, and hitting the enemy three times. " +
        //    amountOfHits(),

        //};
        
        inputField.text = currentText[0];
        Debug.Log(player.name);
    }

    void Update()
    {
        
    }
}