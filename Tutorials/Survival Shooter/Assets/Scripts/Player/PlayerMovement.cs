using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;
	public Vector3 movement;
	public Animator anim;
	public Rigidbody playerRigidBody;
	public int floormask;
	public float camRayLength = 100f;

	void Awake(){//like start, but called regardless of whethter script is activated. Good for setting up references.
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody>();
		floormask = LayerMask.GetMask("Floor");
	}

	void FixedUpdate(){//runs when physics updates
		//Axes are input predefined (but customizable) in the Input manager section under Edit->ProjectSettings->Input
		float h = Input.GetAxisRaw("Horizontal"); // returns -1, 0, or 1. Non-raw returns -1<=x<=1. 
		float v = Input.GetAxisRaw("Vertical");
		Move (h, v);
		Turn ();
		Animate (h,v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime; //ensure no speed boost when h AND v movement
		playerRigidBody.MovePosition(this.transform.position + movement);
	}

	void Turn()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition); //takes point on screen and cast it onto screen
		RaycastHit floorHit; // returns true if hit, false if not
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floormask)) { // out means its going to be a reference variable
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0;
			//Cant change rotation based on vector, so use quaternion
			Quaternion newRot = Quaternion.LookRotation(playerToMouse); //forward defaults to Z-Axis
			playerRigidBody.MoveRotation (newRot);
		}
		
	}

	void Animate(float h, float v){
		bool isWalking = ((h != 0) || (v != 0));
		anim.SetBool ("IsWalking", isWalking);
	}
}
