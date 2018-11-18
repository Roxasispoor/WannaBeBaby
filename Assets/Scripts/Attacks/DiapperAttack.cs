using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiapperAttack : Attack {
    public float slowTime;
    void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag != character.tag && collision.GetComponent<Character>()!=null)
        {
            if (collision.GetComponent<AudioSource>() != null && hittingSound != null)
            {
                collision.GetComponent<AudioSource>().PlayOneShot(hittingSound);
            }

            collision.GetComponent<Character>().timeEndSlow = Time.fixedTime + slowTime;
            collision.GetComponent<Rigidbody2D>().velocity = collision.GetComponent<Rigidbody2D>().velocity/2;

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
