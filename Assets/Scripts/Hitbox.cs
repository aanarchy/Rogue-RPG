using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Breakable")) {
            other.GetComponent<BreakableObject>().Destroy();
        }
    } 
}
