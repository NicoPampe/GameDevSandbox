using UnityEngine;
using System.Collections;

public class ParentLevelClass : MonoBehaviour {
	public float playerSpeed = 1.0f;	

	private GameObject _player;
	private PlayerBehavior _playerBehavior;
	private bool runningLevel = false;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find ("/Player");
		_playerBehavior = _player.GetComponent<PlayerBehavior> ();

		if (playerSpeed == 0) {
			playerSpeed = 1.0f;
		}
		playerSpeed *= _playerBehavior.walkingSpeed / 50.0f;
	}
	
	public void StartLevel (Collider collider) {
		runningLevel = true;
	}

	// Update is called once per frame
	void Update () {
		if (runningLevel) {
			// TODO: use the player movement rather than just transforming their pos
			_player.transform.Translate(new Vector3(0, 0, playerSpeed), gameObject.transform);
		}
	}
}
