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
                hasWin = true;
                SceneManager.LoadScene(0);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            }
        }
    }
}
