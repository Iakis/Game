using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public GameObject bullet;
	public GameObject player;
	Vector3 upBulletPos;
	Vector3 downBulletPos;
	Vector3 leftBulletPos;
	Vector3 rightBulletPos;
	bool shooting;
	public float currentTimeInterval;
	public float baseTimeInterval;
	public bool coneChanged;

	Quaternion leftRot;
	Quaternion rightRot;
	Quaternion upRot;
	Quaternion downRot;

	Quaternion upRight;
	Quaternion upLeft;
	Quaternion leftLeft;
	Quaternion leftRight;
	Quaternion downLeft;
	Quaternion downRight;
	Quaternion rightLeft;
	Quaternion rightRight;


	// Use this for initialization
	void Start () {
		coneChanged = false;
		baseTimeInterval = .2f;
		currentTimeInterval = baseTimeInterval;

		

		leftRot = new Quaternion(90, 90, -90, -90);
		rightRot = new Quaternion(90, 90, 90, 90);
		upRot = new Quaternion(0, 0, 0, 0);
		downRot = new Quaternion(0, 90, 0, 0);



		upLeft = new Quaternion(0, -67, -67, 300);
		upRight = new Quaternion(0, 67, 67, -300);
	}

	// Update is called once per frame
	public void setTimeInterval(float time)
	{
		currentTimeInterval = time;
	}
	void Update()
	{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (!shooting)
				{
					leftBulletPos = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
					Instantiate(bullet, leftBulletPos, leftRot);
					StartCoroutine(tapDelay(currentTimeInterval));
				// if (coneChanged)
						//Instantiate(bullet, upBulletPos);
			}
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{	w
				leftBulletPos = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
				if (!shooting)
					StartCoroutine(shootDelay(currentTimeInterval, leftRot, leftBulletPos, KeyCode.LeftArrow));
			}

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				rightBulletPos = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
				if (!shooting)
				{
					Instantiate(bullet, rightBulletPos, rightRot);
					StartCoroutine(tapDelay(currentTimeInterval));
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				rightBulletPos = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
				if (!shooting)
					StartCoroutine(shootDelay(currentTimeInterval, rightRot, rightBulletPos, KeyCode.RightArrow));
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				upBulletPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
				if (!shooting)
				{
					Instantiate(bullet, upBulletPos, upRot);
					StartCoroutine(tapDelay(currentTimeInterval));
				if (coneChanged)
				{
					Instantiate(bullet, upBulletPos, upLeft);
					Instantiate(bullet, upBulletPos, upRight);
				}
			}
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				upBulletPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
				if (!shooting)
					StartCoroutine(shootDelay(currentTimeInterval, upRot, upBulletPos, KeyCode.UpArrow));
			}
	
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				downBulletPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
				if (!shooting)
				{
					Instantiate(bullet, downBulletPos, downRot);
					StartCoroutine(tapDelay(currentTimeInterval));
				}
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{

				downBulletPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
				if (!shooting)
					StartCoroutine(shootDelay(currentTimeInterval, downRot, downBulletPos, KeyCode.DownArrow));
			}

		//Cone Upgrade
		if (coneChanged == true)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				upBulletPos = new Vector3(player.transform.position.x+1, player.transform.position.y, player.transform.position.z + 3);
				if (!shooting)
				{
					Instantiate(bullet, upBulletPos, upRot);
					StartCoroutine(tapDelay(currentTimeInterval));
				}
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				upBulletPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 3);
				if (!shooting)
					StartCoroutine(shootDelay(currentTimeInterval, upRot, upBulletPos, KeyCode.UpArrow));
			}

		}



	}
	IEnumerator shootDelay(float time, Quaternion a, Vector3 bul, KeyCode b)
	{
		shooting = true;
		yield return new WaitForSeconds(time);
		if (Input.GetKey(b))
			Instantiate(bullet, bul, a);
		shooting = false;
	}

	IEnumerator tapDelay(float time)
	{
		shooting = true;
		yield return new WaitForSeconds(time);
		shooting = false;
	}
}
