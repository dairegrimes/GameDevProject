﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {


	public int LevelToLoad;

	void OnTriggerEnter(Collider other){

		LevelToLoad ++;

		if(other.gameObject.tag == "player"){

			SceneManager.LoadScene (LevelToLoad);

		}
	}
}
