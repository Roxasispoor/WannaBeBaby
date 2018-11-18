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
        if(Time.fixedTime-lastTimeShoot<firerate)
        {
            GameObject newObj=  Instantiate(prefabBullet, transform.position, Quaternion.identity);
            newObj.GetComponent<Rigidbody2D>().velocity= character.transform.forward * maxSpeed;
            lastTimeShoot = Time.fixedTime;
            newObj.GetComponent<Attack>().character = gameObject.GetComponent<Character>();
          
        }


    }
}
