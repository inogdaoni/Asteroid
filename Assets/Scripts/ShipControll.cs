using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControll : MonoBehaviour
{
    float rotationSpeed = 100.0f;
    float pushForce = 3f;
    public GameObject bullet;
    private GameController gameController;

    void Start()
    { 
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(transform.up * pushForce * Input.GetAxis("Vertical"));

        if (Input.GetKey("space"))
            ShootingBullet();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Bullet")
        {
            transform.position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            gameController.DecrementLives();
        }
    }

    void ShootingBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, 
                                        transform.position.y, 0),
                                        transform.rotation);
    }
}

