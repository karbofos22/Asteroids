using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void GameRestart()
    {
        EventManager.SendRestart();
        EventManager.OnLose.RemoveAllListeners();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
