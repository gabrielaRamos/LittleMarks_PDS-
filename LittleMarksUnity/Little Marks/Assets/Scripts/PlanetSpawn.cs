using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Quaternion meaning

public class PlanetSpawn : MonoBehaviour {

	public GameObject planetPrefab;
	public float planetSpawnRate = 10f;
	public float planetLocationY = 2f;
	public float planetLocationX = 10f;

	private GameObject planet;
	private float timeSinceLastPlanet;

	// Use this for initialization
	void Start () {
		Vector2 planetPosition = new Vector2(planetLocationX, planetLocationY);
		planet = (GameObject)Instantiate (planetPrefab, planetPosition, Quaternion.identity); 
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastPlanet += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastPlanet >= planetSpawnRate) {
			timeSinceLastPlanet = 0;

			planet.transform.position = new Vector2 (planetLocationX, planetLocationY);
		}
	}
}
