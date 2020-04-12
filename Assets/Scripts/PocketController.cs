using UnityEngine;

public class PocketController : MonoBehaviour {

	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D other) {
        print("POCKET");
		if(other.gameObject.CompareTag("Player")) {
			var player = other.gameObject;
			Destroy(player);
		}
	}

}
