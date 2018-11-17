using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiapperAttack : Attack {
    public float lockTime;
    void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().PlayOneShot(hittingSound);
        }
        if (collision.tag != character.tag)
        {

            StartCoroutine(LockForSeconds(collision.gameObject.GetComponent<Character>()));
        }
    }
    public IEnumerator LockForSeconds(Character character)
    {
        character.isLocked = true;
        yield return new WaitForSeconds(lockTime);
        character.isLocked = false;
    }
    // Update is called once per frame
    void Update()
    {
        TimeToLive();

    }
    
}
