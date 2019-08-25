using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraMin;
    public Vector2 cameraMax;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
	public Text placeText;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {    
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraMin;
            cam.maxPosition += cameraMax;
            other.transform.position += playerChange;
			if (needText) {
				StartCoroutine(placeNameCo());
			}
        }
    }

    private IEnumerator placeNameCo() {
		text.SetActive(true);
		placeText.text = placeName;
		yield return new WaitForSeconds(4.0f); 
		text.SetActive(false);
    }
} 
