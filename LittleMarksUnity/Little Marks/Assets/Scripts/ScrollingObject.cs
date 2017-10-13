using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool control = false;

	public float scrollSpeed = -3.5f;
	public float increaseSpeedPerScore = -0.15f;
	public float scoreToIncreaseSpeed = 50;
	public float scoreToStopIncreasingSpeed = 120;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (scrollSpeed, 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameControl.instance.score % scoreToIncreaseSpeed != 0 && GameControl.instance.score < scoreToStopIncreasingSpeed) {
			control = false;
		}

		if ((GameControl.instance.score % scoreToIncreaseSpeed) == 0 
			&& GameControl.instance.score != 0 
			&& GameControl.instance.gameOver == false 
			&& control == false) 
		{
			increaseRb2dVelocity ();
			control = true;
		}

		if (GameControl.instance.score == scoreToStopIncreasingSpeed && control == false) {
			control = true;
		}

	}

	void increaseRb2dVelocity(){
		scrollSpeed -= increaseSpeedPerScore;
		rb2d.velocity = new Vector2 (scrollSpeed, 0);
	}

}
