using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrizeUpdater : MonoBehaviour {

	public Text scoreColaText;
	public Text scoreFriesText;
	public Text scoreBurguerText;
	public Text scorePizzaText;

	// Use this for initialization
	void Start () {
		scoreColaText.text = "= " + GameControl.instance.colaCount;
		scoreFriesText.text = "= " + GameControl.instance.friesCount;
		scoreBurguerText.text = "= " + GameControl.instance.burguerCount;
		scorePizzaText.text = "= " + GameControl.instance.pizzaCount;
	}
	
	// Update is called once per frame
	void Update () {
		scoreColaText.text = "= " + GameControl.instance.colaCount;
		scoreFriesText.text = "= " + GameControl.instance.friesCount;
		scoreBurguerText.text = "= " + GameControl.instance.burguerCount;
		scorePizzaText.text = "= " + GameControl.instance.pizzaCount;
	}
}
