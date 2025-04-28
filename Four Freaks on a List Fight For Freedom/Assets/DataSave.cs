using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class DataSave : MonoBehaviour
{
    GameObject[] Characters;
    GameObject player;
    List<int> Stages = new List<int>
    {0, 1, 2, 3};

    void SetPlayerCharacter_DJ()
    {
        player = Characters[0];
        Stages.Remove(0);
    }
    void SetPlayerCharacter_MO()
    {
        player = Characters[1];
        Stages.Remove(1);
    }
    void SetPlayerCharacter_RF()
    {
        player = Characters[2];
        Stages.Remove(2);
    }
    void SetPlayerCharacter_RA()
    {
        player = Characters[3];
        Stages.Remove(3);
    }
    void StartGame()
    {
        int randomDegree = Random.Range(0, Stages.Count);
        SceneManager.LoadScene(randomDegree);
    }
}
