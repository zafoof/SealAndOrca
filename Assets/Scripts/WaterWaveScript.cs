using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveScript : MonoBehaviour {


    public Transform targetPoint;


    //Vector3 startPos;
    float dirX, dirY;
    void Start()
    {
        Vector3 targetDir = targetPoint.position - transform.position;
        float angle = Vector3.Angle(transform.up, targetDir);
        Debug.Log("Generating point is(in WaterWaveScript):" + transform.position);
        if (transform.position.x < -12.2)
        {
            GetComponent<Rigidbody2D>().MoveRotation(-angle-90);
            //transform.position = transform.position - new Vector3(-0.2f, -1.83f, 0.0f);
            //wave.transform.Rotate(wave.transform.rotation.eulerAngles +  new Vector3(0, 0, -90));
        }
        if (transform.position.x == 10.5)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        if (transform.position.y == -8.0 && transform.position.x < 0)
        {
            Debug.Log("Generating point is:" + transform.position);
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        if (transform.position.y == -8.0 && transform.position.x > 0)
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

        Debug.Log("The angle is: " + angle);
        GiveVelocity();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GiveVelocity()
    {

        GetComponent<Rigidbody2D>().velocity = transform.position.normalized * -3f;
    }

 
}
