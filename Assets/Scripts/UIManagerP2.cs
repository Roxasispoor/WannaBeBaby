using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManagerP2 : MonoBehaviour
{

    public Slider slider;
    public TMPro.TextMeshProUGUI textP;
    public Character character;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = character.Age;
        textP.text = character.Age.ToString();
    }
}
