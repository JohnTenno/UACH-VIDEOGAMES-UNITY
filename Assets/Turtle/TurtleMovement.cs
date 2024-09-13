using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] public bool isRightMovement = true;
    [SerializeField] protected float speed = 5;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isRightMovement == false){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else{
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}