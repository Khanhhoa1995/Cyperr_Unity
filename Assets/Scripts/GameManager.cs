using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject helicopterPrefab;
    //public GameObject dogPrefabs;

    public List<GameObject> pooledObjects;
    //public GameObject objectToPool;
    public int amountToPool;

    public float minRate;
    public float maxRate;

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
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("SpawnHelicopter", 4f, Random.Range(minRate,maxRate));
       // SpawnHelicopterPooling();
    }

    /// <summary>
    // Object Pooling
    private void SpawnHelicopterPooling()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(helicopterPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetHelicopterToPool()
    {
        Debug.Log("hoa GetHelicopterToPool ");
        foreach (GameObject item in pooledObjects)
        {
            Debug.Log("hoa GetHelicopterToPool222 ");
            if (!item.activeInHierarchy)
            {
                Debug.Log("hoa GetHelicopterToPool1111 ");
                Vector2 spawnPosItem = Camera.main.ScreenToWorldPoint(RandomPosision());
                item.transform.position = spawnPosItem;
                item.SetActive(true);
                return item;
            }
        }

        GameObject prefabInstance = Instantiate(helicopterPrefab);
        Vector2 spawnPos = Camera.main.ScreenToWorldPoint(RandomPosision());
        prefabInstance.transform.position = spawnPos;
        pooledObjects.Add(prefabInstance);

        return prefabInstance;
    }

/// </summary>
// Update is called once per frame
void Update()
    {

    }
    // spawn Helicoper;
    private Vector2 RandomPosision()
    {
        float xPos = 0f;
        if (Random.Range(-1.0f, 1.0f) > 0)
        {
            xPos = Screen.width;
        }       
        Vector2 point = new Vector3(xPos, Random.Range(Screen.height /1.5f, (Screen.height / (1.05f))));
        return point;
    }
    private void SpawnHelicopter()
    {
        Vector2 spawnPoint = Camera.main.ScreenToWorldPoint(RandomPosision());
        helicopterPrefab.transform.position = spawnPoint;
        Instantiate(helicopterPrefab);
    }  
    
}
