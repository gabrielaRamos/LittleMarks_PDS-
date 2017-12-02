using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	public GameObject meteorPrefab;
	public GameObject satelitePrefab;
	public float meteorSpawnRate = 10f;
	public int meteorPoolSize = 5;
	public float meteorSpawnX = 12f;
	public float botLane = -3.0f;
	public float midLane = 0f;
	public float topLane = 3.0f;


	private GameObject[] meteors;
	private GameObject[] satelites;
	private float timeSinceLastMeteor;
	private Vector2 initialMeteor = new Vector2 (-15f, -25f);
	private int currentObstacle = 0;

	// Use this for initialization
	void Start () {
		meteors = new GameObject[meteorPoolSize];
		for (int i = 0; i < meteorPoolSize; i++) {
			meteors[i] = (GameObject)Instantiate (meteorPrefab, initialMeteor, Quaternion.identity); 
		}

		satelites = new GameObject[meteorPoolSize];
		for (int i = 0; i < meteorPoolSize; i++) {
			satelites[i] = (GameObject)Instantiate (satelitePrefab, initialMeteor, Quaternion.identity); 
		}

	}

	// Update is called once per frame
	void Update () {
		int spawnControl;
		int obstacleControl;
		timeSinceLastMeteor += Time.deltaTime;

		if (GameControl.instance.score > 150) {
			spawnControl = Random.Range (0, 6);
		}
		else{
			spawnControl = Random.Range (0, 3);
		}

		obstacleControl = Random.Range (0, 2);
		//obstacleControl = 1;

		if (GameControl.instance.gameOver == false && timeSinceLastMeteor >= meteorSpawnRate && obstacleControl == 0) {
			
			timeSinceLastMeteor = 0f;
			//meteors [currentObstacle].SetActive(true);
			if (spawnControl == 0)
				meteors [currentObstacle].transform.position = new Vector2 (meteorSpawnX, botLane);
			else if (spawnControl == 1)
				meteors [currentObstacle].transform.position = new Vector2 (meteorSpawnX, midLane);
			else if (spawnControl == 2)
				meteors [currentObstacle].transform.position = new Vector2 (meteorSpawnX, topLane);
			else if (spawnControl == 3) {
				if ((currentObstacle + 1) < meteorPoolSize) {
					meteors [currentObstacle].transform.position = new Vector2 (meteorSpawnX, botLane);
					meteors [currentObstacle + 1].transform.position = new Vector2 (meteorSpawnX, topLane);
				}
			}
			else if (spawnControl == 4) {
				if ((currentObstacle + 1) < meteorPoolSize) {
					meteors [currentObstacle].transform.position = new Vector2 (meteorSpawnX, midLane);
					meteors [currentObstacle + 1].transform.position = new Vector2 (meteorSpawnX, topLane);
				}
			}
			else if (spawnControl == 5) {
				if ((currentObstacle + 1) < meteorPoolSize) {
					meteors [currentObstacle].transform.position = new Vector2 (meteorSpawnX, botLane);
					meteors [currentObstacle + 1].transform.position = new Vector2 (meteorSpawnX, midLane);
				}
			}
		
			currentObstacle += 1;

			if (currentObstacle >= meteorPoolSize) 
			{
				currentObstacle = 0;
			}
		}

		if (GameControl.instance.gameOver == false && timeSinceLastMeteor >= meteorSpawnRate && obstacleControl == 1) {

			timeSinceLastMeteor = 0f;
			//meteors [currentObstacle].SetActive(true);
			if (spawnControl == 0)
				satelites [currentObstacle].transform.position = new Vector2 (meteorSpawnX, botLane);
			else if (spawnControl == 1)
				satelites [currentObstacle].transform.position = new Vector2 (meteorSpawnX, midLane);
			else if (spawnControl == 2)
				satelites [currentObstacle].transform.position = new Vector2 (meteorSpawnX, topLane);
			else if (spawnControl == 3) {
				if ((currentObstacle + 1) < meteorPoolSize) {
					satelites [currentObstacle].transform.position = new Vector2 (meteorSpawnX, botLane);
					satelites [currentObstacle + 1].transform.position = new Vector2 (meteorSpawnX, topLane);
				}
			}
			else if (spawnControl == 4) {
				if ((currentObstacle + 1) < meteorPoolSize) {
					satelites [currentObstacle].transform.position = new Vector2 (meteorSpawnX, midLane);
					satelites [currentObstacle + 1].transform.position = new Vector2 (meteorSpawnX, topLane);
				}
			}
			else if (spawnControl == 5) {
				if ((currentObstacle + 1) < meteorPoolSize) {
					satelites [currentObstacle].transform.position = new Vector2 (meteorSpawnX, botLane);
					satelites [currentObstacle + 1].transform.position = new Vector2 (meteorSpawnX, midLane);
				}
			}

			currentObstacle += 1;

			if (currentObstacle >= meteorPoolSize) 
			{
				currentObstacle = 0;
			}
		}
	}
}

