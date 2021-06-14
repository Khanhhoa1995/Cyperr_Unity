using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //diference.Normalize();
        //float rotationZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;

        //if (rotationZ > -100.0f && rotationZ < 100.0f)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        //}
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        pos.Normalize();
        var angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
       
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.AngleAxis(angle - 90 ,Vector3.forward), Time.deltaTime * 50);
        }
    }

    private void Update()
    {
  
    }

}
