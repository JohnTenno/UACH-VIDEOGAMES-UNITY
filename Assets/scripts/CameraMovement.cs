using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    // Método para obtener los límites de la cámara
    public Vector2 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        return mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }
}
