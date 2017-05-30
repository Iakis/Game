using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour {

	public GameObject atksp, movespeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float r = Random.Range(0, 100);
		if (r > 98)
		{
			float x = Random.value;
			if (x < .5)
				//Instantiate(atksp, genPosition(), Quaternion.identity);
			//else
				Instantiate(movespeed, genPosition(), Quaternion.identity);
		}
		
	}
	public Vector3 genPosition()
	{
		float x = Random.Range(-27, 26);
		float z = Random.Range(-34, 11);
		Vector3 pos = new Vector3(x, 2.5f, z);
		return pos;
	}
}
