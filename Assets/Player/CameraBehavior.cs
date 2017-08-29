using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	CursorLockMode wantedMode;

	private Camera _camera;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
	}
	
	// Apply requested cursor state
	void SetCursorState()
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}
	
	void OnGUI()
	{
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/4;
		GUI.Label (new Rect (posX, posY, size, size), "*");

		Cursor.lockState = wantedMode = CursorLockMode.None;
		wantedMode = CursorLockMode.Locked;
		
		SetCursorState();
	}
}
