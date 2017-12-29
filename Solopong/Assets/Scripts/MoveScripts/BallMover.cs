using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour {

	public float speed = 25.0f;
	public float vecX,vecY,vecZ;
	private Vector3 origin;
	private Vector3 criticalVec, criticalOrigin;
	Renderer renderer;
	Material mat;
	PaddleBehavior pb;

	public float angle;
	public GameObject paddle;

	void Awake ()
	{
		pb = paddle.GetComponent<PaddleBehavior>();
		origin = new Vector3 (0.0f, 2f, 0.0f);
		renderer = GetComponent<Renderer> ();
		mat = renderer.material;
	}

	void Start(){
		this.transform.position = origin;
		RandomizeForward ();
	}

	void Update () {
		this.transform.position += this.transform.forward.normalized * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision){
		GameObject other = collision.collider.gameObject;
		bool shouldReflect = false;
		Vector3 normal = new Vector3();

		if (other.CompareTag ("BouncerTop")) {
			shouldReflect = true;
			normal = Vector3.back;
		} else if (other.CompareTag ("BouncerBottom")) {
			shouldReflect = true;
			normal = Vector3.forward;
		} else if (other.CompareTag ("DeadZoneLeft") || other.CompareTag ("DeadZoneRight")) {
			shouldReflect = true;
			normal = Vector3.left;
		} else if (other.CompareTag ("PaddleLeft")) {
			criticalOrigin = pb.getNormalOrigin ();
			criticalVec = (this.transform.position - criticalOrigin).normalized;
			this.transform.forward = criticalVec;
		}
		if (shouldReflect) {
			this.transform.forward = Vector3.Reflect (this.transform.forward, normal);
			mat.SetColor ("_EmissionColor", Color.green);
		}
	}


	void RandomizeForward (){
		angle = Random.Range (20f, 150f);
		if (Random.value <= 0.5f)
			angle *= (-1f);
		transform.Rotate (0, angle, 0);
	}
}
