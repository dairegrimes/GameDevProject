using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

	public int cur_coins = 0;
	public GameObject Door;

	// Use this for initialization
	void Start () {

		Door.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void UpdateUI(){

		if(cur_coins <= 0) {
			Door.SetActive (true);

		}


	}
}
