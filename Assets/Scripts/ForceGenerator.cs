using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator : MonoBehaviour
{

    private GameObject seal;
    Transform cameraMove;
    float dirX, dirY;
    // Use this for initialization
    void Start()
    {
        seal = GameObject.Find("Seal");
        cameraMove = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Waiting for Input");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate(new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f)));
        }

    }
    public void Generate(Vector2 v)
    {
        Debug.Log("Generator Called!!!");

       
        Vector2 waveForceDir = v;

        float magnitude = Random.Range(100f, 150f);
        int aftershock = 2;
        waveForceDir = waveForceDir.normalized;

        StartCoroutine(GenerateForce(waveForceDir, magnitude, aftershock));
    }

    IEnumerator GenerateForce(Vector2 direction, float magnitude, int aftershock)
    {
        float time = 3.0f;
        if (aftershock <= 0)
        {
            yield return new WaitForSeconds(time);
        }
        else
        {
            seal.GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Force);
            cameraMove.transform.Translate(-direction/5);
            yield return new WaitForSeconds(time);
            StartCoroutine(GenerateForce(direction * -1, magnitude * 2.0f, aftershock - 1));
        }


        Debug.Log("Front force Given and invoking Back Force");
        //Invoke("GenerateBackForce", 1.5f);

    }

}