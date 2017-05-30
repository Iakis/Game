using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRem : MonoBehaviour
{

	// Use this for initialization
	public Text textRef;
	public int wave;
	private Waves wavesScript;
	public GameObject wavehandle;
	void Awake()
	{
		wavesScript = wavehandle.GetComponent<Waves>();
 	}

	// Update is called once per frame
	void Update()
	{
		textRef.text = "Enemies: " + wavesScript.getRemaining().ToString();
	}
}
