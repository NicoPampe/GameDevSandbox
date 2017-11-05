using UnityEngine;
using System.Collections;

public class ParentLevelClass : MonoBehaviour {
	public float playerSpeed = 1.0f;
	public float levelDistance;

	private GameObject _player;
	private bool runningLevel = false;
	private PlayerBehavior _playerBehavior;

	// Prefabs
	[SerializeField] private GameObject endWallPrefab;
	private GameObject _backWall;

	//************ INITIALIZATION **************//
	// This sets up how long the level is 
	void levelSetUp() {
		if (levelDistance < 20.0f) {
			levelDistance = 20.0f;
		}

//		_backWall = Instantiate (endWallPrefab) as GameObject;
//		_backWall.transform.parent = transform;
//		_backWall.transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2 + (levelDistance / 2.0f));
			
		Transform floor = gameObject.transform.Find ("Floor");
		floor.localScale += new Vector3 (0, 0, levelDistance + 4);
		floor.Translate (0, 0, ((levelDistance + 4) / 2.0f) - 1);

		Transform walls = gameObject.transform.Find ("Walls");
		walls.localScale += new Vector3 (0, 0, levelDistance);
		walls.Translate (0, 0, (levelDistance / 2.0f) - 1);

		Transform backWall = gameObject.transform.Find ("BackWall");
		backWall.Translate (0, 0, levelDistance - 1);

		Transform endTrigger = gameObject.transform.Find ("World/EndTrigger");
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
