using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{

	public GameObject player;
	PlayerShooting playershoot;
	bool changed;
	public float baseDuration;
	float duration;
	// Use this for initialization
	void Start()
	{
		changed = false;
		baseDuration = 2f;
		duration = baseDuration;
		playershoot = player.GetComponent<PlayerShooting>();
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(playershoot.coneChanged);	
		//Timer. Change BaseTimeInterval to change how long it lasts
		if (changed == true)
		{
			if (duration > 0)
			{
				duration -= Time.deltaTime;
				playershoot.coneChanged = true;
			}
			else
			{
				changed = false;
				duration = baseDuration;
			}
		}
		if (changed == false)
			playershoot.coneChanged = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (changed == false)
		{
			//Change to whatever game object
			if (other = player.GetComponent<Collider>())
			{
				changed  = true;
			}
		}
	}

}
