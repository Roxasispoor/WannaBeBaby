using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartOfSuitCaseAttack { FirstMove, Return}

public class SuitCaseAttack : Attack {

    private Vector2 direction;
    public int damage;
    public float range;
    public float maxSpeed;
    public PartOfSuitCaseAttack state;
    private Vector3 arrivalPoint;

    private void Awake()
    {
        startTime = Time.time;
        arrivalPoint = new Vector3(gameObject.transform.position.x + direction.x * range, gameObject.transform.position.y + direction.y * range);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (state == PartOfSuitCaseAttack.FirstMove)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(((arrivalPoint - gameObject.transform.position).magnitude /range )* maxSpeed * direction.x,
                ((arrivalPoint - gameObject.transform.position).magnitude / range) * maxSpeed * direction.y);
        }
        if (state == PartOfSuitCaseAttack.Return)
        {
            direction = new Vector2(character.transform.position.x - gameObject.transform.position.x,
                character.transform.position.y - gameObject.transform.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp((arrivalPoint - gameObject.transform.position).magnitude, 0, 1) * maxSpeed * direction.x,
                Mathf.Clamp((arrivalPoint - gameObject.transform.position).magnitude, 0, 1) * maxSpeed * direction.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == character.tag)
        {
            Destroy(gameObject);
        }
        else
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            character.TakeDamage(-damage);
            Destroy(gameObject);
        }
    }
}
