using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	RaycastHit hit;
	Ray ray;
	// Use this for initialization
	void Start () {
						
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
			ray = new Ray(transform.position, Vector3.forward);
		
		
	}
}
