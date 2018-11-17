using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Form : MonoBehaviour {
    [SerializeField]
    private List<Skill> skills;
    public void UseSkill(int i,Character character)
    {
        if(i>0 && i<skills.Count)
        {
            skills[i].Use(character);
        }
        else
        {
            Debug.Log("Skill to use not in range");
        }
    }
    
    void Start () {
		
	}

    private Collider2D hurtBox;

    public Collider2D HurtBox
    {
        get
        {
            return hurtBox;
        }

        set
        {
            hurtBox = value;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
