using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicFadeInController : MonoBehaviour {
	[SerializeField] private int fadeInTime = 3;
	private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	private void Update() {
		if (audioSource.volume < 0.1) {
			audioSource.volume += (Time.deltaTime / (fadeInTime*10));
		} else {
			Destroy(this);
		}
	}
}