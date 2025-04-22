using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image health;
    public Image passive;
    [SerializeField] Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (health != null)
        {
            health.fillAmount = player.currentHealth * 0.01f;
        }
        //passive.fillAmount = player.currentPassive * 0.02f;
    }
}
