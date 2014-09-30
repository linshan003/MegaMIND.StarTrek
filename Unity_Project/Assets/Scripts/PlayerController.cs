using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
	public float Xmin, Xmax, Zmin, Zmax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawnL, shotSpawnR;
	public float fireRate;

	private float nextFire;
	private float weaponLevel;
	private float delta ;

	void Start()
	{
		weaponLevel = 1;
	    delta = shotSpawnR.position.x - shotSpawnL.position.x ;

	}
	public void LevelUp()
	{
		weaponLevel += 1;
	}

	void Update()
	{
		if ((Input.GetKey ("space")||Input.GetButton ("Fire1")) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate/(1 + weaponLevel/10) ;

			for( int i = 0 ; i <= weaponLevel ; i++)
			{
				Instantiate(shot, new Vector3(shotSpawnL.position.x + i * delta / weaponLevel, 
				                              0.0f, 
				                              shotSpawnL.position.z),
				        /* diverse shotting */    Quaternion.Euler (0.0f, 100 * (i - weaponLevel/2) * delta / weaponLevel,0.0f)
				         //   shotSpawnL.rotation
				            );
			}

		//	Instantiate(shot, shotSpawnL.position, shotSpawnR.rotation);
		//	Instantiate(shot, shotSpawnR.position, shotSpawnR.rotation);
			audio.Play ();
		}
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed; 


		// Input in android pad.
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(-touchDeltaPosition.x * speed, 0.0f,  -touchDeltaPosition.y * speed);
		}


		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.Xmin, boundary.Xmax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.Zmin, boundary.Zmax)
		   );
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	 }
}
