using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text gameOverText;
	
	private GameObject[] players;
	private Boolean isGameOver = false;
	
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (!isGameOver && GameObject.FindGameObjectsWithTag("Player").Length <= 1) {
			Instantiate(gameOverText);
			isGameOver = true;
			// TODO Game Over
		}
	}
}
