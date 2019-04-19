using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedMoniter : MonoBehaviour {

    CheckSDK checksdk;

    public float Speed;

    public Rigidbody pcSdk;
    public Rigidbody viveSdk;
    public Rigidbody oculusSdk;

    public Text SpeedLV;
    public Text SpeedRV;
    public Text SpeedLO;
    public Text SpeedRO;

    public Text SpeedLV2;
    public Text SpeedRV2;
    public Text SpeedLO2;
    public Text SpeedRO2;
    // Use this for initialization
    void Start () {
        checksdk = GetComponent<CheckSDK>();
	}
	
	// Update is called once per frame
	void Update () {
        if (checksdk.PC)
        {
            Speed = pcSdk.velocity.magnitude;
        }
        if (checksdk.VIVE)
        {
            Speed = viveSdk.velocity.magnitude;
        }
        if (checksdk.OCULUS)
        {
            Speed = oculusSdk.velocity.magnitude;
        }
        SpeedLO.text = Speed.ToString();
        SpeedRO.text = Speed.ToString();
        SpeedLV.text = Speed.ToString();
        SpeedRV.text = Speed.ToString();
        SpeedLO2.text = Speed.ToString();
        SpeedRO2.text = Speed.ToString();
        SpeedLV2.text = Speed.ToString();
        SpeedRV2.text = Speed.ToString();
    }
}
