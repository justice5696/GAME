using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCubeMovement : MonoBehaviour {

	// Use this for initialization
	public UnityEngine.AI.NavMeshAgent navmesh;
	public Camera cam;

	void Start () {

		//navmesh.SetDestination(new Vector3(150, 10, 270));
	}

	// Update is called once per frame
	void Update () {
		navmesh.SetDestination(cam.transform.position);
	}
}
