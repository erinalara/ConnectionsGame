using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        Debug.Log("cam: " + position.x);

        
        position.x +=  0.001f;
        transform.position = position;
        

        
    }
}
