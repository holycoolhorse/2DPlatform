using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float max_health = 100;
    private float current_health;
    public Animator myanimator;
    private float jumpspeed=5;
    [SerializeField] GameObject bat;
    private float speedx;
    private Vector3 defaultscale;
    private Rigidbody2D MyBody;
    public bool onground;
    private bool doublejump;
    [SerializeField] float attacktimer;
    public float defaulttimer = 2;
    [SerializeField] bool attacked;
    public bool touch;
    public Text health;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        myanimator = GetComponent<Animator>();
        MyBody = GetComponent<Rigidbody2D>();
        defaultscale = transform.localScale;
        current_health = max_health;
        
    }





    // Update is called once per frame
    void Update()
    {
        
        myanimator.SetBool("onground", onground);
        #region Horizontal Speed 
        speedx = Input.GetAxis("Horizontal");
        MyBody.velocity = new Vector2(7 * speedx, MyBody.velocity.y);
        myanimator.SetFloat("speed", Mathf.Abs(speedx));
        #endregion
        #region Face Swap
        if (speedx > 0)
        {
            transform.localScale = new Vector3(defaultscale.x, defaultscale.y, defaultscale.z);
        }
        else if (speedx<0) 
        {
            transform.localScale = new Vector3(-defaultscale.x, defaultscale.y, defaultscale.z);
        }
        #endregion
        #region Vertical Speed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (onground == true)
            {
                myanimator.SetTrigger("jump");
                MyBody.velocity = new Vector2(MyBody.velocity.x, jumpspeed);
                doublejump = true;
                
            }
            else 
            {
                if(doublejump == true)
                {
                    myanimator.SetTrigger("jump");
                    MyBody.velocity = new Vector2(MyBody.velocity.x, jumpspeed);
                    doublejump = false;

               
                }
            }
            

        }
        
        #endregion

        
        #region throw bat
        void throwbat() { 
            
            GameObject mybat = Instantiate(bat, transform.position, Quaternion.identity);
            
            if (transform.localScale.x > 0)
            {
                mybat.GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 0f);
            }
            else if(transform.localScale.x < 0)
            {
                Vector3 batlocalscale = mybat.transform.localScale;
                mybat.transform.localScale = new Vector3 (-batlocalscale.x, batlocalscale.y, batlocalscale.z);
                mybat.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {   
            
            if (attacked == false)
            {   
                myanimator.SetTrigger("throwbat");
                attacked = true;
                throwbat();
                
                
            }
        
        }
        if (attacked == true)
        {
            attacktimer += Time.deltaTime;
            if (attacktimer >= defaulttimer)
            {
                attacked = false;
                attacktimer = 0;
            }
        }

        #region attack animation
        if (Input.GetKeyDown(KeyCode.Z))
        {
            myanimator.SetTrigger("fight");
        }
        #endregion

        




        #endregion
    }
    public void takedamageplayer(int damage)
    {
        current_health = current_health - damage;
        health.text=current_health.ToString();
        if (current_health <= 0)
        {
            myanimator.SetTrigger("die");
        }
    }

    

    
}
