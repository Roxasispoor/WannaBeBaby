using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSuitCase : InstantiatorSkill {

    private Vector2 direction;
    private Vector2 flySpeed;

    public override void Use(Character character)
    {
        Instantiate(prefabToInstanciate, character.transform.position, Quaternion.identity);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
