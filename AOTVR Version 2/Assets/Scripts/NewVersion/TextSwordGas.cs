using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSwordGas : MonoBehaviour {

    public Text SwordLV;
    public Text SwordRV;
    public Text GasLV;
    public Text GasRV;
    public Text SwordLO;
    public Text SwordRO;
    public Text GasLO;
    public Text GasRO;

    public Text SwordLV2;
    public Text SwordRV2;
    public Text GasLV2;
    public Text GasRV2;
    public Text SwordLO2;
    public Text SwordRO2;
    public Text GasLO2;
    public Text GasRO2;

    SwordAndGasCount sagc;
    CheckSDK checksdk;
	// Use this for initialization
	void Start () {
        sagc = GetComponent<SwordAndGasCount>();
        checksdk = GetComponent<CheckSDK>();
	}
	
	// Update is called once per frame
	void Update () {
    
        if (checksdk.VIVE)
        {
            SwordLV.text = sagc.LeftSwordCount.ToString();
            SwordRV.text = sagc.RightSwordCount.ToString();
            GasLV.text = sagc.LeftGasCount.ToString();
            GasRV.text = sagc.RightGasCount.ToString();
            SwordLV2.text = sagc.LeftSwordCount.ToString();
            SwordRV2.text = sagc.RightSwordCount.ToString();
            GasLV2.text = sagc.LeftGasCount.ToString();
            GasRV2.text = sagc.RightGasCount.ToString();
        }
        if (checksdk.OCULUS)
        {
            SwordLO.text = sagc.LeftSwordCount.ToString();
            SwordRO.text = sagc.RightSwordCount.ToString();
            GasLO.text = sagc.LeftGasCount.ToString();
            GasRO.text = sagc.RightGasCount.ToString();
            SwordLO2.text = sagc.LeftSwordCount.ToString();
            SwordRO2.text = sagc.RightSwordCount.ToString();
            GasLO2.text = sagc.LeftGasCount.ToString();
            GasRO2.text = sagc.RightGasCount.ToString();
        }
    }
}
