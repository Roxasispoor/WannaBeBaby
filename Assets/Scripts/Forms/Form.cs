using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour {
    public string label;
    [SerializeField]
    private List<Skill> skills;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Collider2D hurtBox;
    public float moveSpeed;
    public void UseSkill(int i,Character character)
    {
        if(i>=0 && i<skills.Count &&  Time.fixedTime - skills[i].lastTimedUsed > skills[i].cooldown)
            
        {
            skills[i].Use(character);
            //animator.SetTrigger(skills[i].triggerName);
            skills[i].lastTimedUsed = Time.fixedTime;
            //lance l'animation sur le personnage

        }
        else
        {
            Debug.Log("Skill to use not in range");
        }
    }
    
    void Awake () {
        this.name = name;
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
    private void Update()
    {
        animator.SetFloat("Speed", moveSpeed);
    }
}
