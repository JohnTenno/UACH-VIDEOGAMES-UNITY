using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumen : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject buttonResume;

    void Start() {
        resume();
    }

    public void pause()
    {
        buttonResume.SetActive(false);
        panelPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        buttonResume.SetActive(true);
        panelPausa.SetActive(false);
        Time.timeScale = 1;
    }
}
