using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	public float skyHorizontalLenght = 30f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -skyHorizontalLenght) {
			RepositionBackground ();
		}


	}

	private void RepositionBackground(){
		Vector2 skyOffset = new Vector2 (skyHorizontalLenght * 2f, 0);
		transform.position = (Vector2)transform.position + skyOffset;
	}
}
