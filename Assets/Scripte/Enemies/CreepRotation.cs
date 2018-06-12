using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepRotation : MonoBehaviour {


    public GameObject player;
    public GameObject creep;
    public float angle;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        creep = transform.parent.gameObject;
    }

    
    void Update () {
        angle = Mathf.Atan2(creep.transform.position.y, creep.transform.position.x) * Mathf.Rad2Deg;
        creep.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }
}
