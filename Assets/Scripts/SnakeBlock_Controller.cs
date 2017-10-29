using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBlock_Controller : MonoBehaviour {

	GameObject tailBlock;
	public float speed;

	// Use this for initialization
	void Start () {
			tailBlock = GameObject.Find ("Snake Head").GetComponent<Snake_Controller>().tailBlock;//Get last block to be used as the new block's follow target
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (tailBlock.transform);//Look at tail
		transform.position = Vector3.Lerp(transform.position, tailBlock.transform.position, Time.deltaTime*speed);//Go after tail
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Snake Head") {//If snake head hit snake body relaod scene
			SceneManager.LoadScene ("Scene_1");
		}
	}
}
