using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingAttack : Attack {

    public float range;
    public float maxSpeed;
    public float firerate;
    public float lastTimeShoot;
    public GameObject prefabBullet;
   
    // Use this for initialization
    void Start () {
        Init();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeToLive();
        if (Time.fixedTime-lastTimeShoot>firerate)
        {
            Vector3 rotation = new Vector3(0, 0, 1);
            GameObject newObj=  Instantiate(prefabBullet, this.transform.position, 
                Quaternion.FromToRotation(Vector3.up, new Vector3(character.AimDirection.x, character.AimDirection.y)));
            //GetComponent<Rigidbody2D>().rotation = Mathf.Atan(character.AimDirection.y / character.AimDirection.y);


            newObj.GetComponent<Rigidbody2D>().velocity= character.AimDirection * maxSpeed;
            
            lastTimeShoot = Time.fixedTime;
            newObj.GetComponent<Attack>().character = character;
          
        }


    }
}
