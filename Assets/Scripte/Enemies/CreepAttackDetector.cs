using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAttackDetector : MonoBehaviour {

    public GameObject target;
    public CreepsAttributes creepsAtt;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public int dmg;
    public int memberSpeed;

    public AudioSource AttackSound;

    public Animator BrudiAnimator;
    


	
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        dmg = GetComponentInParent<CreepsAttributes>().creepDmg;
        creepsAtt = GetComponentInParent<CreepsAttributes>();
        memberSpeed = creepsAtt.movementSpeed;
        AttackSound = GetComponent<AudioSource>();
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        
            if (other.tag == "Player")
            {
                creepsAtt.movementSpeed = 0;
                if (fireCountdown <= 0f)
                {
                    AttackSound.Play();
                    other.GetComponentInChildren<PlayerController>().health = other.GetComponentInChildren<PlayerController>().health - dmg;
                    BrudiAnimator.SetTrigger("AttackTrigger");
                    fireCountdown = 1f / fireRate;
                }
                fireCountdown -= Time.deltaTime;
            }
            creepsAtt.movementSpeed = memberSpeed;

        
        


    }   
    
}
