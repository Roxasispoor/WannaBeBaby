using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    [SerializeField]
    private int age;
    private Form currentForm;
    private List<Form> forms;         // 0-> baby  1->Teen  2->Adult  3->Old  4->Lich
    private Vector2 aimDirection;
    [SerializeField]
    private float moveSpeed;          //Needs to change when form changes

    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            age = value;
        }
    }

    public Form CurrentForm
    {
        get
        {
            return currentForm;
        }

        set
        {
            currentForm = value;
        }
    }

    public List<Form> Forms
    {
        get
        {
            return forms;
        }

        set
        {
            forms = value;
        }
    }

    public Vector2 AimDirection
    {
        get
        {
            return aimDirection;
        }

        set
        {
            aimDirection = value;
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
    void LateUpdate () {
		
	}

    public void changeForm(int id)
    {
        currentForm.hurtBox.gameObject.SetActive(false);

        //launch animator for change of sprite
        CurrentForm = Forms[id];
        Hurtbox
    }
}
