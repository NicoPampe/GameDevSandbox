﻿using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MosueY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minVert = -45.0f;
	public float maxVert = 45.0f;

	private float _rotationX = 0;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null) {
			body.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		print (axes == RotationAxes.MouseX);
		if (axes == RotationAxes.MouseX) {
			// This never seems to be true...
			// transform.Rotate (0, sensitivityHor, 0);
		} else if (axes == RotationAxes.MosueY) {
			// This never seems to be true...
		} else {
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}
