﻿// MoveDestination.cs
// Patrol.cs
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Patrol : MonoBehaviour {


	public Transform[] points;
	public Transform player;
	private int destPoint = 0;
	private UnityEngine.AI.NavMeshAgent agent;
	static Animator anim;
	public float maxRayDistance = 15;
	//LoadLevel startAgain;
	public int levelNumber;

	private int state = 1;


	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator> ();


		}






	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}


	void Update () {


		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		switch (state) {
			
		case 1:
			{
				if (agent.remainingDistance < 1f) {

					agent.speed = 5;
					GotoNextPoint ();

				}

				if (Vector3.Distance (player.position, this.transform.position) < 10 && angle < 20) {
					
					anim.SetBool("isWalking",false);
					anim.SetBool("isRunning",true);
					state = 2;

				}

			}break;



		case 2: 
			{
				agent.speed = 15;
				direction.y = 0;

				this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction), 0.1f);
				agent.destination = player.position;


				if (Vector3.Distance (player.position, this.transform.position) < 2) {

					anim.SetBool("isRunning",false);
					state = 3;

				}

			}break;

		case 3: 
			{
					anim.SetBool("isAttacking",true);
					StartCoroutine("Delay");

			}break;

		}	
			
	}


	IEnumerator Delay() {
		
		yield return new WaitForSeconds(2);
		//SceneManager.LoadScene (startAgain.LevelToLoad);
		SceneManager.LoadScene (levelNumber); 
	}

}






