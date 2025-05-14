using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject UI;
    Player player;
    public void TransferPlayer(Player playerTransferred)
    {
        player = playerTransferred;
    }
    public void Resume()
    {
        player.isPaused = false;
        UI.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Settings()
    {

    }
    public void Exit()
    {
        GameObject data = FindFirstObjectByType<DataSave>().gameObject;
        Destroy(data);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
