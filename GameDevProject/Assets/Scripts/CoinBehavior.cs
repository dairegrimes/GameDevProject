using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour {


	GameManagement GM;
	private float speed = 10f;
	// Use this for initialization
	void Start () {

		GM = GameObject.Find ("GameManager").GetComponent<GameManagement> ();
		GM.cur_coins++;

		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.left * speed);
		
	}


	void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag == "player"){
			
			Destroy (gameObject);
			GM.cur_coins--;
			GM.UpdateUI ();
		}

	}
}
