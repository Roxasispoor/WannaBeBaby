using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public Slider slider;
    public Text Age;
    public Character character;
    // Use this for initialization

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            slider.value = character.Age;
            Age.text = character.Age.ToString();
        }
    }
}
