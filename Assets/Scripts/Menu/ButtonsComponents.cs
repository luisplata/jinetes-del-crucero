using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsComponents : MonoBehaviour
{
    public void ChangedScene(int sceneToChange)
    {
        SceneManager.LoadScene(sceneToChange);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}