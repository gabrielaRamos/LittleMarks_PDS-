using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public Text scoreText;
	public int score = 0;

	public int colaCount;
	public int friesCount;
	public int burguerCount;
	public int pizzaCount;


	// Use this for initialization
	void Awake () {
		string jsonScore = File.ReadAllText (Application.persistentDataPath + "/Score.json");
		JsonData scoreData = JsonMapper.ToObject (jsonScore);

		colaCount = int.Parse(scoreData[0].ToString());
		pizzaCount = int.Parse(scoreData [1].ToString());
		burguerCount = int.Parse(scoreData [2].ToString());
		friesCount = int.Parse(scoreData [3].ToString());

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		Time.timeScale = 1f; //Resume o jogo caso ele tenha sido pausado e ido para o menu, sempre que a cena carrega, ela está com o time definido.
	}

	// Update is called once per frame
	void Update () {
		
		if (gameOver && Input.touchCount > 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

			Score object_score = new Score (colaCount, pizzaCount, burguerCount, friesCount);

			JsonData scr;
			scr = JsonMapper.ToJson(object_score);
			File.WriteAllText (Application.persistentDataPath + "/Score.json", scr.ToString());
		}

		ShipScored();
	}

	public void ShipScored(){
		if (gameOver)
			return;
		score = (int)(Time.timeSinceLevelLoad * 5);
		scoreText.text = "Pontuação = " + score;
	}

	public void ShipExplodes(){
		
		gameOverText.SetActive (true);
		
		gameOver = true;	

	}


	void OnApplicationQuit(){
		Score object_score = new Score (colaCount, pizzaCount, burguerCount, friesCount);

		JsonData scr;
		scr = JsonMapper.ToJson(object_score);
		File.WriteAllText (Application.persistentDataPath + "/Score.json", scr.ToString());

	}
}

public class Score {
	public int cola;
	public int pizza;
	public int burguer;
	public int fries;

	public Score(int cola, int pizza, int burguer, int fries) {
		this.cola = cola;
		this.pizza = pizza;
		this.fries = fries;
		this.burguer = burguer;
	}
}
