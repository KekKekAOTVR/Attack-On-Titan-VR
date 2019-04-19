using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollow : MonoBehaviour {

    public Transform Follow;

	// Use this for initialization
	void Start () {
		
	}

    public float offset;
 
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Follow.position.x, Follow.position.y - offset, Follow.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Follow.eulerAngles.y, transform.eulerAngles.z);
       
    }
}
