using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

	public static Waves instance;
	private int wave;
	List<GameObject> enemies;
	public GameObject enemy, player;
	// Use this for initialization
	void Awake () {
		instance = this;
		wave = 1;
		enemies = new List<GameObject>();
		createEnemies(1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	void createEnemies(int a)
	{
		for (int i = 0; i < a; i++)
		{
			float x = -23 + Random.value * (26+23);
			float z = -38 + Random.value * (11+38);
			Vector3 pos = new Vector3(x, 2.5f, z);
			enemies.Add(enemy);
			GameObject e = Instantiate(enemy, pos, Quaternion.identity) as GameObject;
			e.GetComponent<MoveTowards>().target = player;
			
		}
	}
	public void removeEnemy()
	{
		enemies.Remove(enemy);
		if (enemies.Count < 1)
		{
			wave++;
			createEnemies(wave);
		}
	}
}
