using UnityEngine;
using System.Collections;

public class ParentLevelClass : MonoBehaviour {
	public float playerSpeed = 1.0f;
	public float levelDistance;

	private GameObject _player;
	private PlayerBehavior _playerBehavior;
	private bool runningLevel = false;

	//************ INITIALIZATION **************//
	// This sets up how long the level is 
	void levelSetUp() {
		if (levelDistance < 20.0f) {
			levelDistance = 20.0f;
		}

		Transform floor = gameObject.transform.FindChild ("Floor");
		floor.localScale += new Vector3 (0, 0, levelDistance);
		floor.Translate (0, 0, (levelDistance / 2.0f) - 1);

		Transform walls = gameObject.transform.FindChild ("Walls");
		walls.localScale += new Vector3 (0, 0, levelDistance);
		walls.Translate (0, 0, (levelDistance / 2.0f) - 1);

		Transform endTrigger = gameObject.transform.FindChild ("World/EndTrigger");
		endTrigger.localScale += new Vector3 (5.0f, 4.0f, 0);
		endTrigger.Translate (0, 0, (levelDistance - 2));
	}

	// Use this for initialization
	void Start () {
		_player = GameObject.Find ("/Player");
		_playerBehavior = _player.GetComponent<PlayerBehavior> ();

		if (playerSpeed == 0) {
			playerSpeed = 1.0f;
		}
		playerSpeed *= _playerBehavior.walkingSpeed / 50.0f;

		levelSetUp ();
	}
	
	//************ CONTINUOUS **************//
	// Update is called once per frame
	void Update () {
		if (runningLevel) {
			// TODO: use the player movement rather than just transforming their pos
			_player.transform.Translate(new Vector3(0, 0, playerSpeed), gameObject.transform);
		}
	}

	public void StartLevel (Collider collider) {
		runningLevel = true;
	}

	public void EndLevel (Collider collider) {
		runningLevel = false;
		_player.transform.position = new Vector3 (0, 0, 0);
	}
}
