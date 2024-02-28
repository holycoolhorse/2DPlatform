using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordattack : MonoBehaviour
{
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    private int attackdamage = 40;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            attack();
        }
    }

    void attack()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position , attackrange, enemyLayers);

        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<skeletoncontrol>().takedamage(attackdamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(100f);

    }
}
