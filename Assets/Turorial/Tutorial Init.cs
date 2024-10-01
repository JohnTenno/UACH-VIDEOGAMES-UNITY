using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInit : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public List<string> tutorialTexts;  // Lista de textos del tutorial
    public float typingSpeed = 0.05f;  // Velocidad del efecto de tipeo
    private int currentTextIndex = 0;  // Índice del texto actual
    private bool isTyping = false;     // Bandera para saber si se está escribiendo
    private bool textCompleted = false; // Bandera para saber si el texto ya terminó
    [SerializeField] protected PauseResumen pauseGame; // Referencia al script de pausa
    public float initialDelay = 0.5f;  // Tiempo de espera inicial antes de pausar el juego

    void Start()
    {
        StartCoroutine(StartTutorialWithDelay()); // Iniciar el tutorial con un delay
    }

    void Update()
    {
        // Solo avanza si el texto ha sido completado y presionas Space
        if (Input.GetKeyDown(KeyCode.Space) && textCompleted)
        {
            ShowNextText();
        }
    }

    // Mostrar el siguiente texto en la lista
    void ShowNextText()
    {
        if (!isTyping && textCompleted) // Verificamos que no esté escribiendo ni haya texto pendiente
        {
            currentTextIndex++;
            if (currentTextIndex < tutorialTexts.Count)
            {
                StartCoroutine(TypeText(tutorialTexts[currentTextIndex]));
            }
            else
            {
                // Limpiar el texto antes de reanudar
                tutorialText.text = ""; // Limpiar el texto
                pauseGame.resumeByTutorial();  // Reanudar el juego cuando el tutorial finaliza
            }
        }
    }

    // Efecto de tipeo del texto
    IEnumerator TypeText(string text)
    {
        tutorialText.text = "";  // Limpiar el texto
        isTyping = true;  // Indicar que el texto se está escribiendo
        textCompleted = false;  // Texto aún no completado

        foreach (char letter in text.ToCharArray())
        {
            tutorialText.text += letter;  // Añadir cada letra una por una
            yield return new WaitForSecondsRealtime(typingSpeed);  // Esperar el tiempo de tipeo
        }

        // Una vez completado el texto
        textCompleted = true;  // Indicar que el texto ha sido completado
        yield return new WaitForSecondsRealtime(1f);  // Esperar un segundo antes de avanzar
        isTyping = false;  // Indicar que el texto ha terminado de escribirse
    }

    // Iniciar el tutorial después de un tiempo de espera
    IEnumerator StartTutorialWithDelay()
    {
        yield return new WaitForSecondsRealtime(initialDelay);  // Espera de medio segundo
        pauseGame.pauseByTutorial();  // Pausar el juego después del delay

        if (tutorialTexts.Count > 0)
        {
            StartCoroutine(TypeText(tutorialTexts[currentTextIndex]));
        }
    }
}
