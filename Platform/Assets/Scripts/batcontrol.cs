using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batcontrol : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(!(collision.gameObject.tag == "player"))
        {
            Destroy(gameObject);
            if (collision.gameObject.CompareTag("enemy"))
            {
                collision.gameObject.GetComponent<skeletoncontrol>().takedamage(20);
            }
        }

    }
}
