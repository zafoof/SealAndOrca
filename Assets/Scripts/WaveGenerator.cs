using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject whale;
    public AudioClip clip;
  
	void Start () {
        InvokeRepeating("whaleGeneratorFunction", 3, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void whaleGeneratorFunction()
    {
        int priorityDirection = Random.Range(1, 1000) % 2;
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
        //int priorityDirection = 0;
        if (priorityDirection == 0)
        {
            int xDirection = Random.Range(1, 1000) % 2;
            //int xDirection = 0;
            if (xDirection == 0)
            {
                Vector2 pos = new Vector2(-10.5f, Random.Range(8.0f, -8.0f));
                Vector2 pos2 = pos - new Vector2(1.886f, 0.1542f);
                whale = Instantiate(whale,pos, Quaternion.identity) as GameObject;
                
            }
            else
            {
                whale = Instantiate(whale, new Vector3(10.5f, Random.Range(8.0f, -8.0f), 0), Quaternion.identity) as GameObject;
            }
        }
        else
        {
            int yDirection = Random.Range(1, 1000) % 2;
            
            if (yDirection == 0)
            {

                whale = Instantiate(whale, new Vector3(Random.Range(-7f,7f),-8.0f, 0), Quaternion.identity) as GameObject;
            }
            else
            {
                whale = Instantiate(whale, new Vector3(Random.Range(-7f, 7f), 8.0f, 0), Quaternion.identity) as GameObject;
            }
        }
    }
}
