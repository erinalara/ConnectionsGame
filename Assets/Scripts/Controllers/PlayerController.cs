using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //public static PlayerController Instance { get; private set; }
    public TransitionLoader tLoader;
    public Animator animator;
    public float speed;

    public bool interactionActivated;

    private PlayerManager playerManager;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        if (playerManager) 
            InitializePosition();
        GameObject cam = GameObject.FindGameObjectWithTag("CamBounds");
        if (cam) 
            Physics2D.IgnoreCollision(cam.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        interactionActivated = false;
        speed = 5f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ProcessInputs();
        if (!interactionActivated)
        {
            animator.SetBool("interactionActivated", false);
            Move();
        }
        else if (interactionActivated)
            animator.SetBool("interactionActivated", true);
        
    }

    void Awake()
    {
        /*if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }*/
    }

    /*void ProcessInputs()
    {
*//*        Vector2 movementDir = (Input.GetAxis("Horizontal"), ProcessInputs().GetAxis("Vertical"));
*//*    }*/

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 && vertical != 0)
        {
            horizontal = 0f;
            vertical = 0f;
        }
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        float sq = (float)Math.Sqrt((Math.Pow(horizontal, 2) + Math.Pow(vertical, 2)));
        animator.SetFloat("Speed", sq);
        
        position = transform.position;
        if (horizontal != 0)
        {
            position.x = position.x + speed * horizontal * Time.deltaTime;

        }
        else if (vertical != 0)
        {
            position.y = position.y + speed * vertical * Time.deltaTime;
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
            tLoader.StartTransition(collision.gameObject.name);
            playerManager.SetPosition(position);
        }

        // Game end
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Game end");
            var gc = GameObject.Find("PlayerManager").GetComponent<GameController>();
            if (gc)
                gc.ShowFinishMenu();

        }
        
    }

    void InitializePosition()
    {
        Vector2 pos = playerManager.GetPosition();
        transform.position = pos;
        TransitionScenes curr = tLoader.GetCurrentScene();
        if ((curr == TransitionScenes.NeighborhoodScene) || (curr == TransitionScenes.TownScene))
        {
            var cam = GameObject.Find("Main Camera");
            cam.transform.position = new Vector3(pos.x, pos.y, cam.transform.position.z);
        }
    }



}
