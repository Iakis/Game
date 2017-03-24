using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodging : MonoBehaviour
{

	// Use this for initialization
	public float timeLimit;
	private float timeRemaining;
	private int tapCountW, tapCountA, tapCountS, tapCountD;
	public int dodgeDistance;
	Vector3 temp;
	void Start()
	{
		dodgeDistance = 10;
		tapCountW = 0;
		tapCountA = 0;
		tapCountS = 0;
		tapCountD = 0;

		timeLimit = .5f;
	}

	// Update is called once per frame
	void Update()
	{

		//Shift Dodging
		
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (Input.GetAxisRaw("Vertical") > 0)
				transform.position += Vector3.forward * dodgeDistance;
			if (Input.GetAxisRaw("Vertical") < 0)
				transform.position += Vector3.back * dodgeDistance;
			if (Input.GetAxisRaw("Horizontal") > 0)
				transform.position += Vector3.right * dodgeDistance;
			if (Input.GetAxisRaw("Horizontal") < 0)
				transform.position += Vector3.left * dodgeDistance;
		}


		//Double tap dodging
		
		if (Input.GetKeyDown(KeyCode.W))
		{
			if (timeLimit > 0 && tapCountW == 1)
				transform.position += Vector3.forward  * dodgeDistance;
			else
			{
				timeLimit = 0.5f;
				tapCountW++;
				tapCountA = 0;
				tapCountS = 0;
				tapCountD = 0;
			}
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			if (timeLimit > 0 && tapCountS == 1)
				transform.position += Vector3.back  * dodgeDistance;
			else
			{
				timeLimit = 0.5f;
				tapCountW = 0;
				tapCountA = 0;
				tapCountS++;
				tapCountD = 0;
			}
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			if (timeLimit > 0 && tapCountD == 1)
				transform.position += Vector3.right  * dodgeDistance;
			else
			{
				timeLimit = 0.5f;
				tapCountW = 0;
				tapCountA = 0;
				tapCountS = 0;
				tapCountD++;
			}
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			if (timeLimit > 0 && tapCountA == 1)
				transform.position += Vector3.left  * dodgeDistance;
			else
			{
				timeLimit = 0.5f;
				tapCountW = 0;
				tapCountA++;
				tapCountS = 0;
				tapCountD = 0;
			}
		}


		if (timeLimit > 0)
			timeLimit -= 1 * Time.deltaTime;
		else
		{
			tapCountW = 0;
			tapCountA = 0;
			tapCountS = 0;
			tapCountD = 0;
		}
			
	}
}