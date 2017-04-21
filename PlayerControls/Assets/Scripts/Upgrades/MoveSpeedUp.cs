using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedUp : MonoBehaviour {

	public float baseDuration;
	float duration;
	public float amp;
	bool changed;
	public GameObject player;
	PlayerMovement movement;
	// Use this for initialization
	void Start () {
		duration = baseDuration;
		changed = false;
		movement = player.GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(movement.currentMoveSpeed);
		if (changed == true)
		{
			if (duration > 0)
				duration -= Time.deltaTime;
			else
			{
				changed = false;
				duration = baseDuration;
			}
		}
		if (changed == false)
			movement.currentMoveSpeed = movement.baseMoveSpeed;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (changed == false)
		{
			if (other = player.GetComponent<Collider>())
			{
				grantMoveSpeed();
			}
		}
	}

	public void grantMoveSpeed()
	{
		changed = true;
		movement.currentMoveSpeed += amp;
	}


}
