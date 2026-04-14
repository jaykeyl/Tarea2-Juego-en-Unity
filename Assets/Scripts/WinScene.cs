using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain ()
    {
        SceneManager.LoadScene(1);
    }
}
