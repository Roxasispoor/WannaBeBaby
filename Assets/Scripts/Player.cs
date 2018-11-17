using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int ID = -1;
    public PlayerInput input;
    public Color color;

	// Use this for initialization
	void Start () {
        Debug.Assert(input != null);
        Debug.Assert(ID > 0);
        gameObject.name = "player" + ID;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
