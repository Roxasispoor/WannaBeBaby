using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCollectible : Attack {

    public float invincibleTime;

    void Start()
    {
        Init();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AudioSource>() != null && hittingSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(hittingSound);
        }
        if (collision.tag != character.tag && collision.GetComponent<Character>())
        {

            collision.GetComponent<Character>().isInvincible = true;
            collision.GetComponent<Character>().StartCoroutine(collision.GetComponent<Character>().StopInvincible(invincibleTime));
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("auto hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeToLive();

    }
}
