using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;


public class UIManager : MonoBehaviour
{


	//Reloads the Level
	public void Reload(){SceneManager.LoadScene("Game");}
	//Loads Title Scene
	public void MainMenu(){SceneManager.LoadScene("Title");}
	//controls the pausing of the scene
	public void play()
	{
		Time.timeScale = 1;
		GameObject[] pauseObjects;
		GameObject[] playObjects;
        GameObject[] deathObjects;
		//hidePaused();
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		playObjects = GameObject.FindGameObjectsWithTag("ShowDuringPlay");
        deathObjects = GameObject.FindGameObjectsWithTag("ShowOnDeath");
        foreach (GameObject g in pauseObjects){g.SetActive(false);}
		foreach(GameObject h in playObjects){h.SetActive(true);}
        foreach (GameObject i in deathObjects) { i.SetActive(false); }


    }

	public void equipWeapon1()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Weapon1");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Weapon> w = p.populateWeapons();
		if(w.ContainsKey(myText.text))
		{
			p.equipWeapon(w[myText.text]);
		}
	}

	public void equipWeapon2()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Weapon2");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Weapon> w = p.populateWeapons();
		if(w.ContainsKey(myText.text))
		{
			p.equipWeapon(w[myText.text]);
		}
	}

	public void equipWeapon3()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Weapon3");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Weapon> w = p.populateWeapons();
		if(w.ContainsKey(myText.text))
		{
			p.equipWeapon(w[myText.text]);
		}
	}

	public void equipWeapon4()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Weapon4");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Weapon> w = p.populateWeapons();
		if(w.ContainsKey(myText.text))
		{
			p.equipWeapon(w[myText.text]);
		}
	}
	public void equipWeapon5()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Weapon5");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Weapon> w = p.populateWeapons();
		if(w.ContainsKey(myText.text))
		{
			p.equipWeapon(w[myText.text]);
		}
	}
	public void equipWeapon6()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Weapon6");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Weapon> w = p.populateWeapons();
		if(w.ContainsKey(myText.text))
		{
			p.equipWeapon(w[myText.text]);
		}
	}



	public void equipMask1()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Mask1");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Mask> w = p.populateMasks();
		if(w.ContainsKey(myText.text))
		{
			p.equipMask(w[myText.text]);
		}
	}

	public void equipMask2()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Mask2");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Mask> w = p.populateMasks();
		if(w.ContainsKey(myText.text))
		{
			p.equipMask(w[myText.text]);
		}
	}

	public void equipMask3()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Mask3");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Mask> w = p.populateMasks();
		if(w.ContainsKey(myText.text))
		{
			p.equipMask(w[myText.text]);
		}
	}

	public void equipMask4()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Mask4");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Mask> w = p.populateMasks();
		if(w.ContainsKey(myText.text))
		{
			p.equipMask(w[myText.text]);
		}
	}

	public void equipMask5()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Mask5");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Mask> w = p.populateMasks();
		if(w.ContainsKey(myText.text))
		{
			p.equipMask(w[myText.text]);
		}
	}

	public void equipMask6()
	{
		Inventory p = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		//Text myText = gameObject.GetComponentInChildren<Text>();
		GameObject weapon = GameObject.Find("Mask6");
		Text myText = weapon.GetComponentInChildren<Text>();
		Dictionary<string, Mask> w = p.populateMasks();
		if(w.ContainsKey(myText.text))
		{
			p.equipMask(w[myText.text]);
		}
	}

}
