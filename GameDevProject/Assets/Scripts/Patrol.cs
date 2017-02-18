﻿// MoveDestination.cs
// Patrol.cs
using UnityEngine;
using System.Collections;

public enum State {

	WALK,
	ATTACK,
	CHASE

}



public class Patrol : MonoBehaviour {


	public Transform[] points;
	public Transform player;
	private int destPoint = 0;
	private UnityEngine.AI.NavMeshAgent agent;
	static Animator anim;

	private int state = 1;


	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator> ();

		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).

		//agent.autoBraking = false;
		//GotoNextPoint ();

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
		// Choose the next destination point when the agent gets
		// close to the current one.

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		//float angle = Vector3.Angle(direction,this.transform.forward);
		switch (state) {
			
		case 1:
			{
				if (agent.remainingDistance < 0.5f) {

					agent.speed = 50;
					GotoNextPoint ();

				}

				if (Vector3.Distance (player.position, this.transform.position) < 10 && angle < 30) {
					anim.SetBool("isWalking",false);
					state = 2;

				}

			}break;



		case 2: 
			{
				agent.speed = 100;
				anim.SetBool("isRunning",true);
				direction.y = 0;

				this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
					Quaternion.LookRotation(direction), 0.1f);
				agent.destination = player.position;


				if (Vector3.Distance (player.position, this.transform.position) < 5 && angle < 30) {

					anim.SetBool("isAttacking",true);
				}

			}break;

		}	


	
	}
}






