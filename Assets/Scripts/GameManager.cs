﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private static GameManager instance;
    public List<Character> characters;
    public List<Player> players;
    public Canvas Canva;
    public UIManager[] UIBatchs;
    public GameObject characterPrefab;
    public Timer timer;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += InitializeMainScene;
    }

    public void InitializeMainScene(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name.Contains("MainScene"))
        {
            Canva = GameObject.Find("UI").GetComponent<Canvas>();
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            GameObject[] UIBatchs = GameObject.FindGameObjectsWithTag("UIBatch");
            foreach (GameObject gameObject in UIBatchs)
            {
                gameObject.SetActive(false);
            }
            for (int i = 0; i< players.Count; i++)
            {
                Character character = Instantiate(characterPrefab, new Vector3(-2 + i, 0, 0), Quaternion.identity).GetComponent<Character>();
                characters.Add(character);
                character.player = players[i];
                UIBatchs[i].gameObject.SetActive(true);
                UIBatchs[i].GetComponent<UIManager>().character = character;
            }
        }
    }
}
