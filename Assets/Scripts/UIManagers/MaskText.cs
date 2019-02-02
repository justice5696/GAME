using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MaskText : MonoBehaviour {

	private Text myText;
	private Inventory D;

	void Start () {
		myText = GetComponent<Text>();
		//Debug.Log("MaskText: myText: " + myText.text);
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		int interval = 10; //this shoudl keep update running 30/10 = 3 times per second
		if (Time.frameCount % interval == 0)
    {
			D = GameObject.FindWithTag("Player").GetComponent<Inventory>();
			List<Mask> w = D.getMasks();
			//Debug.Log("MaskText: w[0] " + w[0].name);
			int wNum = Convert.ToInt32(gameObject.name);
			wNum = wNum - 1;
			if(wNum>5){Debug.Log("wNum is too high.");}
			switch(wNum)
			{
				case -1:
					Debug.Log("MaskText: Item Text name parse failed");
					myText.text = "Default";
					break;
			 case 0:
			 		myText.text = w[0].name;
					break;
			 case 1:
				 	myText.text = w[1].name;
				 	break;
			 case 2:
				 	myText.text = w[2].name;
				 	break;
			 case 3:
	 				myText.text = w[3].name;
	 				break;
			 case 4:
					myText.text = w[4].name;
					break;
			 case 5:
					myText.text = w[5].name;
					break;
			 default:
					Debug.Log("MaskText: Item Text name parse failed");
					myText.text = "Default";
					break;
			}
		}
	}
}
