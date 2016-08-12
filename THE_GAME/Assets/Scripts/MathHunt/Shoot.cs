﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

	public Transform bulletSpawn;
	public float bulletSpeed = 500.0f;
	public float fireRate;
	private float reloadTimer = 0;
    private int answer;
    public AudioSource source;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update (){
        

		if (Input.GetMouseButtonDown (0) && Time.time > reloadTimer) {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.gameObject.name);

                GameObject scoring = GameObject.Find("Score");
                GameObject questions = GameObject.Find("Questions");
                GameObject controller = GameObject.Find("GameController");
                

                if (hitInfo.transform.gameObject.tag == "bird1")
                {
                    if (hitInfo.transform.gameObject.name == answer.ToString() ) {
                        scoring.SendMessageUpwards("addScore", 10);
                        questions.SendMessageUpwards("updateQuestion");
                        controller.SendMessageUpwards("correctAnswer");
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        controller.SendMessageUpwards("correctAnswer");
                    }

                }
                if (hitInfo.transform.gameObject.tag == "bird2")
                {
                    if (hitInfo.transform.gameObject.name == answer.ToString())
                    {
                        scoring.SendMessageUpwards("addScore", 10);
                        questions.SendMessageUpwards("updateQuestion");
                        controller.SendMessageUpwards("correctAnswer");
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        controller.SendMessageUpwards("correctAnswer");
                    }

                }
                if (hitInfo.transform.gameObject.tag == "bird3")
                {
                    if (hitInfo.transform.gameObject.name == answer.ToString())
                    {
                        scoring.SendMessageUpwards("addScore", 10);
                        questions.SendMessageUpwards("updateQuestion");
                        controller.SendMessageUpwards("correctAnswer");
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        controller.SendMessageUpwards("correctAnswer");
                    }
                }
                if (hitInfo.transform.gameObject.tag == "bird4")
                {
                    if (hitInfo.transform.gameObject.name == answer.ToString())
                    {
                        scoring.SendMessageUpwards("addScore", 10);
                        questions.SendMessageUpwards("updateQuestion");
                        controller.SendMessageUpwards("correctAnswer");
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        controller.SendMessageUpwards("correctAnswer");
                    }
                }
                Destroy(hitInfo.transform.gameObject);

                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
        }

	}

    public void getAnswer(int x)
    {
        this.answer = x;
    }


}
