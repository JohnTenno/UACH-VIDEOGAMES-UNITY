using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInit : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
     public TextMeshProUGUI continueText;  
    public List<string> tutorialTexts;  
    public float typingSpeed = 0.05f; 
    private int currentTextIndex = 0;  
    private bool isTyping = false;   
    private bool textCompleted = false;
    [SerializeField] protected PauseResumen pauseGame; 
    public float initialDelay = 0.5f; 

    void Start()
    {
        continueText.gameObject.SetActive(false);
        StartCoroutine(StartTutorialWithDelay()); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && textCompleted)
        {
            continueText.gameObject.SetActive(false);
            ShowNextText();
        }
    }

    void ShowNextText()
    {
        if (!isTyping && textCompleted) 
        {
            currentTextIndex++;
            if (currentTextIndex < tutorialTexts.Count)
            {
                StartCoroutine(TypeText(tutorialTexts[currentTextIndex]));
            }
            else
            {
                tutorialText.text = ""; 
                pauseGame.ResumeByTutorial();  
            }
        }
    }

    IEnumerator TypeText(string text)
    {
        tutorialText.text = "";  
        isTyping = true;  
        textCompleted = false; 

        foreach (char letter in text.ToCharArray())
        {
            tutorialText.text += letter; 
            yield return new WaitForSecondsRealtime(typingSpeed); 
        }
        textCompleted = true;  
        yield return new WaitForSecondsRealtime(1f); 
        isTyping = false; 
         continueText.gameObject.SetActive(true);
    }

    IEnumerator StartTutorialWithDelay()
    {
        yield return new WaitForSecondsRealtime(initialDelay);  
        pauseGame.PauseByTutorial(); 

        if (tutorialTexts.Count > 0)
        {
            StartCoroutine(TypeText(tutorialTexts[currentTextIndex]));
        }
    }
}
