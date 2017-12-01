using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPriceCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("cola") 
			|| other.gameObject.CompareTag ("fries") 
			|| other.gameObject.CompareTag ("burguer")
			|| other.gameObject.CompareTag ("pizza"))
		{

			this.gameObject.SetActive (false);
		}


	}
}
