using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{

    public PlayerController player;
    public int spawnCase;
    public float spawnTimer;
    public float spawnRate;
    public float changeLevel;
    public float levelTimer;
   


    public int numberToSpawn;
  //  public Vector2[] spawnPoint;
    public List<Vector2> spawnPoints;





    Vector2 savePosition;
    Vector2 additionalPosition;


    public GameObject PrefabCreep;
    public GameObject PrefabHulk;
    public GameObject PrefabSpeedy;
    





    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spawnCase = 1;
        levelTimer = 30;
       


    }


    Vector2 newRandomCircle(Vector2 center, float radius, int _numberToSpawn)
    {
        spawnPoints.Clear();
        Vector2 pos;
        float ang = Random.value * 360;
        for (int i = 0; i < numberToSpawn; i++)
        {
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            savePosition = pos;
            spawnPoints.Add(pos);
           // spawnPoint[i] = pos;
          //  Debug.Log("Added to Array Position" + i);
           
        }
        return savePosition;
    }

 

    private void Update()
    {
        checkForWave();
    }

    public void startLevel(float _spawnRate,int _numberToSpawn,float nextLevelTimer,bool hulkTimer)
    {
        spawnRate = _spawnRate;
        numberToSpawn = _numberToSpawn;

        if (spawnCase >= 15)
        {
            spawnRate = Random.Range(1f, 5f);
            numberToSpawn = Mathf.RoundToInt(Random.Range(1f, 20f));
        }


        if (spawnTimer <= 0f)
        {

            spawnTimer = spawnRate;

            var pos = newRandomCircle(new Vector2(0, 0), 13f, numberToSpawn);
            foreach (Vector2 o in spawnPoints)
            {
                Instantiate(PrefabCreep, pos, Quaternion.identity);
               
            }
            if (hulkTimer==true)
            {
                Instantiate(PrefabHulk, pos, Quaternion.identity);
                if (levelTimer> 1000)
                {
                    numberToSpawn++;
                }
            }
        }       

        if (levelTimer <= 0f)
        {           
            spawnCase++;
            levelTimer =nextLevelTimer;
          //  Debug.Log("nextLevel");
        }

        spawnTimer -= Time.deltaTime;
        levelTimer -= Time.deltaTime;
    }

  








    //  public void startLevel          (float _spawnRate       ,int _numberToSpawn       ,float nextLevelTimer      ,float hulkTimer)

    public void checkForWave() { 
        switch (spawnCase)
        {


            ///-----------------------------------------------Level 1-------------------------------/////
            case 1:
                startLevel(5, 1, 30,false);
                break;


///-------------------------------------------------Level 2---------------------------------------------------///////
            case 2:
                startLevel(5, 2, 10,false);
                break;

            case 3:
                startLevel(10, 10, 60,false);
                break;
            case 4:
                startLevel(1, 2,15,false);
                break;
            case 5:

                startLevel(10,0,5,true);
                
                break;
            case 6:
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(PrefabSpeedy, new Vector3(10, 10, 0), Quaternion.identity);
                }
                spawnCase++;
               

                break;
            case 7:
               
                startLevel(10,35, 5, false);
                break;


            case 8:
                startLevel(6,15, 20, true);               
                break;

            case 9:
                startLevel(2, 15, 10, false);
                break;
            case 10:
                startLevel(10, 10, 40, true);
                break;
            case 11:

                for (int i = 0; i < 21; i++)
                {
                    Instantiate(PrefabSpeedy, new Vector3(-10, -10, 0), Quaternion.identity);
                }
                spawnCase++;
                

                break;
            case 12:
                startLevel(3,30, 10, false);
                break;
            case 13:
                startLevel(2, 20, 10, false);
                break;
            case 14:
                startLevel(1, 5, 50, true);
                break;
            case 15:
                startLevel(2,20, 200, true);
                break;




            //case 2:
            //    startLevel(5, 2, 10, false);
            //    break;

            //case 3:
            //    startLevel(10, 10, 60, false);
            //    break;
            //case 4:
            //    startLevel(1, 2, 15, false);
            //    break;
            //case 5:
            //    startLevel(10, 0, 15, true);

            //    break;
            //case 6:
            //    startLevel(10, 0, 15, true);


            //    break;
            //case 7:
            //    startLevel(10, 0, 15, true);

            //    break;
            //case 2:
            //    startLevel(5, 2, 10, false);
            //    break;

            //case 3:
            //    startLevel(10, 10, 60, false);
            //    break;
            //case 4:
            //    startLevel(1, 2, 15, false);
            //    break;
            //case 5:
            //    startLevel(10, 0, 15, true);

            //    break;
            //case 6:
            //    startLevel(10, 0, 15, true);


            //    break;
            //case 7:
            //    startLevel(10, 0, 15, true);

            //    break;









            case 16:
                
                startLevel(3,20, 9999, true);
               
                break;
            case 18:
             
                startLevel(3, 20, 9999, true);
               

                break;

            case 19:

                startLevel(3, 20, 9999, true);

                break;
            case 20:

                startLevel(3, 20, 9999, true);


                break;


            case 21:

                startLevel(3, 20, 9999, true);

                break;
            case 22:

                startLevel(3, 20, 9999, true);


                break;


            case 23:

                startLevel(3, 20, 9999, true);

                break;
            case 24:

                startLevel(3, 20, 9999, true);


                break;


            case 25:

                startLevel(3, 20, 9999, true);

                break;
            case 26:

                startLevel(3, 20, 9999, true);


                break;


            case 27:

                startLevel(3, 20, 9999, true);

                break;
            case 28:

                startLevel(3, 20, 9999, true);


                break;


            case 29:

                startLevel(3, 20, 9999, true);

                break;
            case 30:

                startLevel(3, 20, 9999, true);

                break;







        }
        // calculate a circle
    }
}
    // berechnet eine position am rande des kreises.









    //public GameObject prefab;
    //public PlayerController playerController;
    //public GameObject player;



    //public int spawnRate;
    //public float spawnCountdown;



    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    playerController = player.GetComponentInChildren<PlayerController>();

    //    spawnCountdown = 10;

    //    spawnRate = 10;
    //}
    //private void Update()
    //{
    //    spawnCreepers();


    //}
    //// berechnet eine position am rande des kreises.
    //Vector2 RandomCircle(Vector2 center, float radius)
    //{
    //    float ang = Random.value * 360;
    //    Vector2 pos;
    //    pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
    //    pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);

    //    return pos;
    //}

    //// spawn eine Creature 
    //public void spawnCreepers()
    //{
    //    if (spawnCountdown <= 0f)
    //    {

    //        if (playerController.playerLevel % 10 == 0 && spawnRate>=2)
    //        {
    //            spawnRate--;
    //        }
    //        else
    //        {
    //            spawnRate = 1;
    //        }

    //        spawnCountdown = spawnRate;
    //        Debug.Log(spawnCountdown);
    //        Vector2 center = transform.position;


    //        for (int i = 1; i <= playerController.getPlayerLevel(); i++)
    //        {

    //            Instantiate(prefab, pos, Quaternion.identity);


    //        }


    //    }
    //    spawnCountdown -= Time.deltaTime;
    //}





    //NEW SpawnSystem.

