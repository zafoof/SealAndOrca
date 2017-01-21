using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator : MonoBehaviour {

    private GameObject seal;

    float dirX, dirY;
	// Use this for initialization
	void Start () {
        seal = GameObject.Find("Seal");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Waiting for Input");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input!!Input!!");
            dirX = Random.Range(-3.0f, 3.0f);
            dirY = Random.Range(-3.0f, 3.0f);
            GenerateFrontForce(dirX,dirY);
            
        }
        
	}

    void GenerateFrontForce(float dirX,float dirY)
    {
        seal.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirX,dirY) * 35, ForceMode2D.Force);
        Debug.Log("Front force Given and invoking Back Force");
        //Invoke("GenerateBackForce", 1.5f);
        StartCoroutine(GenerateBackForce(dirX, dirY, 1.5f));
    }

    IEnumerator GenerateBackForce(float dirX, float dirY,float time)
    {
        yield return new WaitForSeconds(time);
        seal.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirX, dirY) * -25, ForceMode2D.Force);
        Debug.Log("Back force Given and invoking Front Force1");  
        StartCoroutine(GenerateFrontForce1(dirX, dirY, 1.0f));
    }
    IEnumerator GenerateFrontForce1(float dirX, float dirY,float time)
    {
        yield return new WaitForSeconds(time);
        seal.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirX, dirY) * 15, ForceMode2D.Force);
        Debug.Log("Front force Given and invoking Back Force1");
        StartCoroutine(GenerateBackForce1(dirX, dirY, 0.8f));
    }
    IEnumerator GenerateBackForce1(float dirX, float dirY,float time)
    {
        yield return new WaitForSeconds(time);
        seal.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirX, dirY) * -1, ForceMode2D.Force);
        Debug.Log("Back force Given and nothing should happen now");
        Invoke("StopForce", 0.8f);
    }
    
}
