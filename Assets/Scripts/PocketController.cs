using UnityEngine;

public class PocketController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter(Collider other){
		print("TRIGGERED");
		if(other.gameObject.CompareTag("Player")) // this string is your newly created tag
		{
			var player = other.gameObject;
			Destroy(player);
		}
	}

	private void OnCollisionEnter(Collision other) {
		print("COLLIDED");
	}

	private void OnTriggerStay(Collider other) {
	}

	private void OnTriggerExit(Collider other) {
	}
}
