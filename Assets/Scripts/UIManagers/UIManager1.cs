using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;


public class UIManager1 : MonoBehaviour {


GameObject[] pauseObjects;
GameObject[] playObjects;
    GameObject[] deathObjects;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		playObjects = GameObject.FindGameObjectsWithTag("ShowDuringPlay");
        deathObjects = GameObject.FindGameObjectsWithTag("ShowOnDeath");
		hidePaused();
    hideDeath();
	}

	// Update is called once per frame
	void Update ()
	{
		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
				Time.timeScale = 0;
				showPaused();
		}
		if(Time.timeScale == 1)
		{
			foreach(GameObject h in playObjects){h.SetActive(true);}
		}
	}


	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach(GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
		foreach(GameObject h in playObjects)
		{
			h.SetActive(false);
		}
	}

	public void hidePaused()
	{
		foreach(GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
		foreach(GameObject h in playObjects)
		{
			h.SetActive(true);
		}
	}

    public void showDeath()
    {
        foreach (GameObject g in deathObjects)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject h in playObjects)
        {
            h.SetActive(false);
        }
    }

    public void hideDeath()
    {
        foreach (GameObject g in deathObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject h in playObjects)
        {
            h.SetActive(true);
        }
    }
}
