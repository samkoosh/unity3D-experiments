using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5.0f; //follow lag

	private Vector3 offset;

	void Start(){
		offset = this.transform.position - target.position;
	}

	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		// Lerp is a way of tweening
		this.transform.position = Vector3.Lerp (this.transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
