using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider health;
    [SerializeField] Slider posture;
    [SerializeField] Slider ult;
    [SerializeField] Player player;

    private void Start()
    {
        player = GetComponent<Player>();

        if (player.CompareTag("Player"))
        { 
            health = GameObject.Find("/UI/Player Health").GetComponent<Slider>();
            posture = GameObject.Find("/UI/Player Posture").GetComponent<Slider>();
            ult = GameObject.Find("/UI/Player Ult").GetComponent<Slider>();
        }
        if (player.CompareTag("Enemy"))
        {
            health = GameObject.Find("/UI/Enemy Health").GetComponent<Slider>();
            posture = GameObject.Find("/UI/Enemy Posture").GetComponent<Slider>();
            ult = GameObject.Find("/UI/Enemy Ult").GetComponent<Slider>();
        }
    }

    private void Update()
    {
        health.value = player.currentHealth;
        health.maxValue = player.currentMaxHealth;
        posture.value = player.currentPosture;
        posture.maxValue = player.currentMaxPosture;
    }
}
