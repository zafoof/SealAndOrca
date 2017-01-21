using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

    // Use this for initialization

    GameObject forceGenerator;
    public Transform target;
    //Vector3 startPos;
    float dirX, dirY;
	void Start () {
        forceGenerator = GameObject.Find("Force");

        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(transform.up,targetDir);
        if(transform.position.x == -10.5)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        if(transform.position.x == 10.5)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        if(transform.position.y == -8.0 && transform.position.x <0)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        if(transform.position.y == -8.0 && transform.position.x > 0)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        if (transform.position.y == 8.0 && transform.position.x < 0)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        if (transform.position.y == 8.0 && transform.position.x > 0)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        /*
        if(transform.position.x < 0.0 && transform.position.y > 0)
        {
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        else
        {
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        */
        Debug.Log("The angle is: " + angle);
        GiveVelocity();
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public void GiveVelocity()
    {

        GetComponent<Rigidbody2D>().velocity = transform.position.normalized * -3f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Iceberg")
        {
            forceGenerator.GetComponent<ForceGenerator>().Generate(transform.position.normalized * -1);
        }
    }
}
