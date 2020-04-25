using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void GotoLevel1() {
		SceneManager.LoadScene("level1");
	}

    public void GotoLevelEditor()
    {
        SceneManager.LoadScene("level_editor");
    }

    public void GotoCustomLevels()
    {
        SceneManager.LoadScene("level_custom");
    }
}
