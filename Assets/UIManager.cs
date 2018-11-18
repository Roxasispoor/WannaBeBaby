using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public Slider slider;
    public Text Age;
    public Character character;
    public Image image;
    // Use this for initialization

    void Start()
    {
        if (character != null)
        {
            Player player = character.player;
            image.color = new Color(player.color.r, player.color.g, player.color.b);
        }
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
