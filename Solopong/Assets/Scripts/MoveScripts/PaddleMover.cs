using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMover : MonoBehaviour { //paddles should be sensitivity-adjustable

	public float speed = 25f;
	public float zLimit = 8f;


	void Awake(){

	}

//	void FixedUpdate(){//runs when physics updates
//		//Axes are input predefined (but customizable) in the Input manager section under Edit->ProjectSettings->Input
//		float moveVert = Input.GetAxisRaw("Vertical");
//		Vector3 movement = new Vector3 (0.0f, 0.0f, moveVert);
//		rb.AddForce (movement * speed);	
//	}

	void Update(){
		float zPos = this.transform.position.z;
		float motion = Input.GetAxisRaw ("Vertical");
		float bound = zLimit * motion;
		if ( (motion > 0 && zPos <= bound) || (motion < 0 && zPos >= bound) )
			this.transform.position += this.transform.forward.normalized * motion * speed * Time.deltaTime;
	}

}