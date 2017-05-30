using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public float bulletSpeed;
	public GameObject enemy;
	private Collider enemyCol;
	// Use this for initialization
	void Start () {
		bulletSpeed = 1f;
		enemyCol = enemy.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * bulletSpeed);
		Destroy(gameObject, 2f);
		
	}
}