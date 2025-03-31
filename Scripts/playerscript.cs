using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
	//general variable
	//functions
		//function-specific variables
	// Movement
	private float playerspeed = 8.0f;
	private float horizontalInput;
	private float verticalInput;

	private float horizontalScreenLimit = 11f;
	//private float verticalScrollLimit = 6.5f;
	private float verticalScreenLimitL = -4.41f;
	private float verticalScreenLimitU = 0f;
	public GameObject bulletPrefab;

	private void Update ()
	{
		//This function is called every frame; 60 frames/second
		Movement();
		Shooting();
	}

	void Movement()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		//move the player
		transform.Translate(new Vector3(horizontalInput, verticalInput,0) * Time.deltaTime * playerspeed);
		//Player Leaves Screen Horozontally
		if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit){
			transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
		}

		//if (transform.position.y > verticalScrollLimit || transform.position.y < -verticalScrollLimit){
		//	transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
		//}
		if (transform.position.y < verticalScreenLimitL){
			transform.position = new Vector3(transform.position.x, -4.4f, 0);
		}
		if (transform.position.y > verticalScreenLimitU){
			transform.position = new Vector3(transform.position.x, 0f, 0);
		}
	}
	// Shooting
	void Shooting(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		}
	}
}