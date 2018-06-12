using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRudiScript : MonoBehaviour {


    public float deathTimer;
	void Start () {
        deathTimer = 60f;
	}
	
	// Update is called once per frame
	void Update () {
        if (deathTimer <= 0)
        {
            Debug.Log("eradicated");
            Destroy(this);
        }
        deathTimer -= Time.deltaTime;
	}
}
