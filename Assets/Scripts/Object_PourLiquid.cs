﻿using UnityEngine;
using System.Collections;

public class Object_PourLiquid : MonoBehaviour {
	private GameObject particleSystem;
	private bool isBottleFilled;
	private float bottleContent;
	private bool isPlayingSound;

	void Start () {
		particleSystem = this.gameObject.transform.FindChild ("PourParticle").gameObject;
		particleSystem.SetActive (false);
		isBottleFilled = true;
		bottleContent = 5f;
		isPlayingSound = false;
	}

	void Update () {
		if (particleSystem.activeInHierarchy) {
			bottleContent -= Time.deltaTime;
			if (bottleContent < 0) {
				isBottleFilled = false;
			}
		}


		if (Vector3.Dot (transform.up, Vector3.down) > 0 && isBottleFilled){
			particleSystem.SetActive (true);
			if (!this.GetComponent<AudioSource>().isPlaying) {
				this.GetComponent<AudioSource>().Play ();
			}

		} else {
			particleSystem.SetActive (false);
			if (this.GetComponent<AudioSource>().isPlaying) {
				this.GetComponent<AudioSource>().Stop ();
			}

		}
	}
}
