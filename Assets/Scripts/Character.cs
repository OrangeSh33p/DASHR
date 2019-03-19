using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float rotateSpeed;
	public float dashLength;
	public float minSpeed;
	public float maxSpeed;
	public float currentSpeed;
	public float acceleration;
	public float deceleration;
	public float stopping;

	void Update () {
		if (Input.GetKey(KeyCode.Z)) {
			currentSpeed = Mathf.Min(currentSpeed + acceleration*Time.deltaTime, maxSpeed);
		} else if (Input.GetKey(KeyCode.S)) {
			currentSpeed = Mathf.Max(currentSpeed-Time.deltaTime*stopping, minSpeed);
		}
		else {
			currentSpeed = Mathf.Max(currentSpeed-Time.deltaTime*deceleration, minSpeed);
		}
		Move ();
		Rotate();
		if (Input.GetKeyDown(KeyCode.Q)) DashLeft();
		if (Input.GetKeyDown(KeyCode.D)) DashRight();
	}

	void Move () {
		transform.position += currentSpeed*Time.deltaTime*transform.forward;
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
