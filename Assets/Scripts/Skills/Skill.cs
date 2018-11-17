using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    public float damage;
    public float cooldown;
    public float lastTimedUsed;
    public string triggerName;
    public GameObject prefabToInstanciate;
    
    public void Use(Character character)
    {
        GameObject attack = Instantiate(prefabToInstanciate, character.transform.position, Quaternion.identity);
        attack.GetComponent<Attack>().direction = character.AimDirection;
        attack.GetComponent<Attack>().character = gameObject.GetComponent<Character>();
    }
}
