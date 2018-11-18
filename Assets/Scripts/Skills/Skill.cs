using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    public float cooldown;
    public float lastTimedUsed;
    public string triggerName;
    public GameObject prefabToInstanciate;
    public float spawnRange;
    public float timeAnimation;
    public AudioClip skillSound;
    public bool attackLocksCaster;
    public void Use(Character character)
    {
        GameObject attack = Instantiate(prefabToInstanciate, new Vector3(character.transform.position.x + spawnRange * character.AimDirection.x,
            character.transform.position.y + spawnRange * character.AimDirection.y), Quaternion.identity,character.transform);
        attack.GetComponent<Attack>().direction = character.AimDirection;
        attack.GetComponent<Attack>().character = gameObject.GetComponent<Character>();
        GetComponent<Animator>().SetBool(triggerName, true);
       
        if (GetComponent<AudioSource>()!=null && skillSound!=null)
        { 
        GetComponent<AudioSource>().PlayOneShot(skillSound);
        }
        if (attackLocksCaster)
        {
            character.isLocked = true;
            character.timeEndLock = Time.fixedTime + timeAnimation;
            character.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        StartCoroutine(WaitAndStopAnimation(character));
    }
    private IEnumerator WaitAndStopAnimation(Character character)
    {
       
        float startTime = Time.fixedTime;
        while(Time.fixedTime-startTime<timeAnimation)
        {
            yield return null;
        }
        GetComponent<Animator>().SetBool(triggerName, false);
     
    }
}
