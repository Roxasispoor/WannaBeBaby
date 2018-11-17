using System.Collections;
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
        SceneManager.sceneLoaded += InitializeMainScene;
    }

    public void InitializeMainScene(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name.Contains("MainScene"))
        {
            Canva = GameObject.Find("UI").GetComponent<Canvas>();
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            GameObject[] UIBatchs = GameObject.FindGameObjectsWithTag("UIBtach");
            for (int i = 0; i< players.Count; i++)
            {
                Character character = Instantiate(characterPrefab, new Vector3(-7.5f + i * 3, -1.2f), Quaternion.identity).GetComponent<Character>();
                character.player = players[i];
                UIBatchs[i].gameObject.SetActive(true);
                UIBatchs[i].GetComponent<UIManager>().character = character;
            }
        }
    }
}
