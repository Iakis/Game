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
	bool inputed;
	public Text cont;

	public GameMan gameManageScript;
	public GameObject gameManageEmpty;
	private void Start()
	{
		col = target.GetComponent<Collider>();
		gameManageEmpty = GameObject.FindGameObjectWithTag("GamManage");
		gameManageScript = gameManageEmpty.GetComponent<GameMan>();
	}

	void Update()
	{
		float step = speed * Time.deltaTime;
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