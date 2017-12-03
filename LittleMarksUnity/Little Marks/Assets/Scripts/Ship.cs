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
	private int lastMovement = 0; //1 é pra cima, 2 é pra baixo, 0 não teve movimento;
	private Animator anim;

	public float shipVelocity = 0.5f;
	public float botLane = -3.0f;
	public float midLane = 0f;
	public float topLane = 3.0f;


	void Start(){
		transform.DOMoveY (midLane, shipVelocity);

		anim = GetComponent<Animator> ();
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
				} 

				if (touch.phase == TouchPhase.Moved && !controlConstantTouch && !blockMoveTouch) {
					lastPos = Vector2.zero;
					lastPos = touch.position;

					moveSide = lastPos.y - pos.y;

					if (moveSide > 0) {

						anim.SetTrigger ("Rising");

						if (transform.position.y == botLane) {
							transform.DOMoveY (midLane, shipVelocity);
							lastMovement = 1;
						} else if (transform.position.y == midLane) {
							transform.DOMoveY (topLane, shipVelocity);
							lastMovement = 1;
						}  else if (transform.position.y < midLane && lastMovement == 1){
							transform.DOMoveY (topLane, shipVelocity);
							lastMovement = 1;
						}
						else if (transform.position.y < midLane && lastMovement == 2){
							transform.DOMoveY (midLane, shipVelocity);
							lastMovement = 1;
						} 
						else if (transform.position.y < topLane && transform.position.y > midLane && lastMovement == 2){
							transform.DOMoveY (topLane, shipVelocity);
							lastMovement = 1;
						} 


					} else if (moveSide < 0) {
						
						anim.SetTrigger ("Falling");

						if (transform.position.y == topLane) {
							transform.DOMoveY (midLane, shipVelocity);
							lastMovement = 2;

						} else if (transform.position.y == midLane) {
							transform.DOMoveY (botLane, shipVelocity);
							lastMovement = 2;
						}
						else if (transform.position.y < topLane && transform.position.y > midLane && lastMovement == 2){
							transform.DOMoveY (botLane, shipVelocity);
							lastMovement = 2;
						}
						else if (transform.position.y < topLane && transform.position.y > midLane && lastMovement == 1){
							transform.DOMoveY (midLane, shipVelocity);
							lastMovement = 2;
						}
						else if (transform.position.y < midLane && lastMovement == 1){
							transform.DOMoveY (botLane, shipVelocity);
							lastMovement = 2;
						}

					}
					controlConstantTouch = true;
				} 
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.CompareTag ("meteor")) {
			anim.SetTrigger ("Explosion");
			isDead = true;
			Destroy (other.gameObject);

			
			GameControl.instance.ShipExplodes ();

		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("cola")) {
			GameControl.instance.colaCount += 1;
			Destroy (other.gameObject);

		} else if (other.gameObject.CompareTag ("fries")) {
			Destroy (other.gameObject);
			GameControl.instance.friesCount += 1;

		} else if (other.gameObject.CompareTag ("burguer")) {
			Destroy (other.gameObject);
			GameControl.instance.burguerCount += 1;

		} else if (other.gameObject.CompareTag ("pizza")) {
			Destroy (other.gameObject);
			GameControl.instance.pizzaCount += 1;
		}

	}
}
