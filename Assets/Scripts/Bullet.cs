using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.isGameActive)
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            pos.Normalize();
            var angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            var angle1 = Mathf.Clamp(angle, 0, 180 );
            //Debug.Log($"hoa1111111111 angle={angle}");
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.AngleAxis(angle1 - 90, Vector3.forward), Time.deltaTime * 50);
            
        }
    }
}
