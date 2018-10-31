using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance = null;
    private int level = 1;
    private int maxLevel = 2;

    private Dictionary<int, int> playerScores = new Dictionary<int, int>(); 

    private GameObject[] players;
    private Boolean isGameOver = false;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if (Input.GetMouseButtonDown(1)) {    // FIXME FOR DEBUG ONLY
            players = new GameObject[0];
            print("Finished Level in Debug mode");
        }
         
        if (!isGameOver && players.Length <= 0) {
            if (level >= maxLevel) {
                isGameOver = true;
                Destroy(gameObject);
                SceneManager.LoadScene("Menu");
            }
            else {
                GotoNextLevel();
            }
            
        }
        
    }
    
    public void GotoNextLevel() {
        level++;
        SceneManager.LoadScene("level" + level);
    }

    public void incrementCurrentScore(int player) {
        if (!playerScores.ContainsKey(player)) {
            playerScores.Add(player, 0);    
        }

        playerScores[player]++;
        print("Score:"+playerScores[player]);
        
        var scores = GameObject.FindGameObjectsWithTag("Score");

        foreach (var score in scores) {
            int playerScore = 0;
            if (score.name.Equals(player.ToString()) && playerScores.TryGetValue(player, out playerScore)) {
                score.GetComponent<TextMesh>().text = playerScore.ToString();
            }
        }
    }
    
}