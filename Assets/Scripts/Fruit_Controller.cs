using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Controller : MonoBehaviour {

	Game_Manager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("Game Manager").GetComponent<Game_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.name == "Snake Head") {
			col.gameObject.GetComponent<Snake_Controller> ().AddSnakeBlock (); //increase snake size
			col.gameObject.GetComponent<AudioSource>().Play();//Play munching sound
			Game_Manager.score++;
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Snake Block" ) {//Temporary: If spawned inside obstacle or snake body destroy fruit (To be optimized)
			print ("destroyed");
			Destroy (gameObject);
		}
	}
}
