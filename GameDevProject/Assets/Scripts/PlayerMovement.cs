using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {



	private float speed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveX, 0f, moveZ);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		 
		
	}
}
