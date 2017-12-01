using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;

public class menu_controller : MonoBehaviour {

	public void loadScene(string scene_name) {
	
		SceneManager.LoadScene (scene_name);

	}

	public void loadAndSave(string scene_name) {
		
		Score object_score = new Score (GameControl.instance.colaCount, GameControl.instance.pizzaCount, 
			GameControl.instance.burguerCount, GameControl.instance.friesCount);
		
		JsonData scr;
		scr = JsonMapper.ToJson(object_score);

		File.WriteAllText (Application.persistentDataPath + "/Score.json", scr.ToString());
		SceneManager.LoadScene (scene_name);


	}

	public void loadAndSaveEx(string scene_name) {

		Score object_score = new Score (PrizeUpdater.instance.colaCount, PrizeUpdater.instance.pizzaCount, 
			PrizeUpdater.instance.burguerCount, PrizeUpdater.instance.friesCount);

		JsonData scr;
		scr = JsonMapper.ToJson(object_score);

		File.WriteAllText (Application.persistentDataPath + "/Score.json", scr.ToString());
		SceneManager.LoadScene (scene_name);


	}
}
