using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject db;
    public Text text;
    public string dialogue;
    public bool playerInRange;
    public GameObject player;
    private MonoBehaviour playerMovement;

    void Start() {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            if (db.activeInHierarchy) {
                db.SetActive(false);
                playerMovement.enabled = true;
            } else {
                db.SetActive(true); 
                text.text = dialogue; 
                playerMovement.enabled = false;
            }
        }
           
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            playerInRange = false;
            db.SetActive(false);
            playerMovement.enabled = true;
        }
    }
}
