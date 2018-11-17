using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private static GameManager instance;
    public List<Character> characters;
    public List<Player> players;

    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(this);


    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += InitialyzeMainScene;
    }

    public void InitialyzeMainScene(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name.Contains("MainScene"))
        { 
            
        }
    }
}
