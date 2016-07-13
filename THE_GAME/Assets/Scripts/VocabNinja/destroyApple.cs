using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class destroyApple : MonoBehaviour
{

    private bool slice;

    private Rigidbody2D myRigidbody;

   


    // Use this for initialization
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision name" + col.gameObject.tag);

        if (col.gameObject.tag == "weapon")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }

        
        
    }
    /*
    public void Slice(bool slice)
    {
        if (slice == true)
        {
            gameObject.GetComponent<Animation>().Play("SlicedApple");
        }
    }
   */

    //Delete the knife after it leaves the visable region
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
