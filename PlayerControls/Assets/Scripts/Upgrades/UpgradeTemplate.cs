
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTemplate : MonoBehaviour
{

	public GameObject player;
	PlayerShooting playershoot;
	bool changed;
	public float baseDuration;
	float duration;
	public float bonusAmp;
	float tempTimeInterval;
	// Use this for initialization
	void Start()
	{
		changed = false;
		baseDuration = 2f;
		duration = baseDuration;
		//Script to get from player - Temp: playershoot = player.GetComponent<PlayerShooting>();
	}

	// Update is called once per frame
	void Update()
	{
		//Timer. Change BaseTimeInterval to change how long it lasts
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
			//Change to whatever 
			playershoot.currentTimeInterval = playershoot.baseTimeInterval;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (changed == false)
		{
			//Change to whatever game object
			if (other = player.GetComponent<Collider>())
			{
				//Whatever the bonus method is below
				bonus();
				//Destroy(gameObject);
			}
		}
	}

	public void bonus()
	{
		
	}
}
