using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshInstantiator : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		UnityEngine.AI.NavMeshHit closestHit;

        if (UnityEngine.AI.NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, UnityEngine.AI.NavMesh.AllAreas))
            gameObject.transform.position = closestHit.position;
        else
            Debug.LogError("Could not find position on NavMesh!");
	}
}
