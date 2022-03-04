using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideElementUI : MonoBehaviour
{
    public GameObject continueButton;
    void Start() 
    {
        if (NextLevel.hasWin) {
            continueButton.SetActive(true);
        }
        else {
            continueButton.SetActive(false);
        }
    }
}
