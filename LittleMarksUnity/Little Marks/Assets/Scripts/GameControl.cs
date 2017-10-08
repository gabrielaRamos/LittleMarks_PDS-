using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public bool gameOver = false;

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

		/* IF game over e teve toque na tela
		 * SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        */
	}

	public void ShipExplodes(){
		
		gameOverText.SetActive (true);
		gameOver = true;	
	}
}
