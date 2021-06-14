using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public Rigidbody2D rb2D;
    [SerializeField]
    private float DefaultSpeed;
    private float speed;
    public GameObject dogPrefabs;
    public float minSpawnDog;
    public float maxSpawnDog;
    public SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    private void OnEnable()
    {
        SetupPosition();
        StartCoroutine(WaitToSpawnDog());
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    public void SetupPosition()
    {
        if (transform.position.x >= 0.0f)
        {
            speed = -DefaultSpeed;
        }
        else
        {
            speed = DefaultSpeed;
        }    
       spriteRenderer.flipX = speed < 0 ? true : false;
    }
   
    public IEnumerator WaitToSpawnDog()
    {
        while (GameManager.instance.isGameActive)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDog, maxSpawnDog));
            Instantiate(dogPrefabs, transform.position, Quaternion.identity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.CompareTag("Left")) || (collision.gameObject.CompareTag("Right")))
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("BulletFire"))
        {

        }    
    }


}
