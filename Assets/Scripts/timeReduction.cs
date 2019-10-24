using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeReduction : MonoBehaviour
{
    public string description;
    public string number;
    public float duration;
    public float timer;
    public float cooldownTime;
    public float slowdownFactor;
    float effectDelaySeconds;
    public float effectDelay;
    bool inCooldown;
    public GameObject enemy;
    public GameObject effect; 
    public GameObject afterImage;
    public GameObject player;

    public timeReduction () {
        description = "Slows down time but maintains speed for its user.";
        duration = 1.0f;
        timer = duration;
        cooldownTime = 2.0f;
        inCooldown = false;
        number = "1";
    }

    void Start()
    {
        effectDelaySeconds = effectDelay;
    }

    void Update()
    {
        if (timer <= .0f) {
            inCooldown = true;
        } else if (inCooldown && timer >= cooldownTime) {
            inCooldown = false;
        }

        if (Input.GetButton("Ability" + number) && timer > .0f && inCooldown == false) {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, .0f, duration);
            Ability();
            effect.SetActive(true);
            if (effectDelaySeconds > .0f) {
                effectDelaySeconds -= Time.deltaTime;
            } else {
                GameObject currentAfterImage = Instantiate(afterImage, transform.position, transform.rotation);
                Sprite currentSprite = player.GetComponent<SpriteRenderer>().sprite;
                currentAfterImage.GetComponent<SpriteRenderer>().sprite = currentSprite;
                effectDelaySeconds = effectDelay;
                Destroy(currentAfterImage, 1f);
            }
        } else if (timer < duration) {
            timer += Time.deltaTime;
            timer = Mathf.Clamp(timer, .0f, duration);
            effect.SetActive(false);
        } 
        
    }

    void Ability () {

    }
}
