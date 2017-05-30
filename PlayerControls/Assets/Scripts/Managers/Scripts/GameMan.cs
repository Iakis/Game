using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{

	// Use this for initialization
	public GameObject contPanel;
	bool lost;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}
	public void loseScreen()
	{
		SceneManager.LoadScene("Lose");
	}
}
