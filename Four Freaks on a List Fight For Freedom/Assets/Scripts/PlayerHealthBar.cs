using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider health;
    [SerializeField] Slider passive;
    [SerializeField] Slider ult;
    [SerializeField] Player player;

    private void Start()
    {
        player = GetComponent<Player>();

        if (player.CompareTag("Player"))
        { 
            health = GameObject.Find("/UI/Player Health").GetComponent<Slider>();
            passive = GameObject.Find("/UI/Player Posture").GetComponent<Slider>();
        }
        if (player.CompareTag("Enemy"))
        {
            health = GameObject.Find("/UI/Enemy Health").GetComponent<Slider>();
            passive = GameObject.Find("/UI/Enemy Posture").GetComponent<Slider>();
        }
    }

    private void Update()
    {
        health.value = player.currentHealth;
        health.maxValue = player.currentMaxHealth;
        passive.value = player.currentPosture;
        passive.maxValue = player.currentMaxPosture;
    }
}
