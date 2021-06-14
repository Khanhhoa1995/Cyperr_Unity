using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public Helicopter helicopterPP;

    public GameObject bulletFire;
    public Transform firePos;

    public float minRate;
    public float maxRate;

    public bool isGameActive = false;
    public GameObject titleScreen;
    public bool isFaceLeft;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }    
    }
    void Start()
    {
        isGameActive = true;
         StartCoroutine(SpawnHeli());
    }

    IEnumerator SpawnHeli()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            //helicopterPP.SpawnHelicopter();
            SpawnHelicopter();
        }

    }



    public void GameStart()
    {
        isGameActive = true;
       // InvokeRepeating("SpawnHeliCopter", 4f, Random.Range(minRate, maxRate));
        //titleScreen.SetActive(false);
        //SpawnHeliCopter();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletFire, firePos.position, firePos.rotation);
        }
    }

    public void SpawnHelicopter()
    {
        GameObject helicopter = ObjectPooler.SharedInstance.GetPooledObject();
        if (helicopter != null)
        {
            Vector2 spawnPoint = Camera.main.ScreenToWorldPoint(RandomPosision());
            helicopter.transform.position = spawnPoint;
            transform.position = helicopter.transform.position;
            helicopter.SetActive(true);
            //SetupPosition();
        }
    }

    private Vector2 RandomPosision()
    {
        float xPos = 0f;
        if (Random.Range(-1.0f, 1.0f) > 0)
        {
            xPos = Screen.width;
        }
        Vector2 point = new Vector3(xPos, Random.Range(Screen.height / 1.5f, (Screen.height / (1.05f))));
        return point;
    }

}
