using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private Player player;
    [SerializeField]
    private int age;
    private Form currentForm;
    private List<Form> forms;         // 0-> baby  1->Teen  2->Adult  3->Old  4->Lich
    private Vector2 aimDirection;
    [SerializeField]


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


    // Update is called once per frame
    void LateUpdate () {
	    /*
         * Assign AimDirection
         * Check use of skill from inputs
         * move based on joystick and speedMove
         * check colisions (triggers)
         *
         */

	}

    public void TakeDamage(int damage)
    {
        age += damage;
    }

    public void changeForm(int id)
    {
        currentForm.HurtBox.gameObject.SetActive(false);

        //launch animator for change of sprite
        CurrentForm = Forms[id];
        currentForm.HurtBox.gameObject.SetActive(true);
    }
}
