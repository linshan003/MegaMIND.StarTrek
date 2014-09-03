using UnityEngine;
using System.Collections;

public class DestroyByTouch : MonoBehaviour
{
	private PlayerController  playerController ;

	void Start()
	{
		GameObject controller = GameObject.FindWithTag("Player");

		if (controller != null)
		{
			playerController = controller.GetComponent<PlayerController> ();
		}
		if (controller == null)
		{
			Debug.Log("Can not find Player Controller");
		}
						
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") 
		{
			return;
		}
		if (other.tag == "Player")
		{
			Destroy (gameObject);
			playerController.LevelUp();
		}
	}

}
