using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public TransitionLoader tLoader;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
/*        ProcessInputs();
*/        Move();
        
    }

    /*void ProcessInputs()
    {
*//*        Vector2 movementDir = (Input.GetAxis("Horizontal"), ProcessInputs().GetAxis("Vertical"));
*//*    }*/

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        float sq = (float)Math.Sqrt((Math.Pow(horizontal, 2) + Math.Pow(vertical, 2)));
        animator.SetFloat("Speed", sq);
        
        Vector2 position = transform.position;
        if (horizontal != 0)
        {
            position.x = position.x + 3f * horizontal * Time.deltaTime;

        }
        else if (vertical != 0)
        {
            position.y = position.y + 3f * vertical * Time.deltaTime;
        }
        if (horizontal != 0 ||  vertical != 0)
        {
            animator.SetFloat("lastH", horizontal);
            animator.SetFloat("lastV", vertical);
        }

        /*Debug.Log(horizontal);
        Debug.Log(vertical);*/

        transform.position = position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Tile collision!");
        if (collision.gameObject.tag == "FloorExit")
        {
            tLoader.StartTransition();
        }
    }

}
