using UnityEngine;
using System.Collections;

public class DeathByTime : MonoBehaviour {

	public float timeDeath;

	private Vector2 direction;
	private float speed;

	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		Destroy (gameObject, timeDeath);
	}

	void FixedUpdate(){
		myRigidbody.velocity = direction * speed;
	}

	public void Initialize(Vector2 direction, float speed){
		this.direction = direction;
		this.speed = speed;
	}
}
