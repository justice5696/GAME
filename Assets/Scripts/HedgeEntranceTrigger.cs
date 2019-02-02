using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeEntranceTrigger : MonoBehaviour {

    private void OnTriggerExit(Collider collision)
    {
			if (collision.gameObject.tag == "Player")
			{
					Debug.Log("Player exited");
					collision.gameObject.GetComponent<CharacterStatus>().setTrigger(true);
			}
    }
}
