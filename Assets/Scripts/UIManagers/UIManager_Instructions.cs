using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;


public class UIManager_Instructions : MonoBehaviour
{

	//Loads Title Scene
	public void MainMenu(){SceneManager.LoadScene("Title");}
	//controls the pausing of the scene
	public void play(){SceneManager.LoadScene("Game");}

}
