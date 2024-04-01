using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float _followspeed = 2f;
    public float yOffset = -1f;
    public Transform target;
    public GameObject camBounds;

    private Camera cam;
    private float camX, camY;
    private Vector2 minPosition, maxPosition;


    

    void Start()
    {

        cam = GetComponent<Camera>();
        var cameraHeight = 2f * cam.orthographicSize;
        var cameraWidth = cameraHeight * cam.aspect;

        // Calculate the min and max position based on the camera and map
        BoxCollider2D _collider = camBounds.GetComponent<BoxCollider2D>();
        var mapSize = _collider.bounds.size;
        var minPositionX = (camBounds.transform.position.x - (mapSize.x / 2)) + (cameraWidth / 2);
        var maxPositionX = (camBounds.transform.position.x + (mapSize.x / 2)) - (cameraWidth / 2);
        var minPositionY = (camBounds.transform.position.y - (mapSize.y / 2)) + (cameraHeight / 2);
        var maxPositionY = (camBounds.transform.position.y + (mapSize.y / 2)) - (cameraHeight / 2);

        minPosition = new Vector2(minPositionX, minPositionY);
        maxPosition = new Vector2(maxPositionX, maxPositionY);

    }

// Update is called once per frame
void Update()
    {
        camX = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
        camY = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);
        Vector3 newPos = new Vector3(camX, camY, -10f);
        Vector3 _pos = Vector3.Lerp(transform.position, newPos, _followspeed * Time.deltaTime);

        transform.position = _pos;

    }
}
