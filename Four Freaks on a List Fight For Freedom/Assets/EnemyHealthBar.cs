using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] Slider health;
    [SerializeField] Slider posture;
    [SerializeField] Slider ult;
    [SerializeField] Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        health.value = enemy.currentHealth;
        health.maxValue = enemy.currentMaxHealth;
        posture.value = enemy.currentPosture;
        posture.maxValue = enemy.currentMaxPosture;
    }
}
