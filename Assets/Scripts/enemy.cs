using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float leftside;
    [SerializeField] private float rightside;
    [SerializeField] private float movement;
    [SerializeField] private LayerMask ground;


    private Collider2D coll;
    private Rigidbody2D rb;
    private bool facingleft = true;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       move();
    }

    private void move()
    {
         if(facingleft)
        {

            if(transform.position.x > leftside)
            {
                if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-movement, 0);
                }
            }
            else{
                facingleft = false;
            }
        }
        else
        {
            if(transform.position.x < rightside)
            {
                if(transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                 if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(movement, 0);
                }
            }
            else{
                facingleft = true;
            }
        }
    }
}
