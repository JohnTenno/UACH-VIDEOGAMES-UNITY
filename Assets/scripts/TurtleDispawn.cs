using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleDispawn : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("turtle"))
        {
            Destroy(other.gameObject);
        }
    }
}
