using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepRunning : MonoBehaviour {

    public GameObject player;
    public GameObject creep;
    public Animator brudiAnimator;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        creep = transform.parent.gameObject;
    }
        
	
	// Update is called once per frame
	void Update () {        


        if(Vector2.Distance(player.transform.position, creep.transform.position) < 0.65f)
        {
           brudiAnimator.SetBool("inRange",true);
            
        }
        else
        {
           
            creep.transform.Translate(Vector2.up * creep.GetComponent<CreepsAttributes>().movementSpeed * Time.deltaTime);
            brudiAnimator.SetBool("inRange", false);
        }
        
       
	}
}
