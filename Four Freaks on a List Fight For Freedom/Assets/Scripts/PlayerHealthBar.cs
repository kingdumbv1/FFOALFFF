using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public Image healthFillImage;
    public Image passiveFillImage;
    [SerializeField] Player player;
    private void Start()
    {
        player = GetComponent<Player>();
        StartCoroutine(SendData());
    }
    public void FindHealthBarNPassive(Image health, Image passive)
    {
        healthFillImage = health;
        passiveFillImage = passive;
    }
    private void Update()
    {
        //healthFillImage.
        if (healthFillImage != null)
        {
            healthFillImage.fillAmount = player.currentHealth * 0.01f;
        }
        if (passiveFillImage != null)
        {
            passiveFillImage.fillAmount = player.currentPassive * 0.02f;
        }
        //passive.fillAmount = player.currentPassive * 0.02f;
    }
    IEnumerator SendData()
    {
        yield return new WaitForSeconds(1);
        if (player.CompareTag("Player"))
        {
            healthFillImage = GameObject.Find("UI/Player Health").GetComponent<Image>();
            passiveFillImage = GameObject.Find("UI/Player Passive").GetComponent<Child>().image;
        }
    }
}
