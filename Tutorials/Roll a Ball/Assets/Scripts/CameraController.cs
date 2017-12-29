using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame, but guaranteed to run after all items run in update
	void LateUpdate () { //follow cameras, procedural animation, gathering last known states
		this.transform.position = player.transform.position + offset;
	}
}
