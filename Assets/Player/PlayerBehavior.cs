using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public float walkingSpeed = 3.0f;
	public float gravity = -9.8f; // Gravity in Games needs to be tweaked to 'look' more natural

	private CharacterController _charController;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * walkingSpeed;
		float deltaZ = Input.GetAxis ("Vertical") * walkingSpeed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, walkingSpeed);

		movement.y = gravity;

		movement *= Time.deltaTime; // Needed for differnt computer settings
		movement = transform.TransformDirection (movement);
		_charController.Move (movement);
	}
}
