using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : Attack
{
    public float stunTime;
    
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

            collision.GetComponent<Character>().isLocked = true;
            collision.GetComponent<Character>().timeEndLock = Time.fixedTime+stunTime;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
          
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
