using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;
using System;

public class scoreControl : MonoBehaviour {

	private int bestScore;
	public Text score_text;

	// Use this for initialization
	void Awake() {
		try {
			string jsonScore = File.ReadAllText (Application.persistentDataPath + "/Score.json");

			JsonData scoreData = JsonMapper.ToObject (jsonScore);

			bestScore = int.Parse (scoreData [4].ToString ());

			score_text.text = "Recorde = " + bestScore;
		} catch(Exception){
			Score object_score = new Score (0, 0, 0, 0, 0);

			JsonData scr;
			scr = JsonMapper.ToJson(object_score);
			File.WriteAllText (Application.persistentDataPath + "/Score.json", scr.ToString());

			score_text.text = "Recorde = " + 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
