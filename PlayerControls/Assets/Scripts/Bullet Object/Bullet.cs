using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public float bulletSpeed; 

	// Use this for initialization
	void Start () {
		bulletSpeed = 1.5f;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * bulletSpeed);
		Destroy(gameObject, 2f);
		
	}
}