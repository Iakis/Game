using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	// Use this for initialization
	public Text textRef;
	public int wave;
	private Waves wavesScript;
	public GameObject wavehandler;
	void Awake () {

		wavesScript = wavehandler.GetComponent<Waves>();
	}
	
	// Update is called once per frame
	void Update () {
		textRef.text = "Wave: " + wavesScript.getWave().ToString();
	}
}
