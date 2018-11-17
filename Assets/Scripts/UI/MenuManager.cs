using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public PlayerInput player1;
    public PlayerInput player2;
    public PlayerInput player3;
    public PlayerInput player4;
   

    // Use this for initialization
    void Start () {
        Panel1.gameObject.SetActive(false);
        Panel2.gameObject.SetActive(false);
        Panel3.gameObject.SetActive(false);
        Panel4.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Panel1.gameObject.SetActive(player1.ControllerConnected);
        Panel2.gameObject.SetActive(player2.ControllerConnected);
        Panel3.gameObject.SetActive(player3.ControllerConnected);
        Panel4.gameObject.SetActive(player4.ControllerConnected);
    }
}
