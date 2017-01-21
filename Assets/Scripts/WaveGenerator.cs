using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject wave;
	void Start () {
        InvokeRepeating("WaveGeneratorFunction", 3, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void WaveGeneratorFunction()
    {
        int priorityDirection = Random.Range(1, 1000) % 2;
        //int priorityDirection = 1;
        if (priorityDirection == 0)
        {
            int xDirection = Random.Range(1, 1000) % 2;
            //int xDirection = 1;
            if (xDirection == 0)
            {
                wave = Instantiate(wave, new Vector3(-10.5f, Random.Range(8.0f, -8.0f), 0), Quaternion.identity) as GameObject;
            }
            else
            {
                wave = Instantiate(wave, new Vector3(10.5f, Random.Range(8.0f, -8.0f), 0), Quaternion.identity) as GameObject;
            }
        }
        else
        {
            int yDirection = Random.Range(1, 1000) % 2;
            
            if (yDirection == 0)
            {

                wave = Instantiate(wave, new Vector3(Random.Range(-7f,7f),-8.0f, 0), Quaternion.identity) as GameObject;
            }
            else
            {
                wave = Instantiate(wave, new Vector3(Random.Range(-7f, 7f), 8.0f, 0), Quaternion.identity) as GameObject;
            }
        }
    }
}
