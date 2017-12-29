using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour {

	public float sensitivity = 0.5f;
	private float paddleY;
	public Vector3 topOffset, bottomOffset;
	private Vector3 topPoint, bottomPoint;
	public LineRenderer topLine, bottomLine;
	private Vector3 origin;
	public float range = 0.4f;

	public void Awake(){
		topOffset = new Vector3 (this.transform.localScale.x / 2.0f, 0, this.transform.localScale.z / 2.0f);
		bottomOffset = new Vector3 (this.transform.localScale.x / 2.0f, 0, -this.transform.localScale.z / 2.0f);
		paddleY = this.GetComponentInParent<Transform>().position.y;
	}

	public void Update(){
		origin = getNormalOrigin ();
		UpdatePoints ();
		Vector3 topDir, bottomDir;
		topDir = topPoint - origin;
		bottomDir = topDir;
		bottomDir.z *= -1;
		topLine.SetPosition (0, topPoint);
		topLine.SetPosition (1, topPoint + topDir * range);
		bottomLine.SetPosition (0, bottomPoint);
		bottomLine.SetPosition (1, bottomPoint + bottomDir * range);
	}

	public void UpdatePoints(){
		topPoint = this.transform.position + topOffset;
		bottomPoint = this.transform.position + bottomOffset;
	}

	public Vector3 getNormalOrigin (){
		return new Vector3 (
			this.transform.position.x - sensitivity,
			paddleY,
			this.transform.position.z
		);
	}

}

