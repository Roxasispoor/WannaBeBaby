using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : Attack {

	// Use this for initialization
	void Start () {
        Init();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag != character.tag && collision.gameObject.GetComponent<Character>()!=null)
        {
            if (collision.GetComponent<AudioSource>() != null && hittingSound != null)
            {
                collision.GetComponent<AudioSource>().PlayOneShot(hittingSound);
            }
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            if (!collision.gameObject.GetComponent<Character>().isInvincible)
            {
                character.TakeDamage(-damage);
            }
        }
    }
    // Update is called once per frame
    void Update () {
        TimeToLive();
		
	}
    
}
