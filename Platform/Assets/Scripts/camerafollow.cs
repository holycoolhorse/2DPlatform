using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{       
    [SerializeField] GameObject player ;
    private Vector3 aradakifark;
    
    
    void Start()
    {
        aradakifark = transform.position - player.transform.position;
        
    }

    
    void Update()
    {
        transform.position = player.transform.position + aradakifark;
        
    }
}
