using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponText : MonoBehaviour {

	private Text myText;
	private Inventory D;

	void Start () {
		myText = GetComponent<Text>();
		D = GameObject.FindWithTag("Player").GetComponent<Inventory>();
	//	Debug.Log("WeaponText: myText: " + myText.text);
	}

	// Update is called once per frame
	void LateUpdate () {

		int interval = 10; //this shoudl keep update running 30/10 = 3 times per second
		if (Time.frameCount % interval == 0)
		{
			List<Weapon> w = D.getWeapons();
		//	Debug.Log("WeaponText: w[0] " + w[0].name);
			int wNum = Convert.ToInt32(gameObject.name);
			wNum = wNum - 1;
			if(wNum>5){Debug.Log("wNum is too high.");}


			switch(wNum)
			{
				case -1:
					Debug.Log("WeapponText: Item Text name parse failed");
					myText.text = "Default";
					break;
			 case 0:
			 		myText.text = w[0].name;
					if(D.getCurrentWeapon().name == w[0].name){
						myText.color = Color.red;}
					break;
			 case 1:
				 	myText.text = w[1].name;
					if(D.getCurrentWeapon().name == w[1].name){
						myText.color = Color.red;}
				 	break;
			 case 2:
				 	myText.text = w[2].name;
					if(D.getCurrentWeapon().name == w[2].name){
						myText.color = Color.red;}
				 	break;
			 case 3:
						myText.text = w[3].name;
						if(D.getCurrentWeapon().name == w[3].name){
							myText.color = Color.red;}
						break;
			 case 4:
					myText.text = w[4].name;
					if(D.getCurrentWeapon().name == w[4].name){
						myText.color = Color.red;}
					break;
			 case 5:
					myText.text = w[5].name;
					if(D.getCurrentWeapon().name == w[5].name){
						myText.color = Color.red;}
					break;
			 default:
					Debug.Log("WeaponText: Item Text name parse failed");
					myText.text = "Default";
					break;

			}
		}
	}
}
