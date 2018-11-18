using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : Attack {
    private void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == character.tag)
        {
            Destroy(gameObject);
        }
        else
        {
            if (collision.GetComponent<AudioSource>() != null && hittingSound != null)
            {
                collision.GetComponent<AudioSource>().PlayOneShot(hittingSound);
            }
            if (collision.gameObject.GetComponent<Character>())
            {
                collision.gameObject.GetComponent<Character>().TakeDamage(damage);
                if(!collision.gameObject.GetComponent<Character>().isInvincible)
                {
                    character.TakeDamage(-damage);
                }
             
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        TimeToLive();
    }
}
