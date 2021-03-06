﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class destroyApple : MonoBehaviour
{
    public int scoreValue = 10;
    private bool slice;

    private Rigidbody2D myRigidbody;
    //Animator anim;


    // Use this for initialization
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision name" + col.gameObject.name);

        if (col.gameObject.tag == "Ground")
        {
            //anim.SetInteger("state",1);
            Destroy(gameObject);
            
        }    
    }

    public void Slice(bool slice)
    {
        if (slice == true)
        {
            GetComponent<Animator>().enabled = true;
            //Destroy(gameObject);
        }
    }

    //Delete the knife after it leaves the visable region
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
