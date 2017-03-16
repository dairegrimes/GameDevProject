using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Respawn : MonoBehaviour {

	public float threshold;

	public int level;

void FixedUpdate () {
		if (transform.position.y < threshold)

			SceneManager.LoadScene (level);
	}
}
