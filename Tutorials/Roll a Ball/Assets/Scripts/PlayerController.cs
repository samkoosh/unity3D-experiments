using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start(){ //called on first active frame
		rb = GetComponent<Rigidbody> ();
		count = -1;
		IterateCount ();
		winText.text = "";
	}


	void FixedUpdate(){ // called before physics calcs (physics code)
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}


	void OnTriggerEnter(Collider other){//called when touching trigger collider 
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			IterateCount ();
		}
	}

	void IterateCount(){
		++count;
		countText.text = "Score: " + count.ToString ();
		if (count >= 12)
			winText.text = "You Win!";
	}
}
