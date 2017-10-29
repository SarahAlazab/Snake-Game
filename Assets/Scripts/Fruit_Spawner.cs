using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Spawner : MonoBehaviour {

	public GameObject fruit;//Fruit prefab

	public float xDistance;//X distance beween origin and borders
	public float zDistance;//Z distance beween origin and borders

	GameObject spawnedFruit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawnedFruit) {//If there isn't a spawned fruit (any more)
			SpawnFruit ();
		}
	}

	void SpawnFruit()
	{
		Vector3 spawnPos= new Vector3(Random.Range(xDistance,-xDistance),0.2f,Random.Range(zDistance,-zDistance));//Generate random point inside borders
		spawnedFruit = Instantiate (fruit, spawnPos, Quaternion.identity);//Spawn fruit in generated point

	}
}
