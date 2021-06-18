using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    public GameObject textBoxCat;
    public GameObject partical;
    public GameObject animPartical;
    public Transform transform1;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Dog"))
        {
            textBoxCat.SetActive(false);
            rb2D.isKinematic = false;
            partical.SetActive(true);
            animPartical.SetActive(true);
            partical.GetComponent<ParticleSystem>().Play();

            //  Instantiate(partical,new Vector2(Random.Range(transform.position.x-1, transform.position.x+1),Random.Range( transform.position.y -1, transform.position.y +1)), Quaternion.identity);
            Instantiate(partical, partical.transform.position, Quaternion.identity);
            Instantiate(animPartical, transform1.position, Quaternion.identity);
            rb2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            StartCoroutine(WaitToDestroy());// check more here.
        }  
    }
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(3);
        animPartical.GetComponent<Animator>().SetBool("isIdle", true);
        Destroy(gameObject);
        Destroy(partical);
        GameManager.instance.GameOver();
    }    
}
