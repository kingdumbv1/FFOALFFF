using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
