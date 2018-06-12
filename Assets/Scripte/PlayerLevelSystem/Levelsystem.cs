using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelsystem : MonoBehaviour
{
    public GameObject canvasRef;
    public PlayerController player;
    public float thisLvLUpExp;
    
    public bool enableInput;


    private bool isShowing;

    private void Start()
    {
        thisLvLUpExp = 3;
        enableInput = false;
        isShowing = false;
        canvasRef.SetActive(isShowing);
    }

    void Update()
    {
        checkForEnable();
    }
    


    public void toggleLevelGUI()
    {

        enableInput = !enableInput;
        isShowing = !isShowing;
        canvasRef.SetActive(isShowing);
    }

    public void playerLevelUp()
    {
            toggleLevelGUI();              
    }

    public void checkForEnable()
    {

        if (enableInput == true)

        {

            if (Input.GetKey(KeyCode.Alpha1))
            {

                player.numberOfArrows++;
                toggleLevelGUI();
                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                
                player.arrowDmg += 1;
                toggleLevelGUI();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                
                player.arrowSpeed += 1;
                player.fireRate += 1;
                toggleLevelGUI();
            }

        }
    }

}
