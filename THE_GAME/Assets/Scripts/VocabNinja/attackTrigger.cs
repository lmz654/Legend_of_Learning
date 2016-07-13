using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

    public bool dmg;
/*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Apple"))
        {
            dmg = true;
            col.SendMessageUpwards("Slice", dmg);
        }
    }
*/
}
