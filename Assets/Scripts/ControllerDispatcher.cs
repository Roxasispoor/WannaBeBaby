using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDispatcher: MonoBehaviour {

    [SerializeField] 
    private int numberControllerSupported = 7;
    private List<int> assignedController;
    private PlayerInput[] playerInputs;

    public int ControllerSupported
    {
        get
        {
            return numberControllerSupported;
        }
    }

    // Use this for initialization
    void Start() {
        playerInputs = FindObjectsOfType<PlayerInput>();
        PlayerInput[] temp = new PlayerInput[playerInputs.Length];
        for (int i=0; i < temp.Length; i++)
        {
            Player player = playerInputs[i].GetComponent<Player>();
            temp[player.ID - 1] = playerInputs[i];
        }
        playerInputs = temp;
        assignedController = new List<int>();
        Debug.Log("Player found: " + playerInputs.Length);
        Debug.Assert(numberControllerSupported > 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i=1; i < numberControllerSupported; i++)
        {
            if (Input.GetButtonDown("J" + i + "ButtonA") && !assignedController.Contains(i))
            {
                for (int j = 0; j < playerInputs.Length; j++)
                {
                    if (!playerInputs[j].ControllerConnected)
                    {
                        playerInputs[j].SetJoystickNumber(i);
                        Debug.Log("controller " + i + "set to " + playerInputs[j].gameObject.name);
                        assignedController.Add(i);
                        GameManager.Instance.players.Add(playerInputs[j].GetComponent<Player>());
                        DontDestroyOnLoad(playerInputs[j].gameObject);
                        break;
                    }
                }
            }
        }
    }
}


/*
        float dummy = Input.GetAxis("J1LeftHorizontal");
        Debug.Log("J1LeftHorizontal" + dummy);
        Debug.Log("J1RightHorizontal :" + Input.GetAxis("J1RightHorizontal"));
        Debug.Log("J1LeftVertical :" + Input.GetAxis("J1LeftVertical"));
        Debug.Log("J1RightVertical :" + Input.GetAxis("J1RightVertical"));
        Debug.Log("J1RTriggers :" + Input.GetAxis("J1Triggers"));
        Debug.Log("test :" + Input.GetButton("test"));
        Debug.Log("t2est :" + Input.GetButton("t2est"));
        Debug.Log("t3est :" + Input.GetButton("t3est"));
        Debug.Log("t4est :" + Input.GetButton("t4est"));
        Debug.Log("t5est :" + Input.GetButton("t5est"));
        Debug.Log("t6est :" + Input.GetButton("t6est"));
        Debug.Log("t7est :" + Input.GetButton("t7est"));*/
/*
string info = "";

for (int i = 1; i < 17; i++)
{
    info += i + ": " + Input.GetButton("t" + i + "est") + "-";
}

Debug.Log(info);

Debug.Log(Input.GetJoystickNames().Length);

foreach (string name in Input.GetJoystickNames())
{
    Debug.Log(name);
}*/
