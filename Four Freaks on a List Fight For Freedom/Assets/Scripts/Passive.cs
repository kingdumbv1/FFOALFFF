using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Passive : MonoBehaviour
{
    [SerializeField] TMP_InputField playerIntText;
    [SerializeField] Player player;
    bool canAddAgain = true;
    [SerializeField] int passiveInt = 0;
    private void Start()
    {
        player = GetComponent<Player>();

        if (player.CompareTag("Player"))
            playerIntText = GameObject.Find("UI/Passive Spawner (1)/P1 Passive Int").GetComponent<TMP_InputField>();
        if (player.CompareTag("Enemy"))
            playerIntText = GameObject.Find("UI/Passive Spawner (2)/P2 Passive Int").GetComponent<TMP_InputField>();
    }
    private void Update()
    {

        passiveInt = Mathf.Clamp(passiveInt, 0, 4);

        if (player.currentPassive >= 50)
        {
            passiveInt++;
            player.currentPassive = 0;
        }
        switch (player.chosenCharacter)
        {
            case "raven":
                playerIntText.text = passiveInt.ToString();
                player.animator.speed = 1 + ((float)passiveInt / 10);
                Debug.Log(player.animator.speed);
                if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("RavenFencerHeavyDown"))
                {
                    if (player.isHit && canAddAgain)
                    {
                        player.currentPassive += 20;
                        canAddAgain = false;
                        StartCoroutine(CanAddAgainTrue(""));
                    }
                }
                    break;
            case "rockstar":
                if (canAddAgain)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int randomInt = Random.Range(-1, 1);
                        string randomString = "";
                        string randomInput(int randomInt)
                        {
                            if (player.attackClickedFrame == 1)
                            {
                                if (player.currentDirection.y == 1 && randomInt == 1) return "W";

                                if (player.currentDirection.y == 0 && randomInt == 0) return " ";

                                if (player.currentDirection.y == -1 && randomInt == -1) return "S";
                            }
                            return " ";
                        }

                        randomString += randomInput(randomInt);
                        
                        if (i == 2)
                        {
                            canAddAgain = false;
                            playerIntText.text = passiveInt.ToString() + randomString;
                            StartCoroutine(CanAddAgainTrue(randomString));
                            Debug.Log(randomString);
                        }
                    }
                }
                
                break;
            case "dj":
                playerIntText.text = passiveInt.ToString();

                break;
            case "outlaw":
                playerIntText.text = passiveInt.ToString();
                if (passiveInt > 0) player.multiplier = 1 + (float)passiveInt / 8;
                if (player.isBlocking == 1 && canAddAgain && player.isHit)
                {
                    player.currentPassive += 10;
                    canAddAgain = false;
                    StartCoroutine(CanAddAgainTrue(""));
                }
                break;
        }

    }

    IEnumerator CanAddAgainTrue(string randomString)
    {
        yield return new WaitForSeconds(0.5f);
        if (player.chosenCharacter == "rockstar")
            playerIntText.text = passiveInt.ToString() + randomString;
        canAddAgain = true;
    }
}
