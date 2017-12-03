using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb2d;
	private GameObject obstacle;
	private Rigidbody2D ob2d;
	private bool control = false;

	public float scrollSpeed;
	public float increaseSpeedPerScore;
	public float scoreToIncreaseSpeed;
	public float scoreToStopIncreasingSpeed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		if (this.gameObject.CompareTag ("meteor") || this.gameObject.CompareTag ("background"))
			rb2d.velocity = new Vector2 (scrollSpeed, 0);

		else {
			obstacle = GameObject.FindWithTag ("meteor");
			ob2d = obstacle.GetComponent<Rigidbody2D> ();
			rb2d.velocity = ob2d.velocity;

			scrollSpeed = ob2d.velocity.x;
		}

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
