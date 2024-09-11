using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovementFix : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] public bool isRightMovement = true;
    [SerializeField] protected float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRightMovement == false)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
             transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
             transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }


}
