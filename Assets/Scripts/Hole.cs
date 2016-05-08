﻿using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
	
	public GameObject respawnPoint;

	private bool containsSpawner;
	private GameObject cloneSpawner;

	void Start() {
		if (!respawnPoint) {
			respawnPoint = GameObject.FindGameObjectWithTag ("Respawn");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			GameObject player = other.gameObject;

			player.GetComponent<PlayerControl> ().RespawnAt (respawnPoint.transform.position);
		
		} else if (other.gameObject.CompareTag ("Clone")) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");

			player.GetComponent<CloneAbility> ().DestroyClone ();
		
		} else if (other.gameObject.CompareTag ("CloneSpawner")) {
			cloneSpawner = other.gameObject;

		}
	}

	void OnTriggerStay() {
		// Relies on fact clone spawner is destroyed when clone spawns
		if (containsSpawner && cloneSpawner == null) {
			GameObject clone = GameObject.FindGameObjectWithTag ("Clone");

			Destroy (clone); // assumes only one clone

			containsSpawner = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("CloneSpawner")) {
			containsSpawner = false;
			cloneSpawner = null;
		}
	}
}
