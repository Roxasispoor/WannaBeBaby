using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack: MonoBehaviour {
    public int damage;
    protected Collider2D collisionBox;
    protected Sprite sprite;
    [SerializeField]
    protected float surviveTime;
    [SerializeField]
    protected float startTime;
    public Character character;
    public Vector2 direction;
    public AudioClip hittingSound;
    private void Start()
    {
        Init();
    }
    // Use this for initialization
    public void Init()
    {
        startTime = Time.fixedTime;
    }
	
	public void TimeToLive()
    {
        if (Time.fixedTime - startTime > surviveTime)
        {
            Destroy(gameObject);
        }
    }

	}

