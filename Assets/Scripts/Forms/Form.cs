﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Form : MonoBehaviour {
    [SerializeField]
    private List<Skill> skills;
    public void UseSkill(int i)
    {
        if(i>0 && i<skills.Count)
        {
            skills[i].Use();
        }
        else
        {
            Debug.Log("Skill to use not in range");
        }
    }
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
