using UnityEngine;
using System.Collections;

public class AIBehavior : MonoBehaviour {
	public float walkingSpeed = 5.0f;
	public float rotationRange = 110.0f;

	private Rigidbody _rigidbody;
	private bool turning;

	// Use this for initialization
	void Start () {
		turning = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, walkingSpeed * Time.deltaTime);

		int delay = 2;
		if (System.DateTime.Now.Second % delay == 0 && !turning) {
			turning = true;
			float angle = Random.Range(-rotationRange, rotationRange);
			transform.Rotate(0, angle, 0);
		} else if (System.DateTime.Now.Second % delay == 1) {
			turning = false;
		}


	}
}
