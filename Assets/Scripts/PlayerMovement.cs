using System.Collections;
using UnityEngine;

public enum PlayerState{
        walk,
        attack,
        interact
        }

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 change;
    public Animator a;

    void FixedUpdate()
    {
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector2.zero) {
            moveCharacter();
            a.SetFloat("Horizontal", change.x);
            a.SetFloat("Vertical", change.y);
            a.SetBool("Moving", true);
        } else {
            a.SetBool("Moving", false); 
        }
    }

    void moveCharacter()
    {
        rb.MovePosition(rb.position + change.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
