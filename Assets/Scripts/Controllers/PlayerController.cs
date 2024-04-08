using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public TransitionLoader tLoader;
    public Animator animator;

    public bool interactionActivated;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("CamBounds");
        if (cam) 
            Physics2D.IgnoreCollision(cam.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        interactionActivated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ProcessInputs();
        if (!interactionActivated)
            Move();
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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

        transform.position = position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FloorExit")
        {
            tLoader.StartTransition();
        }
        
    }

    

}
