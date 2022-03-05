using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static bool hasWin = false;

    void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null) {
            if (SceneManager.GetActiveScene().name == "SecondScene") {
                NextLevel.hasWin = true;
                SceneManager.LoadScene(0);
            } else {
                NextLevel.hasWin = true;
                BulletLaser.damageStatic += 5;
			    Enemy.healthStatic += 10;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            }
        }
    }
}
