using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimGrab : MonoBehaviour {

    public CheckSDK checkSdk;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Animator HandanimVive;
    public Animator HandanimOculus;
    public void Grab()
    {
        
        if (checkSdk.VIVE)
        {
            HandanimVive.SetBool("isGrabbing", true);
        }
        if (checkSdk.OCULUS)
        {
            HandanimOculus.SetBool("isGrabbing", true);
        }
    }
    public void LetGo()
    {
      
        if (checkSdk.VIVE)
        {
            HandanimVive.SetBool("isGrabbing", false);
        }
        if (checkSdk.OCULUS)
        {
            HandanimOculus.SetBool("isGrabbing", false);
        }
    }
}
