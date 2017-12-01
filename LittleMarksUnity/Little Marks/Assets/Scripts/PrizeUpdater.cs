using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;


public class PrizeUpdater : MonoBehaviour {

	public static PrizeUpdater instance;
	public Text scoreColaText;
	public Text scoreFriesText;
	public Text scoreBurguerText;
	public Text scorePizzaText;

	public int colaCount;
	public int friesCount;
	public int burguerCount;
	public int pizzaCount;

	private string jsonScore;
	private JsonData scoreData;


	// Use this for initialization
	void Start () {

		jsonScore = File.ReadAllText (Application.persistentDataPath + "/Score.json");
		scoreData = JsonMapper.ToObject (jsonScore);

		colaCount = int.Parse(scoreData[0].ToString());
		pizzaCount = int.Parse(scoreData [1].ToString());
		burguerCount = int.Parse(scoreData [2].ToString());
		friesCount = int.Parse(scoreData [3].ToString());

		scoreColaText.text = "= " + scoreData[0];
		scorePizzaText.text = "= " + scoreData[1];
		scoreBurguerText.text = "= " + scoreData[2];
		scoreFriesText.text = "= " + scoreData[3];

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void setText() {
		scoreColaText.text = "= " + colaCount;
		scoreFriesText.text = "= " + friesCount;
		scoreBurguerText.text = "= " + burguerCount;
		scorePizzaText.text = "= " + pizzaCount;
	}

}
