using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitCaseAttack : Attack {

    private Vector2 direction;
    public int damage;

    private void Awake()
    {
        startTime = Time.time;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == player.tag)
        {
            Destroy(gameObject);
        }
        else
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
