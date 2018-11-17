using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack: MonoBehaviour {
    public int damage;
    protected Collider2D collisionBox;
    protected Sprite sprite;
    protected float surviveTime;
    protected float startTime;
    public Character character;
    public Vector2 direction;

	// Use this for initialization
	void Start () {
        startTime = Time.fixedTime;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.fixedTime-startTime>surviveTime)
        {
            Destroy(gameObject);
        }
    }

	}

