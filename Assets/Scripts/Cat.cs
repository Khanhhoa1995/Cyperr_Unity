using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    public GameObject textBoxCat;
    //public GameObject textCat;
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
        if(collision.gameObject.CompareTag("Dog")&& collision.gameObject.GetComponent<BoxCollider2D>().isTrigger == false)
        {
            textBoxCat.SetActive(false);
           // textCat.SetActive(true);
            rb2D.isKinematic = false;
            partical.SetActive(true);
            animPartical.SetActive(true);
            partical.GetComponent<ParticleSystem>().Play();

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
