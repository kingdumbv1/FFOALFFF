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
    }

    private void Update()
    {
        if (healthFillImage != null)
        {
            healthFillImage.fillAmount = player.currentHealth * 0.01f;
        }
        if (passiveFillImage != null)
        {
            Debug.Log(passiveFillImage.name);
            passiveFillImage.fillAmount = player.currentPassive * 0.02f;
        }
        //passive.fillAmount = player.currentPassive * 0.02f;
    }
}
