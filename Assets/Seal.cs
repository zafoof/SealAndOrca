using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seal : MonoBehaviour {
    Vector2 movement;
    float speed = 1f;
    Rigidbody2D playerRigidbody;
    private Text loseText;
	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        loseText = GameObject.Find("Lost").GetComponent<Text>();
        loseText.enabled = false;
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
 
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Iceberg")
        {
            loseText.enabled = true;
        }
    }
    
}
