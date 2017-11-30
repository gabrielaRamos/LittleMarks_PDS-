using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public GameObject priceWinText;
	public GameObject priceReclaimText;
	public bool gameOver = false;
	public Text scoreText;
	public int score = 0;

	public int colaCount = 0;
	public int friesCount = 0;
	public int burguerCount = 0;
	public int pizzaCount = 0;

	private float currentTime;
	private bool priceWon = false;

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

		if (score == 100 && gameOver == false) {
			currentTime = Time.time;
			priceWinText.SetActive (true);
			priceWon = true;
		}
		if ((Time.time - currentTime >= 3.0f) || gameOver == true) {
			priceWinText.SetActive (false);
		}
	}

	public void ShipScored(){
		if (gameOver)
			return;
		score = (int)(Time.timeSinceLevelLoad * 5);
		scoreText.text = "Pontuação = " + score;
	}

	public void ShipExplodes(){
		
		gameOverText.SetActive (true);
		if (priceWon)
			priceReclaimText.SetActive (true);
		
		gameOver = true;	

	}

	public void priceWin(){
		priceWinText.SetActive (true);
	}


	void OnApplicationQuit(){

	}
}
