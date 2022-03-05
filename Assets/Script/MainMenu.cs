using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        NextLevel.hasWin = false;
        SceneManager.LoadScene(1);
    }
    public void ContinueGame ()
    {
        NextLevel.hasWin = true;
        SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
