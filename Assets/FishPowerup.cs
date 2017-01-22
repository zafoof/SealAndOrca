using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPowerup : MonoBehaviour {

    public GameObject Walrus;
 

    private void Start()
    {
        //Walrus = GameObject.Find("Walrus");
       
    }

    private void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Player!!");
            coll.gameObject.transform.position = Vector3.zero;
            coll.gameObject.transform.rotation = Quaternion.identity;

            Walrus = Instantiate(Walrus, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}
