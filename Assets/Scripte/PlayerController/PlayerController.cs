using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Vectors")]
    Vector3 mousePos;
    Vector3 objectPos;
   // Vector2 Position;

        
    public Vector2 shootDirection;

    // [Header("GameObjectReferences")]
    // public GameObject player;


    [Header("Attributes/Varriables")]
    public float health;
    public float startHealth;

    float angle;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    

    


    [Header("UnityStuff")]
    public Image healthbar;
    public Image expBar;
    public GameObject PlayerDeathParticels;
    public SpriteRenderer rend;
    public Levelsystem levelSystem;
    public AudioSource shotAudio;
   

    
       
    

    

    [Header("LevelSystem")]
    public int arrowSpeed;
    public int arrowDmg;
    public int playerLevel;
    public float playerExp ;
    public int expDoublePoint = 4;
    public int numberOfArrows;
    
    
    

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        arrowSpeed=1;
        arrowDmg=1;
        playerLevel = 1;
    // player = GameObject.FindGameObjectWithTag("Player");
    // Position= new Vector2(transform.position.x,transform.position.y);
        health = startHealth;
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = true;
        numberOfArrows=1;

    }

    // Update is called once per frame
    void Update()
    {

       
        lookToCurser();
        fire();
        updateHealthbar();
        upDateExpBar();
        endGameInSlowmo();
        checkForQuit();
        
    }




  //  feuert wen cooldown vorhanden einen pfeil ab.
    public void fire()
    {

        if (fireCountdown <= 0f && Input.GetMouseButton(0))
        {
            shotAudio.Play();
                var number = 90 / numberOfArrows;
                for (int i = 0; i < numberOfArrows; i++)
                {

                    if (numberOfArrows == 1)
                    {
                        
                        GameObject singleArrow = (GameObject)Instantiate(Resources.Load("Prefabs/Arrow"), transform.position, transform.rotation);
                        singleArrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
                    }
                    else
                    {
                        GameObject arrow = (GameObject)Instantiate(Resources.Load("Prefabs/Arrow"), transform.position, transform.rotation);
                        arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90 + 25+i - (number * i)));
                    }
                }
            

            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }


   // instantiert einen Pfeil Prefab
    public void instantiateArrow()
    {
        shootDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        GameObject arrow = (GameObject)Instantiate(Resources.Load("Prefabs/Arrow"), transform.position, transform.rotation);
        arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

       // Debug.DrawLine(transform.position, new Vector3(mousePos.x, mousePos.y, 0), Color.red);
    }



    // lockt die rotation des cursers auf die mausposition.    
    public void lookToCurser()
    {
        mousePos = Input.mousePosition;
       // mousePos.z = player.transform.position.z;

        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;    
        //-------------------------------

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

     

     //   Debug.DrawLine(transform.position,new Vector3(mousePos.x, mousePos.y, 0) ,Color.red);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }



    // methode um dem Spieler schaden zuzufügen
    public void applyDmg(int x)
    {
        health = health - x;
        Debug.Log(health);
    }


    // methode fürs leben und die lebensanzeige.
    public void updateHealthbar()
    {
        healthbar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            GameObject effectIns = (GameObject)Instantiate(PlayerDeathParticels, transform.position, transform.rotation);
            Destroy(effectIns, 1f);
            
           // Destroy(gameObject);
            return;
        }

    }


    //upgraded die exp Bar und level den spieler wenn er genug einheitne getötet hat. Erhöht auch die exp anfordungern alle paar level.
    public void upDateExpBar()
    {
       
       expBar.fillAmount = playerExp / levelSystem.thisLvLUpExp;

        if (playerExp >= levelSystem.thisLvLUpExp)
        {
            levelSystem.playerLevelUp();
            playerExp -= levelSystem.thisLvLUpExp;
            playerLevel++;            
            if (playerLevel % expDoublePoint == 0)
            {
                levelSystem.thisLvLUpExp *= 2;
               // Debug.Log("ExpGotDoubled");
            }
        }
    }


    // verlangsamt alles bis zum stillstand wenn man stirb
    public void endGameInSlowmo()
    {
        if (Time.timeScale >= 0&& health<=0)
        {                   
            if(Time.timeScale<=0.1f)
            {
                SceneManager.LoadScene("DatScene");


                return;
            }
            Time.timeScale=Time.timeScale-0.1f;

         
            
        }
    }

    public int getPlayerLevel()
    {
        return playerLevel;
    }


    // shoots arrows into all directions but is dissabled in the game
    public void arrowVolley()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var number = 360 / numberOfArrows;
            for (int i=0; i<numberOfArrows;i++)
            {

                GameObject arrow = (GameObject)Instantiate(Resources.Load("Prefabs/Arrow"), transform.position, transform.rotation);
                arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90 - (number*i)));
            }
        }
    }

    public void checkForQuit()
    {
        
            if (Input.GetKey("escape"))
                Application.Quit();

    }


}
