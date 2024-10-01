using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScrip : MonoBehaviour
{
    [SerializeField] protected PauseResumen pauseGame;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("win"))
        {
            pauseGame.Win();
        }
    }
}
