using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	RaycastHit hit;
	Ray ray;
	public GameObject bullet;
	public GameObject player = null;
	Vector3 upBulletPos;
	Vector3 downBulletPos;
	Vector3 leftBulletPos;
	Vector3 rightBulletPos;


	Quaternion leftRot;
	Quaternion rightRot;
	Quaternion upRot;
	Quaternion downRot;
	
	// Use this for initialization
	void Start () {
		upBulletPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
		downBulletPos = new Vector3(player.transform.position.x , player.transform.position.y, player.transform.position.z - 1);
		leftBulletPos = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
		rightBulletPos = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);

		leftRot = new Quaternion(90, 90, -90, -90);
		rightRot = new Quaternion(90, 90, 90, 90);
		upRot = new Quaternion(0, 0, 0, 0);
		downRot = new Quaternion(0, 90, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		//Positive z is forward, negative backwards - Positive x is right, negative is left
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			Instantiate(bullet, leftBulletPos, leftRot);
		else if (Input.GetKey(KeyCode.LeftArrow))
			bulletPos = new
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
			Instantiate(bullet, rightBulletPos, rightRot);
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
			Instantiate(bullet, upBulletPos, upRot))
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
			Instantiate(bullet, downBulletPos, downRot);
		//if down else if held down call ienum


	}
	IEnumerable shootDelay(float time, Quaternion a)
	{
		Instantiate(bullet, bulletPos, a);
		yield return new WaitForSeconds(time);
		Instantiate(bullet, bulletPos, a);
	}
}
