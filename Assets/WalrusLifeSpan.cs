using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalrusLifeSpan : MonoBehaviour {

    public float timeAmount;
    private GameObject Seal;
    public float time;

    // Use this for initialization
    void Start () {   
        time = timeAmount;
        Seal = GameObject.Find("Seal") as GameObject;
        Seal.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (time >= 0)
        {
            time -= Time.deltaTime;
           
        }
        else
        {
            Seal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
