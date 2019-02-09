using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using FSM;
using UnityEngine;


public class UIManager : MonoBehaviour {


/*GameObject[] pauseObjects;
GameObject[] playObjects;
GameObject[] deathObjects;*/

public GameObject Inventory, HUD, Death, Options, Pause, Skills;
private FSM.Process p;

public string HUD_Inventory_I, HUD_Death_I, HUD_Pause_I, Pause_HUD_I, Pause_Options_I, Pause_Inventory_I,
Death_HUD_I, Options_Pause_I, Inventory_HUD_I, Inventory_Skills_I, Inventory_Pause_I, Skills_HUD_I, Skills_Inventory_I;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
    p = new FSM.Process();
	}

	// Update is called once per frame
	void Update ()
	{
		//uses the p button to pause and unpause the game
		if(HUD_Pause_I && (p.CurrentState == HUD)){
				HUD_Pause();
        p.MoveNext(Command.HUD_Pause);}
		if()
		{
			//foreach(GameObject h in playObjects){h.SetActive(true);}

		}
	}

/*	public void transition(GameObject inObj, GameObject outObj)
	{
		if(outObj.name == "HUD") 
			Time.timeScale = 1;
		else 
			Time.timeScale = 0;
			
		inObj.SetActive(false);
		outObj.SetActive(true);
	}
*/	

	//shows objects with ShowOnPause tag
	public void HUD_Pause(){
    Time.timeScale = 0;
    HUD.SetActive(false);
	Pause.SetActive(true);}

  public void HUD_Death(){
    HUD.SetActive(false);
    Death.SetActive(true);}

  public void HUD_Inventory(){
    Time.timeScale = 0;
    HUD.SetActive(false);
    Inventory.SetActive(true);}

	public void Pause_HUD(){
    Time.timeScale = 1;
    Pause.SetActive(false);
    HUD.SetActive(true);}

  public void Pause_Options(){
    Time.timeScale = 0;
    Pause.SetActive(false);
    Options.SetActive(true);}

  public void Pause_Inventory(){
    Time.timeScale = 0;
    Pause.SetActive(false);
    Inventory.SetActive(true);}

  public void Death_HUD(){
    Time.timeScale = 1;
    Death.SetActive(false);
    HUD.SetActive(true);}

  public void Options_Pause(){
    Time.timeScale = 0;
    Options.SetActive(false);
    Pause.SetActive(true);}

  public void Inventory_HUD(){
    Time.timeScale = 1;
    Inventory.SetActive(false);
    HUD.SetActive(true);}

  public void Inventory_Skills(){
    Time.timeScale = 0;
    Inventory.SetActive(false);
    Skills.SetActive(true);}

  public void Inventory_Pause(){
    Time.timeScale = 0;
    Inventory.SetActive(false);
    Pause.SetActive(true);}

  public void Skills_HUD(){
    Time.timeScale = 1;
    Skills.SetActive(false);
    HUD.SetActive(true);}

  public void Skills_Inventory(){
    Time.timeScale = 0;
    Skills.SetActive(false);
    Inventory.SetActive(true);}
}
