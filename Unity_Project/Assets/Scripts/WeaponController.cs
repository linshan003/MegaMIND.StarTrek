using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	void Fire()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}


	void Start()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

}
