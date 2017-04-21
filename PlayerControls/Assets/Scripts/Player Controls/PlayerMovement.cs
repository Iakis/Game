using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float baseMoveSpeed;
    public float currentMoveSpeed;
    // Use this for initialization
    void Start()
	{
		baseMoveSpeed = 5f;
		currentMoveSpeed = baseMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
		//Movement
		
		/*if (Input.GetAxisRaw("Vertical") > 0)
            transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") < 0)
            transform.Translate(-Vector3.forward * currentMoveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") > 0)
            transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
			*/
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
			transform.Translate(-Vector3.forward * currentMoveSpeed * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
    }
}