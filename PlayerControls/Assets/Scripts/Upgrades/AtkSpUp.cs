using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpUp : MonoBehaviour {

	public GameObject player;
	PlayerShooting playershoot;
	bool changed;
	public float baseDuration;
	float duration;
	public float bonusAmp;
	float tempTimeInterval;
	// Use this for initialization
	void Start () {
		changed = false;
		baseDuration = 2f;
		duration = baseDuration;
		playershoot = player.GetComponent<PlayerShooting>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
			playershoot.currentTimeInterval = playershoot.baseTimeInterval;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (changed == false)
		{
			if (other = player.GetComponent<Collider>())
			{
				grantAtkSp();
				//Destroy(gameObject);
			}
		}
	}

	public void grantAtkSp()
	{
		changed = true;
		playershoot.setTimeInterval(playershoot.currentTimeInterval - bonusAmp);
	}
}
