using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;


public class UIManager_Title : MonoBehaviour
{

	//controls the pausing of the scene
	public void play(){SceneManager.LoadScene("Game");}

	public void instructions(){SceneManager.LoadScene("InstructionScene");}

	public void quit(){Application.Quit();}

}
