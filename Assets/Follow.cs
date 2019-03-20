using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	public Transform target;
	[Range(0,1)]
	public float smoothness;
	Quaternion originRot;
	Vector3 originPos;
	public Transform cameraTransform;

	void Start () {
		originRot = transform.rotation;
		originPos = transform.position;
	}

	void Update () {
		Vector3 targetPos = originPos + new Vector3 (target.position.x, 0, target.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, 1-smoothness);

		transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation*originRot, smoothness);
	}
}