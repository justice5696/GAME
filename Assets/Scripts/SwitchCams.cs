using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCams : MonoBehaviour {

	private Camera firstPersonCamera;
	public Camera overheadCamera;
	GameObject[] pauseObjects;
	GameObject[] playObjects;
	GameObject[] deathObjects;

	void Start()
	{
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		playObjects = GameObject.FindGameObjectsWithTag("ShowDuringPlay");
		deathObjects =  GameObject.FindGameObjectsWithTag("ShowOnDeath");
	}

	public void ShowOverheadView() {
		firstPersonCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		foreach(GameObject g in pauseObjects){g.SetActive(false);}
 		foreach(GameObject h in playObjects){h.SetActive(false);}
		foreach(GameObject i in deathObjects){i.SetActive(true);}
		firstPersonCamera.enabled = false;
		overheadCamera.enabled = true;

	}

	public void ShowFirstPersonView() {
		 firstPersonCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		 foreach(GameObject g in pauseObjects){g.SetActive(false);}
  	 foreach(GameObject h in playObjects){h.SetActive(true);}
 		 foreach(GameObject i in deathObjects){i.SetActive(false);}
		 firstPersonCamera.enabled = true;
		 overheadCamera.enabled = false;
	}
}
