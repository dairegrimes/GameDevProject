using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {



	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;
	static Animator anim;
	private int state = 1;

	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;

	public Quaternion TargetRotation
	{
		get{ return targetRotation; }
	}

	void Start()
	{
		anim = GetComponent<Animator>();
		targetRotation = transform.rotation;

		if(GetComponent<Rigidbody>())
		{
			rBody = GetComponent<Rigidbody> ();
		}

		else
		{
			Debug.LogError("Need rigid Body");
		}

		forwardInput = turnInput = 0;

	}

	void GetInput()
	{
		forwardInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
	}

	void Update()
	{
		GetInput();
		Turn();

		switch (state) 
		{
		case 1:
			{
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isIdle", true);
			}
			break;

		case 2 :
			{
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isRunning", true);
			}
			break;
		}


	}

	void FixedUpdate()
	{
		Run();
	}

	void Run()
	{
		if(Mathf.Abs(forwardInput) > inputDelay)
		{
			rBody.velocity = transform.forward * forwardInput * forwardVel;
			state = 2;
		}

		else
		{
			rBody.velocity = Vector3.zero;
			state = 1;
		}
	}

	void Turn()
	{
		targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime,Vector3.up);
		transform.rotation = targetRotation;
	}
}

