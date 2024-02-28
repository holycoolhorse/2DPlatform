using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytouch : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            player.GetComponent<Animator>().SetTrigger("touch");
            player.GetComponent<PlayerController>().takedamageplayer(1);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
