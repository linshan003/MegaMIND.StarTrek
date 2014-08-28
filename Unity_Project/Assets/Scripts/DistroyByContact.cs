﻿using UnityEngine;
using System.Collections;

public class DistroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>(); 
		}
		if (gameControllerObject == null)
		{
			Debug.Log("Can't find GameController");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
		if (other.tag == "Player") 
		{
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}


	}
}
