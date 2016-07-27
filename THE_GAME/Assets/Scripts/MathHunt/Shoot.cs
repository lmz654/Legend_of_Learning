using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

	public Rigidbody bullet;
	public Transform bulletSpawn;
	public float bulletSpeed = 500.0f;
	public float fireRate;
	private float reloadTimer = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update (){


		if (Input.GetMouseButtonDown (0) && Time.time > reloadTimer) {
			reloadTimer = Time.time + fireRate;
			Rigidbody bull;
			transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Camera.main.ScreenToWorldPoint (Input.mousePosition);
			bull = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody;
			bull.AddForce (bulletSpawn.forward * bulletSpeed);
			Destroy (bull.gameObject, 2);
		}



	}
}
