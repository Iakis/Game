using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float currentMoveSpeed;
    // Use this for initialization
    void Start()
    {
        currentMoveSpeed = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement

        if (Input.GetAxisRaw("Vertical") > 0)
            transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") < 0)
            transform.Translate(-Vector3.forward * currentMoveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") > 0)
            transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
    }
}