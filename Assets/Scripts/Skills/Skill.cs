using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    public float cooldown;
    public float lastTimedUsed;
    public string triggerName;
    public GameObject prefabToInstanciate;
    public float spawnRange;
    
    public void Use(Character character)
    {
        GameObject attack = Instantiate(prefabToInstanciate, new Vector3(character.transform.position.x + spawnRange * character.AimDirection.x,
            character.transform.position.y + spawnRange * character.AimDirection.y), Quaternion.identity);
        attack.GetComponent<Attack>().direction = character.AimDirection;
        attack.GetComponent<Attack>().character = gameObject.GetComponent<Character>();
    }
}
