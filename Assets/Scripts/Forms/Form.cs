using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Form : MonoBehaviour {
    [SerializeField]
    private List<Skill> skills;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D hurtBox;
    private float moveSpeed;
    public void UseSkill(int i,Character character)
    {
        if(i>0 && i<skills.Count)
        {
            skills[i].Use(character);
            animator.SetTrigger(skills[i].triggerName);//lance l'animation sur le personnage

        }
        else
        {
            Debug.Log("Skill to use not in range");
        }
    }
    
    void Start () {
		
	}

    

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

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
