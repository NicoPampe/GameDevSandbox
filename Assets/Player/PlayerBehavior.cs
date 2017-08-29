using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public float walkingSpeed = 3.0f;
	public float gravity = -9.8f; // Gravity in Games needs to be tweaked to 'look' more natural
	public float jumpSpeed = 15.0f;
	public float terminalVel = -10.0f;
	public float minFall = -1.5f;
	
	private CharacterController _charController;
	private float _vertSpeed;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
		_vertSpeed = minFall;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * walkingSpeed;
		float deltaZ = Input.GetAxis ("Vertical") * walkingSpeed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, walkingSpeed);

		if (_charController.isGrounded) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				_vertSpeed = jumpSpeed;
			} else {
				_vertSpeed = minFall;
			}
		} else {
			_vertSpeed += gravity * 5 *Time.deltaTime;
			_vertSpeed = Mathf.Clamp(_vertSpeed, terminalVel, Mathf.Infinity);
		}
		movement.y = _vertSpeed;

		movement *= Time.deltaTime; // Needed for differnt computer settings
		movement = transform.TransformDirection (movement);
		_charController.Move (movement);
	}
}
