using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1.5f;
    public GameObject startTrans;

     void Start()
    {
        StartTransition();
    }

    public void StartTransition()
    {
        if(startTrans.GetComponent<CanvasGroup>().alpha > 0.0f)
        {
            startTrans.GetComponent<CanvasGroup>().alpha -= 0.1f;
        }
        Invoke("StartTransition", 0.05f);
    }
}
