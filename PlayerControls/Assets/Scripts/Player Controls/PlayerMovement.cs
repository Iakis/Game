using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float baseMoveSpeed;
    public float currentMoveSpeed;
	public Animator anim;
    // Use this for initialization
    void Start()
	{
		anim = GetComponentInChildren<Animator>();
		baseMoveSpeed = 5f;
		currentMoveSpeed = baseMoveSpeed;
		anim.SetInteger("Direction", 0);
	}

	// Update is called once per frame
	void Update()
	{
		anim.SetInteger("Direction", -1);

		//Movement
		if (Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.S))
			transform.Translate(-Vector3.forward * currentMoveSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);		


		if (Input.GetKeyDown(KeyCode.W))
			anim.SetInteger("Direction", 3);
		if (Input.GetKeyDown(KeyCode.S))
			anim.SetInteger("Direction", 4);
		if (Input.GetKeyDown(KeyCode.A))
			anim.SetInteger("Direction", 2);
		if (Input.GetKeyDown(KeyCode.D))
			anim.SetInteger("Direction", 1);

		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
			anim.SetInteger("Direction", 0);
	}
}