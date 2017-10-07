using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchTestScript : MonoBehaviour {

	private Vector2 pos;
	private Vector2 lastPos;
	private float moveSide;
	public float shipVelocity = 0.5f;

	// Update is called once per frame
	/* void FixedUpdate () {

		Rigidbody2D lRigid = GetComponent<Rigidbody2D>();

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		lRigid.velocity = movement;
		
	}

	*/

	void Update()
	{
		if (Input.touchCount > 0)
		{
			
			Touch touch = Input.GetTouch(0);

			if (TouchPhase.Began == touch.phase) {
				pos = Vector2.zero;
				pos = touch.position;
			}

			else if(touch.phase == TouchPhase.Moved) {
				lastPos = Vector2.zero;
				lastPos = touch.position;

				moveSide = lastPos.y - pos.y;

				if (moveSide > 0) {
					if (transform.position.y == -3.0f) {
						transform.DOMoveY (0.0f, shipVelocity);
					} else if (transform.position.y == 0.0f) {
						transform.DOMoveY (3.0f, shipVelocity);
					}
				}
				else {
					if (transform.position.y == 3.0f) {
						transform.DOMoveY (0.0f, shipVelocity);
					} else if (transform.position.y == 0.0f) {
						transform.DOMoveY (-3.0f, shipVelocity);
					}
				}

			}
		}
	}
}
