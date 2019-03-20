using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float rotateSpeed;
	public float dashLength;
	public float maxSpeed;
	public float acceleration;
	public Rigidbody rb;

	void Update () {
		if (Input.GetKey(KeyCode.Z)) Accelerate();
		
		if (Input.GetKeyDown(KeyCode.Q)) DashLeft();
		if (Input.GetKeyDown(KeyCode.D)) DashRight();

		Rotate();		
	}

	void Accelerate () {
		if (rb.velocity.sqrMagnitude<maxSpeed*maxSpeed) rb.AddForce(acceleration*transform.forward);
	}

	void Rotate () {
		transform.rotation *= Quaternion.Euler (0, rotateSpeed*Time.deltaTime*Input.GetAxis("Mouse X"), 0);
	}

	void Dash (bool isLeft) {
		int multiplier = isLeft?-1:1;
		transform.position += multiplier*dashLength*transform.right;
	}

	void DashLeft () {
		Dash (true);
	}

	void DashRight () {
		Dash(false);
	}
}