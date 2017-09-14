using UnityEngine;
using System.Collections;

public class levelTriggers : MonoBehaviour {
	public enum TriggerType {
		Start = 0,
		End = 1
	}
	public TriggerType trigType = TriggerType.Start;

	void OnTriggerEnter(Collider c) {
		if (trigType == TriggerType.Start) {
			Debug.Log(gameObject.transform.position);
			gameObject.GetComponentInParent<levelBehavior> ().StartLevel (c);
		} else if (trigType == TriggerType.End) {
			gameObject.GetComponentInParent<levelBehavior> ().EndLevel(c);
		}
	}
}
