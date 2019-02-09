using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    /*
     * The portal object that actually holds this script SHOULD HAVE THE SAME NAME AS THE SCENE IT LOADS TO 
     * 
     */
     
    private void Awake()
    {
        SceneManager.sceneLoaded += this.OnLoadCallback;
        Debug.Log("this name is: " + this.name);
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited");
            //if (Input.GetKeyDown(KeyCode.F1)){
                // Use a coroutine to load the Scene in the background
                StartCoroutine(LoadYourAsyncScene());
            //}
        }

    }



    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        GameObject character = GameObject.FindWithTag("Controller");
        DontDestroyOnLoad(character);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(this.name);

        //LoadSavedData() //if don't destroy on load doesnt work

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        if(scene.name == "Arena")
        {
            GameObject character = GameObject.FindWithTag("Controller");
            character.transform.position = new Vector3(404.0f, 4.0f, 129.0f);
        }
    }
}
