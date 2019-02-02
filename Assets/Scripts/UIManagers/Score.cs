using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

	private CharacterStatus stat;
	private Text myText;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		myText.text = "";
		stat = GameObject.FindWithTag("Player").GetComponent<CharacterStatus>();
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		int interval = 10; //this shoudl keep update running 30/10 = 3 times per second
		if (Time.frameCount % interval == 0)
		{
			if(GameObject.FindWithTag("Player") != null)
			{
				myText.text = "Score: " + stat.getCharScore().ToString();
			}
		}
	}
}
