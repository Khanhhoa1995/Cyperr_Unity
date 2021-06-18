using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public Text ScoreText;
    public Text ScoreGameOver;
    private int score;

    public GameObject gameOver;
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

    private void Start()
    {

    }
    IEnumerator SpawnHeli()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            SpawnHelicopter();
        }

    }
    public void GameStart()
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        ObjectPooler.SharedInstance.SetPooledObject();
        StartCoroutine(SpawnHeli());
        UpdateScore(0);

    }


    public void UpdateScore(int point)
    {
        score += point;
        ScoreText.text = "" + score;
        ScoreGameOver.text = "" + score;
    }    

    public void GameOver()
    {
        gameOver.SetActive(true);
        isGameActive = false;

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGameActive)
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
