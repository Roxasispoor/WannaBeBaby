using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private static GameManager instance;
    public List<Character> characters;
    public List<Player> players;
    public Canvas Canva;
    public UIManager[] UIBatchs;
    public GameObject characterPrefab;
    public Timer timer;
    private Player winner;
    public Text specialText;

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

    private void Update()
    {
        if (timer.IsFinished)
        {
            Player Save = players[0];
            int saveAge = 90;
            foreach (Character character in characters)
            {
                if (character.Age < saveAge)
                {
                    Save = character.player;
                    saveAge = character.Age;
                }
            }
            winner = Save;
            specialText.text = "Winner : Player" + winner.ID + "\n He is " + saveAge.ToString() + "\n Press Start to Restart";
        }
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
            specialText = GameObject.Find("SpecialText").GetComponent<Text>();
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
                character.gameObject.tag = "Player" + players[i].ID;
                for (int j = 0; j < UIBatchs.Length; j++)
                {
                    if (UIBatchs[j].name.Contains("P" + players[i].ID))
                    {
                        UIBatchs[j].gameObject.SetActive(true);
                        UIBatchs[j].GetComponent<UIManager>().character = character;
                    }
                }
            }
        }
    }
}
