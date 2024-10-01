using UnityEngine;

public class PauseResumen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject dieSound;
    [SerializeField] private GameObject gameSound;
    [SerializeField] private GameObject winSound;
    [SerializeField] private GameObject buttonResume;

    private bool tutorialPause = false;

    void Start()
    {
        ResumeGame();
    }

    public void PauseByTutorial()
    {
        tutorialPause = true;
        PauseGame();
    }

    public void ResumeByTutorial()
    {
        tutorialPause = false;
        dialog.SetActive(false);
        ResumeGame();
    }

    public void PauseByDie()
    {
        ActivateSound(dieSound);
        PauseGame();
    }

    public void Win()
    {
        win.SetActive(true);
        winSound.SetActive(true);
        PauseGame();
    }

    public void PauseGame()
    {
        if (!tutorialPause)
        {
            buttonResume.SetActive(false);
            panelPausa.SetActive(true);
        }

        SetTimeScale(0);
        gameSound.SetActive(false);
    }

    public void ResumeGame()
    {
        buttonResume.SetActive(true);
        panelPausa.SetActive(false);
        SetTimeScale(1);
        gameSound.SetActive(true);
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    private void ActivateSound(GameObject soundObject)
    {
        soundObject.SetActive(true);
    }


}
