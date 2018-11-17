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

    public void Use(Character character)
    {
        GameObject attack = Instantiate(prefabToInstanciate, new Vector3(character.transform.position.x + spawnRange * character.AimDirection.x,
            character.transform.position.y + spawnRange * character.AimDirection.y), Quaternion.identity,character.transform);
        attack.GetComponent<Attack>().direction = character.AimDirection;
        attack.GetComponent<Attack>().character = gameObject.GetComponent<Character>();
        GetComponent<Animator>().SetBool(triggerName, true);
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        if (GetComponent<AudioSource>()!=null && skillSound!=null)
        { 
        GetComponent<AudioSource>().PlayOneShot(skillSound);
        }
        StartCoroutine(WaitAndStopAnimation());
    }
    private IEnumerator WaitAndStopAnimation()
    {
        yield return new WaitForSeconds(timeAnimation);
        GetComponent<Animator>().SetBool(triggerName, false);
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
