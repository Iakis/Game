using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedUp : MonoBehaviour
{

	public float baseDuration;
	float duration;
	public float amp;
	bool changed;
	public GameObject player;
	PlayerMovement movement;
	MeshRenderer mesh;
	// Use this for initialization
	void Start ()
	{
		duration = baseDuration;
		changed = false;
		movement = player.GetComponent<PlayerMovement>();
		mesh = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	private void OnTriggerEnter(Collider other)
	{
			if (other = player.GetComponent<Collider>())
			{
//
			}
	}
}
