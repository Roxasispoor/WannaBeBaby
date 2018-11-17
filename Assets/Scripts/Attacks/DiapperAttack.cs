using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiapperAttack : Attack {
    public float slowTime;
    void Start()
    {
        Init();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AudioSource>() != null && hittingSound != null)
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
        character.speed *= 0.5f;
        yield return new WaitForSeconds(slowTime);
        character.speed *= 2;
    }
    // Update is called once per frame
    void Update()
    {
        TimeToLive();

    }
    
}
