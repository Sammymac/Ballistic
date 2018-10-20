using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance = null;
    private int level = 1;

    public Text gameOverText;

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
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver && GameObject.FindGameObjectsWithTag("Player").Length <= 0) {
            Instantiate(gameOverText);
            isGameOver = true;
        }
    }
    
    public void GotoLevel1() {
        SceneManager.LoadScene("level1");
    }

    public void GotoLevel2() {
        SceneManager.LoadScene("level2");
    }
}