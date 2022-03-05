using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        NextLevel.hasWin = false;
        BulletLaser.damageStatic = 30;
        Enemy.healthStatic = 100;
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
