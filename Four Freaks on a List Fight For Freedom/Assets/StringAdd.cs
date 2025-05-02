using UnityEngine;

public class StringAdd : MonoBehaviour
{
    [SerializeField] string chosenCharacter;
    [SerializeField] Multiplayer multiData;

    private void Awake()
    {
        multiData = GetComponent<Multiplayer>();
    }

}
