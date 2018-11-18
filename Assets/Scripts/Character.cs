using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Player player;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int age;
    public bool isLocked = false;
    private Form currentForm;
    [SerializeField]
    private List<Form> forms;         // 0-> baby  1->Teen  2->Adult  3->Old  4->Lich
    [SerializeField]
    private Vector2 aimDirection;
    public float timeEndLock;
    public float timeEndSlow;
    public float speed = 10;
    public bool isInvincible = false;
    public float blinkingTime = 0.5f;
    public GameObject EffectToMorph;
    public float morphingTime = 0.5f;
    // Use this for initialization
    void Start()
    {
        aimDirection = new Vector2(1, 0);
        target.transform.localPosition = aimDirection / 1.5f;
        target.GetComponent<SpriteRenderer>().material.color = new Color(player.color.r, player.color.g, player.color.b);
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
        if (Time.fixedTime > timeEndLock)
        {
            isLocked = false;
        }
        if (!isLocked)
        {
            Movement();
            UpdateAim();

            if (player.input.bumpRight)
            {
                currentForm.UseSkill(0, this);
            }
            if (player.input.bumpLeft)
            {
                currentForm.UseSkill(1, this);
            }

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
    }
    // Update is called once per frame
    void LateUpdate() {

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
        if (!isInvincible)
        {
            
            age += damage;
            CheckAndChangeForm();
            if(damage>0)
            {
                GetComponent<SpriteRenderer>().color = Color.red;

                StartCoroutine(ReturnToWhite());

            }
        }
    }
    public IEnumerator ReturnToWhite()
        {
        yield return new WaitForSeconds(blinkingTime);
        GetComponent<SpriteRenderer>().color = Color.white;
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
        GameObject newItem=Instantiate(EffectToMorph, transform);
        GetComponent<Animator>().runtimeAnimatorController = Forms[id].animatorController;
        currentForm.HurtBox.gameObject.SetActive(true);
        isLocked = true;
        timeEndLock = Time.fixedTime + morphingTime;
        isInvincible = true;
        StartCoroutine(DeleteMorphing(newItem));
    }
    public IEnumerator DeleteMorphing(GameObject newitem)
    {
        yield return new WaitForSeconds(morphingTime);
        Destroy(newitem);
        
        isInvincible = false;
    }

    public void Movement()
    {
        Vector2 oldMovement = GetComponent<Rigidbody2D>().velocity;
        Vector2 movement = new Vector2(player.input.leftHorizontal, player.input.leftVertical);
        if(timeEndSlow>Time.fixedTime)
        {
            GetComponent<Rigidbody2D>().velocity = movement.normalized * currentForm.moveSpeed/2;

        }
        else
        { 
        GetComponent<Rigidbody2D>().velocity = movement.normalized * currentForm.moveSpeed;
        }
        if (movement.x<0)//signs differents change sprite
        {
            GetComponent<SpriteRenderer>().flipX=true;
        }
        else if(movement.x > 0)//signs differents change sprite
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);
    }
    public void Unlock()
    {
        isLocked = false;
    }

    public void UpdateAim()
    {
        Vector2 aim = new Vector2(player.input.rightHorizontal, player.input.rightVertical);
        if (aim.magnitude < 0.5)
            return;
        aimDirection = aim.normalized;
        target.transform.localPosition = aimDirection/1.5f;
    }
}
