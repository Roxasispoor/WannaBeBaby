﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : Attack {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != character.tag)
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            character.TakeDamage(-damage);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}