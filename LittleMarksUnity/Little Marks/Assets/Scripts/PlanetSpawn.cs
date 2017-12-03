using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Quaternion meaning

public class PlanetSpawn : MonoBehaviour {

	public GameObject planetPrefab;
	public GameObject planet2Prefab;
	public float planetSpawnRate = 10f;
	public float planetLocationY = 2f;
	public float planetLocationX = 10f;

	private GameObject planet;
	private GameObject planet2;
	private float timeSinceLastPlanet;

	// Use this for initialization
	void Start () {
		Vector2 planetPosition = new Vector2(planetLocationX, planetLocationY);
		Vector2 planetPosition2 = new Vector2(-25f, -15f);
		planet = (GameObject)Instantiate (planetPrefab, planetPosition, Quaternion.identity); 
		planet2 = (GameObject)Instantiate (planet2Prefab, planetPosition2, Quaternion.identity);  
	}
	
	// Update is called once per frame
	void Update () {
		int spawnControl;
		spawnControl = Random.Range (0, 2);

		timeSinceLastPlanet += Time.deltaTime;

		if (timeSinceLastPlanet >= planetSpawnRate) {
			timeSinceLastPlanet = 0;
			if (spawnControl == 0)
				planet.transform.position = new Vector2 (planetLocationX, planetLocationY);
			else if (spawnControl == 1)
				planet2.transform.position = new Vector2 (planetLocationX, planetLocationY);
			
		}
	}
}
