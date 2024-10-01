using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumen : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject buttonResume;
    public bool tutorialPause = false;

    void Start() {
        resume();
    }

    public void pauseByTutorial() {
         Debug.Log("raw");
        tutorialPause = true;
        pause();
    }

    public void resumeByTutorial() 
    {
         Debug.Log("not raw");
        tutorialPause = false;
        resume();
    }

    public void pause()
    {
        if(!tutorialPause) {
        buttonResume.SetActive(false);
        panelPausa.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void resume()
    {
        buttonResume.SetActive(true);
        panelPausa.SetActive(false);
        Time.timeScale = 1;
    }
}