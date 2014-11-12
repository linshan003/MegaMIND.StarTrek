using UnityEngine;
using System.Collections;

public class DistroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;
	public int health;
	private int shootCount ;

	void Start()
	{
		shootCount = 1;
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


			
		if (other.tag == "Boundary" || other.tag == "Enemy")
						{
							return;
						}
						
		else if (other.tag == "Player") 
						{
							Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
							gameController.GameOver ();
						}
		else if (shootCount < health)
		{
			shootCount += 1; 
			Destroy(other.gameObject);
			return;
		} 
						Instantiate (explosion, transform.position, transform.rotation);
						gameController.AddScore (scoreValue);
						Destroy (other.gameObject);
						Destroy (gameObject);
	}

			
		

}
