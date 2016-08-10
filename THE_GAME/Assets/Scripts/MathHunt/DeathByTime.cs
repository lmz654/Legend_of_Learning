using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class DeathByTime : MonoBehaviour {

    private int answer;

	[SerializeField]
	private float speed = 10;
	public float timeDeath;
	private Vector2 direction;

	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, timeDeath);
	}

	void FixedUpdate(){
		myRigidbody.velocity = direction * speed;
	}

	public void Initialize(Vector2 direction){
		this.direction = direction;
	}

}
