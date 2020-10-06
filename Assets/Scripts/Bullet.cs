using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1.0f);

        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * 400);
    }
}
  
