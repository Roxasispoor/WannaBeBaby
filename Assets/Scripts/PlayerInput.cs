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
	}

    public void SetJoystickNumber(int num)
    {
        controllerNumber = num;
    }
}
