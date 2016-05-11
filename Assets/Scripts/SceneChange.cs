﻿using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			StartCoroutine (ChangeLevel ());
		}
	}

	IEnumerator ChangeLevel () {
		float fadeTime = GetComponent<LevelFader> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
