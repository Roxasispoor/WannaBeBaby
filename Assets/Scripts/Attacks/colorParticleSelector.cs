using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorParticleSelector : MonoBehaviour {

    [SerializeField]
    Attack attack;

    [SerializeField]
    GameObject system1;
    [SerializeField]
    GameObject system2;
    [SerializeField]
    GameObject system3;
    [SerializeField]
    GameObject system4;
    // Use this for initialization
    void Start () {

        switch (attack.character.player.ID)
        {
            case 1:
                system1.SetActive(true);
                break;
            case 2:
                system2.SetActive(true);
                break;
            case 3:
                system3.SetActive(true);
                break;
            case 4:
                system4.SetActive(true);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
