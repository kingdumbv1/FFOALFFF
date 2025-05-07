using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Passive : MonoBehaviour
{
    [SerializeField] TMP_InputField playerIntText;
    [SerializeField] Player player;
    [SerializeField] Player enemy;
    bool canAddAgain = true;
    [SerializeField] int passiveInt = 0;
    [SerializeField] int maxPassiveInt = 4;
    int RFreductionAmount;
    int currentComboInteger = 0;
    int[] comboString = null; 
    public int MOShellCount = 5;
    public int input;
    private void Start()
    {
        player = GetComponent<Player>();
        if (player.CompareTag("Player"))
            playerIntText = GameObject.Find("UI/Passive Spawner (1)/P1 Passive Int").GetComponent<TMP_InputField>();
        if (player.CompareTag("Enemy"))
            playerIntText = GameObject.Find("UI/Passive Spawner (2)/P2 Passive Int").GetComponent<TMP_InputField>();
        StartCoroutine(GetEnemy());
        if (player.chosenCharacter == "rockstar")
        {
            comboString = new int[] { Random.Range(1, 4), Random.Range(1, 4), Random.Range(1, 4), Random.Range(1, 4) };
        }
    }
    private void Update()
    {

        passiveInt = Mathf.Clamp(passiveInt, 0, maxPassiveInt);

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
                if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("RavenFencerHeavyDown"))
                {
                    if (player.isHit && canAddAgain)
                    {
                        player.currentPassive += 20 - RFreductionAmount;
                        canAddAgain = false;
                        StartCoroutine(CanAddAgainTrue(0.5f));
                    }
                }
                if (player.currentPassive >= 50)
                {
                    RFreductionAmount += 5;
                }
                break;
            case "rockstar":
                maxPassiveInt = 10;
                player.multiplier = 1 + ((float)passiveInt / 20);
                string intToSymbol(int[] comboString)
                {
                    string[] newComboString = { comboString[0].ToString(), comboString[1].ToString(), comboString[2].ToString(), comboString[3].ToString() };
                    for (int i = 0; i < newComboString.Length; i++)
                    {
                        if (newComboString[i] == "1") newComboString[i] = "v";
                        if (newComboString[i] == "2") newComboString[i] = ">";
                        if (newComboString[i] == "3") newComboString[i] = "^";
                    }
                    string output = newComboString[0] + " " + newComboString[1] + " " + newComboString[2] + " " + newComboString[3];
                    return output;
                }
                playerIntText.text = passiveInt.ToString() + " " + intToSymbol(comboString);
                if (currentComboInteger > 3)
                {
                    comboString = new int[] { Random.Range(1, 4), Random.Range(1, 4), Random.Range(1, 4), Random.Range(1, 4) };
                    currentComboInteger = 0;
                }
                if (input == comboString[currentComboInteger] && canAddAgain)
                {
                    player.currentPassive += 15;
                    canAddAgain = false;
                    StartCoroutine(CanAddAgainTrue(0.1f));
                    input = 0;
                    currentComboInteger++;
                }
                break;
            case "dj":
                playerIntText.text = passiveInt.ToString();
                float lifesteal = (float)passiveInt / 3;
                lifesteal = Mathf.Clamp(lifesteal, 0, 3);
                if (enemy != null)
                {
                    if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("DJVampHeavyMiddle2") && enemy.isHit && canAddAgain)
                    {
                        canAddAgain = false;
                        player.currentHealth += lifesteal;
                        player.currentPassive += 5;
                        StartCoroutine(CanAddAgainTrue(0.1f));
                    }
                    if (enemy.isHit) player.currentHealth += lifesteal / 10;
                }
                player.currentPassive -= Time.deltaTime;
                if (player.currentPassive == -5) passiveInt = 0;
                break;
            case "outlaw":
                playerIntText.text = passiveInt.ToString();
                if (!player.isGrounded && player.isAttacking && enemy.isHit && canAddAgain)
                {
                    canAddAgain = false;
                    player.currentPassive += 25;
                    StartCoroutine(CanAddAgainTrue(0.5f));
                }
                MOShellCount = 5 + (passiveInt * 2);
                break;
        }

    }

    IEnumerator GetEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        enemy = player.enemy.GetComponent<Player>();
    }
    IEnumerator CanAddAgainTrue(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canAddAgain = true;
    }
}
