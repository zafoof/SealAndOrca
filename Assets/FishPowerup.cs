using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPowerup : MonoBehaviour {

    public GameObject Walrus;
    static int kill;
    Timer timer;

    private void Start()
    {
        //Walrus = GameObject.Find("Walrus");
        timer = GameObject.Find("Image").GetComponent<Timer>();     
    }

    private void Update()
    {
        if (kill == 1)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            int selection = Random.Range(1, 1000) % 2;
            if (selection == 0)
            {
                Debug.Log("Collision with Player!!");
                coll.gameObject.transform.position = Vector3.zero;
                coll.gameObject.transform.rotation = Quaternion.identity;
                Walrus = Instantiate(Walrus, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
                kill = 1;
                Destroy(gameObject);

            }
            else
            {
                Animator anim = coll.gameObject.GetComponent<Animator>();
                anim.SetInteger("elephant", 1);
                coll.gameObject.transform.position = Vector3.zero;
                coll.gameObject.transform.rotation = Quaternion.identity;
                
                kill = 1;
                timer.time += 20;
               
            }

        
    }
    }
}
