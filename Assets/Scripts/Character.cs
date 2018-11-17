using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private Player player;
    [SerializeField]
    private int age;
    public bool isLocked = false;
    private Form currentForm;
    [SerializeField]
    private List<Form> forms;         // 0-> baby  1->Teen  2->Adult  3->Old  4->Lich
    private Vector2 aimDirection;
    [SerializeField]


    // Use this for initialization
    void Start()
    {
        aimDirection = new Vector2(1, 0);
        currentForm = forms[2];

    }

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

    void Update()
    {
        //Debug
        if (Input.GetKeyDown("a"))
        {
            TakeDamage(-5);
            Debug.Log(currentForm.label);
        }
        if (Input.GetKeyDown("z"))
        {
            currentForm.UseSkill(0, this);
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
        CheckAndChangeForm();
    }
    public void CheckAndChangeForm()
    {
        if (age<=10  && (currentForm==null || forms.FindIndex(currentForm.Equals)!=0))
        {
            ChangeForm(0);
        }
        else if (age<= 25 && age>10 && (currentForm == null || forms.FindIndex(currentForm.Equals) != 1))
        {
            ChangeForm(1);
        }
        else if(age<=50 &&  age > 25 &&(currentForm == null || forms.FindIndex(currentForm.Equals) != 2))
        {
            ChangeForm(2);
        }
        else if (age <= 75 && age > 50 && (currentForm == null || forms.FindIndex(currentForm.Equals) != 3))
        {
            ChangeForm(3);
        }
        else if(age > 75 && (currentForm == null || forms.FindIndex(currentForm.Equals) != 4))
        {
            ChangeForm(4);
        }
        
    }

    public void ChangeForm(int id)
    {
        currentForm.HurtBox.gameObject.SetActive(false);

        //launch animator for change of sprite
        CurrentForm = Forms[id];
        GetComponent<Animator>().runtimeAnimatorController = Forms[id].animatorController;
        currentForm.HurtBox.gameObject.SetActive(true);
    }
}
