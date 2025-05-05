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
    [SerializeField] int passiveTarget = 0;
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
                player.currentMaxPassive = 50 * (passiveInt + 1);
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
                int input()
                {
                    if (player.attackClickedFrame == 1)
                    {
                        if (player.currentDirection.y == 1)
                            return 2;
                        if (player.currentDirection.y == 0)
                            return 1;
                        if (player.currentDirection.y == -1)
                            return 0;
                       
                    }
                    return 1;
                }
                int[] comboString =
                    {0, 0, 0};
                if (canAddAgain && passiveInt == passiveTarget)
                {
                    Debug.Log("canAddAgain is " + canAddAgain + " and passiveInt is " + passiveInt + " Target is " + passiveTarget); ;
                    passiveTarget++;
                    comboString = new int[]
                    {Random.Range(0,3), Random.Range(0,3), Random.Range(0,3)};
                    Debug.Log(comboString[0] + ", " + comboString[1] + ", " + comboString[2]);
                    canAddAgain = false;
                    StartCoroutine(CanAddAgainTrue(""));
                }
                foreach (int i in comboString)
                {
                    int currentComboInteger = 0;
                    if (input() == i)
                    {
                        comboString[currentComboInteger].CompareTo(input());
                        currentComboInteger++;
                    }
                }
                break;
            case "dj":
                playerIntText.text = passiveInt.ToString();

                break;
            case "outlaw":
                playerIntText.text = passiveInt.ToString();
                if (passiveInt > 0) player.multiplier = 1 + (float)passiveInt / 8;
                if (player.isBlocking == 1 && canAddAgain)
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
