using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private bool isFaceLeft;
    public GameObject dogPrefabs;

    public float minSpawnDog;
    public float maxSpawnDog;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
       SetupPosition();
       StartCoroutine(WaitToSpawnDog());
       // InvokeRepeating("SpawnHelicopter", 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFaceLeft)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
      
    }
    private void SetupPosition()
    {
        Vector3 localScale = transform.localScale;
        if (transform.position.x >=0)
        {
            isFaceLeft = true;
        }
        else
        {
            isFaceLeft = false;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    public IEnumerator WaitToSpawnDog()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnDog , maxSpawnDog));
        Instantiate(dogPrefabs, transform.position, Quaternion.identity);
    }

    public void SpawnHelicopter()
    {
        Instantiate(GameManager.instance.GetHelicopterToPool());
    }

}
