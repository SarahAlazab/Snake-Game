using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_Controller : MonoBehaviour {

	public float moveSpeed;//Snake movement speed
	Vector3 curDirection;//Current snake direction

	public GameObject tailBlock;
	GameObject newBlock;
	public float blockOffset; //Distance between snake blocks

	public GameObject snakeBlock;//Prefab of snake body block

	// Use this for initialization
	void Start () {
		Vector3[] directions = new Vector3[]{Vector3.forward, Vector3.back, Vector3.left, Vector3.right};//Populate Array with the four original directions 
		curDirection = directions[Random.Range (0, 4)];//Random snake direction at level start

		Invoke ("AddSnakeBlock", 0.2f);//Add second block to the snake
		Invoke ("AddSnakeBlock", 0.4f);//Add third block to the snake
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("a") && curDirection!= Vector3.right) {//No flipping direction: Snake can go left only if its not going right
			curDirection = Vector3.left;
		}
		if (Input.GetKeyDown ("d") && curDirection!= Vector3.left) {//No flipping direction: Snake can go right only if its not going left
			curDirection = Vector3.right;
		}
		if (Input.GetKeyDown ("w") && curDirection!= Vector3.back) {//No flipping direction: Snake can go up only if its not going down
			curDirection = Vector3.forward;
		}
		if (Input.GetKeyDown ("s") && curDirection!= Vector3.forward) {//No flipping direction: Snake can down only if its not going up
			curDirection = Vector3.back;
		}

		transform.Translate (curDirection* moveSpeed * Time.deltaTime);//Move to current direction
	}

	public void AddSnakeBlock()
	{
		if (newBlock) {//After creating the first snake block we will start storing the last block in the variable tail block in order for the next block to follow it
			tailBlock = newBlock.gameObject;
		}
		Vector3 newSnakeBlockPos = tailBlock.transform.position;//Store tail block position

		if(curDirection == Vector3.back && !newBlock)//Temporary bug fix when creating the first block (To be examined) // Create new block after tail block adding an offset value
			newBlock = GameObject.Instantiate (snakeBlock, newSnakeBlockPos + (tailBlock.transform.forward*blockOffset), Quaternion.identity);
		else
			newBlock = GameObject.Instantiate (snakeBlock, newSnakeBlockPos - (tailBlock.transform.forward*blockOffset), Quaternion.identity);

	}

	void OnCollisionEnter(Collision col)//When hitting an obstacle or self, reload the scene
	{
		if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Snake Block") {
			SceneManager.LoadScene ("Scene_1");
		}
	}
}
