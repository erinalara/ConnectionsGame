using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallalx : MonoBehaviour
{
    public Camera cam;
    public Transform subject;
    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    float distancefromSubject => transform.position.z - subject.position.z; // distance from subject
    float clippingPlane => (cam.transform.position.z + (distancefromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallelxFactor => Mathf.Abs(distancefromSubject) / clippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;

    }

    public void Update()
    {
        Vector2 newPos = startPosition + travel * parallelxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
        Debug.Log("parallel: " + transform.position.x);

        /*        transform.position = startPosition + travel * 0.9f;
        */
    }


}
