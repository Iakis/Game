using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{

	public int health;
	public GameObject bul;

	public Waves wav;

	// Use this for initialization
	void Start ()
	{
		wav = Waves.instance;
		health = 5;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
			wav.removeEnemy();
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bullet")
		{
			health--;
			Destroy(other.gameObject);
		}

	}
}
