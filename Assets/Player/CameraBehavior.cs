using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	CursorLockMode wantedMode;

	private Camera _camera;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			RayShooter();
		}
	}

	// World interaction Raycasting
	void RayShooter() {
		Vector3 middlePoint = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
		Ray ray = _camera.ScreenPointToRay (middlePoint);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			Renderer hitObjRend = hitObject.GetComponent<Renderer>();
//			Material hitObjMaterial = hitObject.GetComponent<Material>();
			Debug.Log("hit " + hitObject.name);
			Debug.Log(hitObjRend.material.color);
//			Debug.Log("color: " + hitObjMaterial.GetColor("_Color"));
//			hitObjMaterial.SetColor("
			hitObjRend.material.color = Color.cyan;
		};
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
