using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class destroyApple : MonoBehaviour
{

   

    private Rigidbody2D myRigidbody;



    // Use this for initialization
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
    }


    public void Slice(bool slice)
    {
        if (slice == true)
        {
            gameObject.GetComponent<Animation>().Play("SlicedApple");
        }
    }


    //Delete the knife after it leaves the visable region
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
