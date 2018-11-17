using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour {

    public float damage;
    public float cooldown;
    public float lastTimedUsed;
    public string triggerName;

    public abstract void Use(Character character);
	// Use this for initialization

}
