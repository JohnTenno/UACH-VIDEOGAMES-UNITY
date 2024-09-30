using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInit : MonoBehaviour
{
    public TextMeshProUGUI tutorialText; // Asumiendo que estás usando TextMeshPro para el texto
    public string fullText = "Este es el tutorial de tu juego...";
    public float typingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        PauseGame(); // Pausar el juego al inicio
        StartCoroutine(TypeText());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el juego
    }

    // Reanudar el juego
    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el juego
    }

    // Efecto de escribir el texto lentamente
    IEnumerator TypeText()
    {
        tutorialText.text = ""; // Inicia con texto vacío
        foreach (char letter in fullText.ToCharArray())
        {
            tutorialText.text += letter; // Añade una letra
            yield return new WaitForSecondsRealtime(typingSpeed); // Usa Realtime para ignorar el Time.timeScale
        }
        yield return new WaitForSecondsRealtime(1f); // Espera un segundo al terminar el texto
        ResumeGame(); // Reanuda el juego cuando el tutorial finaliza
    }
}
