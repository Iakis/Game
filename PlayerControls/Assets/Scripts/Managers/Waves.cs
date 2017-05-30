using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

	public static Waves instance;
	private int wave;
	List<GameObject> enemies;
	public GameObject enemy, player, playerSpawnZone;
	// Use this for initialization
	void Awake ()
	{
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
			Vector3 pos = genPosition();
			while(pos == player.transform.position)
			{
				genPosition();
			}
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
	public Vector3 genPosition()
	{
		float z = Random.Range(-25, 25);
		float x = Random.Range(-25, 25);


		Vector3 pos = new Vector3(x, 2.5f, z);
		if (playerSpawnZone.GetComponent<Collider>().bounds.Contains(pos))
		{
			genPosition();
		}
		return pos;
	}
	public int getWave()
	{
		return wave;
	}
	public int getRemaining()
	{
		return enemies.Count;
	}
}
