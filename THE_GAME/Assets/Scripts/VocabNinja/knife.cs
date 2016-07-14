﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class knife : MonoBehaviour {

    [SerializeField]
    private float speed;
    bool facingRight;

    private Rigidbody2D myRigidbody;

    private Vector2 direction;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

     void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("collision with " + col.gameObject.name);
        if (col.gameObject.name != "Ninja Girl")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        
    }



    //Delete the knife after it leaves the visable region
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
