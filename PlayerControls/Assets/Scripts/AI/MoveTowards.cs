using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveTowards : MonoBehaviour
{
	public GameObject target;
	public float speed;
	private Collider col;

	bool reset = false;

	private int lastDirection = 0;
	public GameMan gameManageScript;
	public GameObject gameManageEmpty;

	private Animator anim;
	private void Start()
	{
		anim = GetComponentInChildren<Animator>();
		col = target.GetComponent<Collider>();
		gameManageEmpty = GameObject.FindGameObjectWithTag("GamManage");
		gameManageScript = gameManageEmpty.GetComponent<GameMan>();
	}

	void Update()
	{
		float step = speed * Time.deltaTime;
		Vector3 diff = target.transform.position - transform.position;
		int dir = (int)(((Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg) + 135f) / 90);


		if (reset)
		{
			anim.SetInteger("Direction", -1);
			reset = false;
		}


		if (dir != lastDirection)
		{
			anim.SetInteger("Direction", dir);
			lastDirection = dir;
			reset = true;
		}


		//Debug.Log((int)(((Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg) + 135f) / 90));
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other == col)
		{
			gameManageScript.loseScreen();
			
		}
	}
}	