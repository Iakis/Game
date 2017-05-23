using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
	public GameObject target;
	public float speed;
	public Collider col;
	private void Start()
	{

		col = target.GetComponent<Collider>();
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
			Destroy(target);
		}
	}

}	