using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    // copied attributes
    public GameObject impactEffect;    

    public int arrowDmg;
    public float projectileVelocity;
    public Vector2 shootingDirection;



    //-----------------------------
    public PlayerController player;

    public Vector2 direction;



    void Start()
    {
        
        player = FindObjectOfType<PlayerController>();

        arrowDmg = player.arrowDmg;
        projectileVelocity = player.arrowSpeed;

        shootingDirection = player.shootDirection;
        
    }

    void Update()
    {

        // forwardsmovement for the arrow    
        moveForward();

        if (player != null) { 
            if(Vector2.Distance(transform.position,player.transform.position)>=10)
            {
                Destroy(gameObject);
                return;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkForHit(collision);       
    }

    public void checkForHit(Collider2D collisionTarget)
    {
        if(collisionTarget.tag=="Creep"|| collisionTarget.tag == "Wall")
        {             
            HitValidTarget(collisionTarget);
        }
    }
    public void moveForward()
    {
        transform.Translate(Vector2.up * projectileVelocity * Time.deltaTime, Space.Self);
    }

    public void HitValidTarget(Collider2D collisionTarget)
    {
        collisionTarget.GetComponent<CreepsAttributes>().applyDmg(arrowDmg);
        GameObject effectIns= (GameObject)  Instantiate(impactEffect,transform.position, transform.rotation);       
        
        Destroy(effectIns,1f);
        Destroy(gameObject);
        
    }
}


 
