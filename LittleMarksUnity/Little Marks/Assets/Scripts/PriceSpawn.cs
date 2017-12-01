using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceSpawn : MonoBehaviour {

	public GameObject priceColaPrefab;
	public GameObject priceFriesPrefab;
	public GameObject priceBurguerPrefab;
	public GameObject pricePizzaPrefab;
	public float botLane = -3.0f;
	public float midLane = 0f;
	public float topLane = 3.0f;
	public float priceSpawnX = 12f;
	public float priceSpawnRate = 5f;

	private GameObject[] prices;
	private int pricePoolSize = 4;
	private Vector2 initialPrice = new Vector2 (-35f, -25f);
	private float timeSinceLastPrice;

	// Use this for initialization
	void Start () {
		prices = new GameObject[pricePoolSize];

		prices[0] = (GameObject)Instantiate (priceColaPrefab, initialPrice, Quaternion.identity);
		prices[1] = (GameObject)Instantiate (priceFriesPrefab, initialPrice, Quaternion.identity);
		prices[2] = (GameObject)Instantiate (priceBurguerPrefab, initialPrice, Quaternion.identity);
		prices[3] = (GameObject)Instantiate (pricePizzaPrefab, initialPrice, Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
		int spawnControl;
		int laneControl;
		float lane;
		timeSinceLastPrice += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastPrice >= priceSpawnRate) {

			spawnControl = Random.Range (0, 100);
			laneControl = Random.Range (0, 3);

			if (laneControl == 0)
				lane = topLane;
			else if (laneControl == 1)
				lane = midLane;
			else
				lane = botLane;

			timeSinceLastPrice = 0;
			Vector2 laneXY = new Vector2 (priceSpawnX, lane);

			if (spawnControl <= 50) {
				prices[0] = (GameObject)Instantiate (priceColaPrefab, laneXY, Quaternion.identity);
			} else if (spawnControl > 50 && spawnControl <= 75) {
				prices[1] = (GameObject)Instantiate (priceFriesPrefab, laneXY, Quaternion.identity);
			}
			else if (spawnControl > 75 && spawnControl <= 92) {
				prices[2] = (GameObject)Instantiate (priceBurguerPrefab, laneXY, Quaternion.identity);
			}
			else
				prices[3] = (GameObject)Instantiate (pricePizzaPre	fab, laneXY, Quaternion.identity);
		}

	}
}
