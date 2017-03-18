using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodging : MonoBehaviour
{

	// Use this for initialization
	public float timeLimit;
	private float timeRemaining;
	Vector3 temp;
	void Start()
	{
		timeLimit = .5f;
	}

	// Update is called once per frame
	void Update()
	{

		//Shift Dodging
		if (Input.GetAxisRaw("Vertical") > 0 && Input.GetKeyDown(KeyCode.LeftShift))
			transform.position += Vector3.forward * 5;
		if (Input.GetAxisRaw("Vertical") < 0 && Input.GetKeyDown(KeyCode.LeftShift))
			transform.position += Vector3.back * 5;
		if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetKeyDown(KeyCode.LeftShift))
			transform.position += Vector3.right * 5;
		if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetKeyDown(KeyCode.LeftShift))
			transform.position += Vector3.left * 5;

		
		
		//Double tap dodging

		if (Input.GetKeyDown(KeyCode.W))
		{
			timeRemaining = timeLimit;
			if (canDodge())
				if (Input.GetKeyDown(KeyCode.W))
					transform.position += Vector3.forward * 5;
		}
		Debug.Log(canDodge());
	}

	bool canDodge()
	{
		if (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
			return true;
		}
		else if (timeRemaining <= 0)
		{
			timeRemaining = 0f;
			return false;
		}
		return false;
	}
}
