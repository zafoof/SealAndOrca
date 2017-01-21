using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaMovement : MonoBehaviour {

    public Transform center;
    public float degreesPerSecond = -65.0f;

    private Vector3 v;
	// Use this for initialization
	void Start () {
        center = GameObject.Find("Iceberg").GetComponent<Transform>();
        v = transform.position - center.position;
	}
	
	// Update is called once per frame
	void Update () {
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.forward * 0.1f) * v;
        transform.position = center.position + v;
    }
}
