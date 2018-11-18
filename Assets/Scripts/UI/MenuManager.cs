using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel11;
    public GameObject Panel22;
    public GameObject Panel33;
    public GameObject Panel44;
    public Button enabledSound;
    public Button disabledSound;
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
        Panel11.gameObject.SetActive(true);
        Panel22.gameObject.SetActive(true);
        Panel33.gameObject.SetActive(true);
        Panel44.gameObject.SetActive(true);
    }
    private void FlipSound()
    {
        AudioListener.pause = !AudioListener.pause;
        enabledSound.enabled = !enabledSound.enabled;
        disabledSound.enabled = !disabledSound.enabled;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(player1.ControllerConnected)
        {
            Panel11.gameObject.SetActive(false);
            Panel1.gameObject.SetActive(true);
        }

        if (player2.ControllerConnected)
        {
            Panel22.gameObject.SetActive(false);
            Panel2.gameObject.SetActive(true);
        }

        if (player3.ControllerConnected)
        {
            Panel33.gameObject.SetActive(false);
            Panel3.gameObject.SetActive(true);
        }

        if (player4.ControllerConnected)
        {
            Panel44.gameObject.SetActive(false);
            Panel4.gameObject.SetActive(true);
        }
        
    }
}
