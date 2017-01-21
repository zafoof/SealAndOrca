using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour {
    Vector2 movement;
    float speed = 1f;
    Rigidbody2D playerRigidbody;
	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");
        Move(h, v);

	}
    void Move (float h, float v)
    {
        movement.Set(h, v);
        movement = movement.normalized;//* speed * Time.deltaTime;
        playerRigidbody.AddForce(movement);
    }
    /*
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Iceberg")
        {
            Debug.Log("On the iceberg");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Iceberg")
        {
            Debug.Log("Out of the iceberg and game over!!");
        }
    }
    */
}
