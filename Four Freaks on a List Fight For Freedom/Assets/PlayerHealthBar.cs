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
    }

    private void Update()
    {
        health.value = player.currentHealth;
        health.maxValue = player.currentMaxHealth;
        posture.value = player.currentPosture;
        posture.maxValue = player.currentMaxPosture;
    }
}
