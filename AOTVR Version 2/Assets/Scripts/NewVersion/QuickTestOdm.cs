using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTestOdm : MonoBehaviour {

    public LineRenderer line;
    public Transform Hook;
    public Rigidbody Body;
    public float Speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(0, Hook.transform.position);
        line.SetPosition(1, Body.transform.position);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Body.AddForce((Hook.transform.position - Body.transform.position).normalized * Speed);
        }
	}
}
