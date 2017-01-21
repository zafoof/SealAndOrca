using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seal : MonoBehaviour {
    Vector2 movement;
    float speed = 1f;
    float turnspeed = 6f;
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
        
        
        movement = movement.normalized* speed;
        if (h != 0 || v != 0)
        {
            float angle = Vector2.Angle(new Vector2(0f, 1f), movement);

            if (h == 1f)
            {
                if (v == 0f)
                {
                    angle = angle + 180;
                }
                if(v==1f)
                {
                    angle = angle + 270;
                }
                if (v == -1f)
                {
                    angle = angle + 90;
                }

            }
            angle = angle % 360;
            

            float playerAngle = ((playerRigidbody.rotation % 360) + 360) % 360;
           
            if (playerAngle < angle + 5f && playerAngle > angle - 5f)
            {
                playerRigidbody.MoveRotation(angle);

            }
            else
            {
                if (playerAngle < 180 && angle > 180)
                {
                    playerRigidbody.AddTorque((180 - ((180 - angle + playerAngle) % 360)) * -turnspeed * Time.deltaTime);
                }
                else
                {
                    playerRigidbody.AddTorque((180 - ((180 - angle + playerAngle) % 360)) * turnspeed * Time.deltaTime);
                    
                }
                
                
            }
        }
        
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
