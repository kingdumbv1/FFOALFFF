using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Multiplayer()
    {

    }
    public void Settings()
    {

    }
    public void Tutorial()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
