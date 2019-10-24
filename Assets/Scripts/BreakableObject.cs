using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private Animator a;

    void Start()
    {
       a = GetComponent<Animator>(); 
    }

    public void Destroy() {
        a.SetBool("Destroyed", true);
    }
}
