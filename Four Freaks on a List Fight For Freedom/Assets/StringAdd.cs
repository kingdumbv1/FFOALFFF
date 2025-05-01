using UnityEngine;

public class StringAdd : MonoBehaviour
{
    [SerializeField] string chosenCharacter;
    [SerializeField] Multipklayer multiData;

    private void Awake()
    {
        multiData = GetComponent<Multipklayer>();
    }

}
