using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// diese klasse soll nur leben und sterbeanimationen ect enthalten.
public class CreepsAttributes : MonoBehaviour {

   [Header("CreepAttributes")]
    public float startHealth;
    public float health;
    public int movementSpeed;
    public int attackRange;
    public int creepDmg;
    public Collider2D meleeCollider2D;
    bool AttackIsEnabled;
    public PlayerController player;
    public int rewardExperience;


    [Header("Unity Stuff")]   
    public GameObject deathEffect;
    public GameObject attackArm;
    public Image healthBar;
    public AudioSource getHitAudio;
    


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerController>();
         startHealth = player.playerLevel;
        health = startHealth;
        attackArm = transform.Find("AttackSword").gameObject;
        if (creepDmg == 30)
        {
            startHealth = player.playerLevel * 20;
            health = startHealth;
        }
    }
	
	// Update is called once per frame
	void Update () {
        updateHealthbar();
       
	}
    

    //Methode um dieser Creature schaden zuzufügen
    public void applyDmg(int x)
    {       
       health = health - x;        
        getHitAudio.Play();
    }    

    // methode die den tot controlliert
    public void updateHealthbar()
    {
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            player.playerExp += rewardExperience;
            
            GameObject effectIns = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effectIns, 1f);
            GameObject bloodBrudi = (GameObject)Instantiate(Resources.Load("Prefabs/BloodBrudi"), transform.position, transform.rotation);
            Destroy(gameObject);
          


            return;
        }

    } 

}
