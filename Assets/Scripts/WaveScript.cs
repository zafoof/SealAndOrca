using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

    // Use this for initialization

    GameObject forceGenerator;
    public Transform target;
    public AudioClip clip;


    //Vector3 startPos;
    float dirX, dirY;
	void Start () {
        forceGenerator = GameObject.Find("Force");


        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(transform.up,targetDir);
        if(transform.position.x == -10.5)
        {
            
            GetComponent<Rigidbody2D>().MoveRotation(-angle);

            //wave.transform.Rotate(wave.transform.rotation.eulerAngles +  new Vector3(0, 0, -90));
        }
        if(transform.position.x == 10.5)
        {

            
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        if(transform.position.y == -8.0 && transform.position.x <0)
        {
           
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        if(transform.position.y == -8.0 && transform.position.x > 0)
        {
            
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        if (transform.position.y == 8.0 && transform.position.x < 0)
        {
           
            GetComponent<Rigidbody2D>().MoveRotation(-angle);
        }
        if (transform.position.y == 8.0 && transform.position.x > 0)
        {
            
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
   
       
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
            AudioSource.PlayClipAtPoint(clip, collision.gameObject.transform.position);
            forceGenerator.GetComponent<ForceGenerator>().Generate(transform.position.normalized * -1);
            
        }
    }
}
