using UnityEngine;
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
        Debug.Log(Time.time);

		if (Input.GetMouseButtonDown (0) && Time.time > reloadTimer) {
            Debug.Log("Clicked");
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.gameObject.name);

                GameObject scoring = GameObject.Find("Score");
                GameObject questions = GameObject.Find("Questions");
                

                if (hitInfo.transform.gameObject.tag == "bird1")
                {
                    //if (answer == hitInfo.transform.gameObject.tag ) {
                        scoring.SendMessageUpwards("addScore", 10);
                    //}
                    
                    //points.addScore (10);
                }
                if (hitInfo.transform.gameObject.tag == "bird2")
                {
                    scoring.SendMessageUpwards("addScore", 20);
                    //points.addScore (20);
                }
                if (hitInfo.transform.gameObject.tag == "bird3")
                {
                    scoring.SendMessageUpwards("addScore", 30);
                    //points.addScore (30);
                }
                if (hitInfo.transform.gameObject.tag == "bird4")
                {
                    scoring.SendMessageUpwards("addScore", 40);
                    //points.addScore (40);
                }
                gameObject.GetComponent<AudioSource>().Play();
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
