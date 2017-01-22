using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startscript : MonoBehaviour {
    Animator a;
    // Use this for initialization
    void Start () {

        a= GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void anim()
    {
        a.SetBool("start", true);
        Invoke("next", 2.5f);


    }
    void next()
    {
        GetComponent<LevelManager>().LoadLevel("instr");
    }
}
