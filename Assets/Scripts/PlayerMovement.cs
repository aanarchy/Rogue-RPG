using System.Collections;
using UnityEngine;

public enum playerState{
        walk,
        attack,
        interact
}

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    Vector2 change;
    private Animator a;
    private playerState currentState;

    void Start () {
        a = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = playerState.walk;
        a.SetFloat("Horizontal", 0);
        a.SetFloat("Vertical", -1);
   }

    void Update()
    {
        change = Vector2.zero;
        if(Input.GetButtonDown("Attack") && currentState != playerState.attack) {
            StartCoroutine(AttackCo());
        } else if (currentState == playerState.walk) {
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
        } 
        UpdateCharacter();
    }

    void UpdateCharacter() {
        if (change != Vector2.zero) {
            MoveCharacter();
            a.SetFloat("Horizontal", change.x);
            a.SetFloat("Vertical", change.y);
            a.SetBool("Moving", true);
        } else {
            a.SetBool("Moving", false); 
        }
    }

    private IEnumerator AttackCo(){
        a.SetBool("Attacking", true);
        currentState = playerState.attack;
        yield return null;
        a.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = playerState.walk;
    }

    void MoveCharacter()
    {
        rb.MovePosition(rb.position + change.normalized * moveSpeed * Time.deltaTime);
    }
}
