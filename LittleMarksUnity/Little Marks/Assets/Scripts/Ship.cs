using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ship : MonoBehaviour {

	private Vector2 pos;
	private Vector2 lastPos;
	private float moveSide;
	private bool isDead = false;
	private bool controlConstantTouch = false;
	private Rigidbody2D rb2d;
	private bool blockMoveTouch = true;

	public float shipVelocity = 0.5f;
	public float botLane = -3.0f;
	public float midLane = 0f;
	public float topLane = 3.0f;

	void Start(){
		transform.DOMoveY (midLane, shipVelocity);
	}

	// Update is called once per frame

	void Update()
	{
		if (isDead == false) {
			if (Input.touchCount > 0)
			{

				Touch touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Began) {
					pos = Vector2.zero;
					pos = touch.position;
					controlConstantTouch = false;
					blockMoveTouch = false;
				} else if (touch.phase == TouchPhase.Moved && !controlConstantTouch && !blockMoveTouch) {
					lastPos = Vector2.zero;
					lastPos = touch.position;

					moveSide = lastPos.y - pos.y;

					if (moveSide > 0) {
						if (transform.position.y == botLane) {
							transform.DOMoveY (midLane, shipVelocity);
						} else if (transform.position.y == midLane) {
							transform.DOMoveY (topLane, shipVelocity);
						}
					} else if (moveSide < 0) {
						if (transform.position.y == topLane) {
							transform.DOMoveY (midLane, shipVelocity);
						} else if (transform.position.y == midLane) {
							transform.DOMoveY (botLane, shipVelocity);
						}
					}

					controlConstantTouch = true;
				} 
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.CompareTag ("meteor")) {
			isDead = true;
			GameControl.instance.ShipExplodes ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("cola")) {
			GameControl.instance.colaCount += 1;
			other.gameObject.SetActive (false);

		} else if (other.gameObject.CompareTag ("fries")) {
			other.gameObject.SetActive (false);
			GameControl.instance.friesCount += 1;

		} else if (other.gameObject.CompareTag ("burguer")) {
			other.gameObject.SetActive (false);
			GameControl.instance.burguerCount += 1;

		} else if (other.gameObject.CompareTag ("pizza")) {
			other.gameObject.SetActive (false);
			GameControl.instance.pizzaCount += 1;
		}

	}
}
