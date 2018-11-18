using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartOfSuitCaseAttack { FirstMove, Return}

public class SuitCaseAttack : Attack {


    public float range;
    public float maxSpeed;
    public PartOfSuitCaseAttack state;
    private Vector3 arrivalPoint;

    private void Awake()
    {
        startTime = Time.time;
        state = PartOfSuitCaseAttack.FirstMove;
    }
    // Use this for initialization
    void Start () {
        arrivalPoint = new Vector3(character.transform.position.x + direction.x * range, character.transform.position.y + direction.y * range);
    }
	
	// Update is called once per frame
	void Update () {
        if (state == PartOfSuitCaseAttack.FirstMove)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(((arrivalPoint - gameObject.transform.position).magnitude /range )* maxSpeed * direction.x + maxSpeed/6 * direction.x,
                ((arrivalPoint - gameObject.transform.position).magnitude / range) * maxSpeed * direction.y + maxSpeed/5  * direction.y);
        }
        if (state == PartOfSuitCaseAttack.Return)
        {
            direction = new Vector2(character.transform.position.x - gameObject.transform.position.x,
                character.transform.position.y - gameObject.transform.position.y).normalized;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * maxSpeed, direction.y * maxSpeed);
                //new Vector2(Mathf.Clamp(1/(character.transform.position - gameObject.transform.position).magnitude, 0, 1) * maxSpeed * direction.x,
               //Mathf.Clamp(1/(arrivalPoint - gameObject.transform.position).magnitude, 0, 1) * maxSpeed * direction.y);
        }

        if ((arrivalPoint - gameObject.transform.position).magnitude < 0.2)
        {
            state = PartOfSuitCaseAttack.Return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerEnter");
        if (collision.tag == character.tag)
        {
            Destroy(gameObject);
        }
        else
        {
            if (collision.GetComponent<AudioSource>() != null && hittingSound != null)
            {
                collision.GetComponent<AudioSource>().PlayOneShot(hittingSound);
            }
            if(collision.gameObject.GetComponent<Character>())
            { 
            
                if (!collision.gameObject.GetComponent<Character>().isInvincible)
                {
                    collision.gameObject.GetComponent<Character>().TakeDamage(damage);
                    character.TakeDamage(-damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
