using UnityEngine;
using System.Collections;

public class levelTriggers : MonoBehaviour {
	void OnTriggerEnter(Collider c) {
		gameObject.GetComponentInParent<levelBehavior> ().StartLevel (c);
	}
}
