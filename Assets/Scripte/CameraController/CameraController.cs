using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
   public Vector2 mouseInp;
  public  Vector2 playerPosition;

  public float maxScreenPoint = 0.8f;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Start () {
        //transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);
        //Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) / 2f;
        Vector3 position = (player.transform.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;
        Vector3 destination = new Vector3(position.x, position.y, -10);

        if (Vector2.Distance(GetComponent<Camera>().ScreenToWorldPoint(mousePos), player.transform.position) >=2)
        { 
            
             destination = new Vector3(position.x, position.y, -10);
        }
        else
        {
             destination = new Vector3(player.transform.position.x,player.transform.position.y, -10);
        }
        
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothTime);
    }
}
