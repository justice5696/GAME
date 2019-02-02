using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusText : MonoBehaviour {

	private CharacterStatus stat;
	private Text myText;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		myText.text = "The Hitting Game!";
		stat = GameObject.FindWithTag("Player").GetComponent<CharacterStatus>();
	}

	// Update is called once per frame
	void Update ()
	{
		 //this shoudl keep update running 30/10 = 3 times per second
		if(GameObject.FindWithTag("Player") != null)
		{
			myText.text = "Health: " + stat.getCharHealth().ToString();
		}
	}
}
