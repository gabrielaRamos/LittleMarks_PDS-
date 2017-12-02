using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using LitJson;

public class menu_controller : MonoBehaviour {

	public Button play_button;
	public Button pause_button;

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

	public void pauseGame(){
		Time.timeScale = 0f;

		pause_button.enabled = !pause_button.enabled;
		play_button.enabled = !play_button.enabled;
		pause_button.image.enabled = !pause_button.image.enabled;
		play_button.image.enabled = !play_button.image.enabled;

	}

	public void playGame(){
		
		Time.timeScale = 1f;

		pause_button.enabled = !pause_button.enabled;
		play_button.enabled = !play_button.enabled;
		pause_button.image.enabled = !pause_button.image.enabled;
		play_button.image.enabled = !play_button.image.enabled;

	}
		
}
