using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public Text scoreText;

	private int score = 0;

	// Use this for initialization
	void Awake () {
		
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
		


		if (gameOver && Input.touchCount > 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		ShipScored();
	}

	public void ShipScored(){
		if (gameOver)
			return;
		score = (int)(Time.timeSinceLevelLoad * 5);
		scoreText.text = "Score = " + score;
	}

	public void ShipExplodes(){
		
		gameOverText.SetActive (true);
		gameOver = true;	
	}
}
