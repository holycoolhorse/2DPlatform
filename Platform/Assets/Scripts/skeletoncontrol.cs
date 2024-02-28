using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletoncontrol : MonoBehaviour
{       
    private Animator skeletonanimator;
    [SerializeField] Rigidbody2D player;
    [SerializeField] Rigidbody2D skeleton;
    [SerializeField] float skeletonspeed;
    [SerializeField] float attackdamage;
    [SerializeField] bool focustohero;
    [SerializeField] LayerMask layer1;
    private Vector3 defaultscale;
    private int skeleton_maxhealth=100;
    private int current_health;
 
    
    void Start()
    {

        skeleton = GetComponent<Rigidbody2D>();
        skeletonanimator = GetComponent<Animator>();
        defaultscale = transform.localScale;
        current_health = skeleton_maxhealth;
        
        
    }

    
    void Update()
    {
        #region focustoherobasic
        if (skeleton.transform.position.x > player.transform.position.x)
        {
            skeleton.velocity = new Vector2(-1f, skeleton.velocity.y);
            skeleton.transform.localScale = new Vector3(defaultscale.x, defaultscale.y, defaultscale.z);
            
        }
        else if(skeleton.transform.position.x < player.transform.position.x)
        {
            skeleton.velocity = new Vector2(1f, skeleton.velocity.y);
            skeleton.transform.localScale = new Vector3(-defaultscale.x, defaultscale.y, defaultscale.z);
        }
        #endregion
        #region focustohero
        /*
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f,layer1);
        if (hit.collider != null)
        {
            focustohero = true;
            
        }
        else
        {
            focustohero = false;
            transform.localScale = new Vector3(-defaultscale.x,defaultscale.y,defaultscale.z);
            skeleton.velocity = new Vector2(1f, skeleton.velocity.y);
            hit = Physics2D.Raycast(transform.position, Vector2.right, 20f, layer1);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-20f,0,0));
    }
    */
        #endregion
    }

    public void takedamage(int damage)
    {
        current_health = current_health - damage;

        if (current_health <= 0)
        {
            StartCoroutine(wait());
            
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(gameObject);

    }
    
    
}
