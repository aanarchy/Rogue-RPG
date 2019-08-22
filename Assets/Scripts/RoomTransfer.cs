using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraMin;
    public Vector2 cameraMax;
    public Vector3 playerChange;
    private CameraMovement cam;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>(); 
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {    
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraMin;
            cam.maxPosition += cameraMax;
            other.transform.position += playerChange;
        }
    }
} 