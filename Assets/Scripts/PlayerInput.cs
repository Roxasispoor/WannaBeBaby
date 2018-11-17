using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    [SerializeField]
    private int controllerNumber = -1;

    public float leftHorizontal;
    public float leftVertical;
    public float rightHorizontal;
    public float rightVertical;
    public bool bumpLeft;
    public bool bumpRight;
    public bool TriggerLeft;
    public bool TriggerRight;

    public bool ControllerConnected
    {
        get
        {
            return controllerNumber > 0;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!ControllerConnected)
            return;

        leftHorizontal = Input.GetAxis("J" + controllerNumber + "LeftHorizontal");
        leftVertical = Input.GetAxis("J" + controllerNumber + "LeftVertical");
        rightHorizontal = Input.GetAxis("J" + controllerNumber + "RightHorizontal");
        rightVertical = Input.GetAxis("J" + controllerNumber + "RightVertical");
        bumpLeft = Input.GetButton("J" + controllerNumber + "BumpLeft");
        bumpRight = Input.GetButton("J" + controllerNumber + "BumpRight");
        TriggerRight = false;
        TriggerRight = false;
        if (Input.GetAxis("J" + controllerNumber + "Triggers") < -0.5f)
        {
            TriggerLeft = true;
        } else if (Input.GetAxis("J" + controllerNumber + "Triggers") > 0.5f)
        {
            TriggerRight = true;
        }


    }

    public void SetJoystickNumber(int num)
    {
        controllerNumber = num;
    }
}
