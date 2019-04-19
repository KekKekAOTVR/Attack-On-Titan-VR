using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour {

    private CheckSDK checkSdk;

    private bool Vive;
    private bool Oculus;

    public bool SwordsOn;
    public bool FlareOn;
    public bool HandsOn;
    public bool MapOn;

    //public ViveHorseScript vrHorse;
    //private PCHorseScript pcHorse;
	// Use this for initialization
	void Start () {
        checkSdk = GetComponent<CheckSDK>();
        SwordsOn = true;

        //pcHorse = GetComponent<PCHorseScript>();

        OculusLHand.SetActive(false);
        OculusRHand.SetActive(false);
        ViveLHand.SetActive(false);
        ViveRHand.SetActive(false);
        OculusFlare.SetActive(false);
        ViveFlare.SetActive(false);
    }
    [Header("Vive")]
    public GameObject ViveLSword;
    public GameObject ViveRSword;
    public GameObject ViveLHand;
    public GameObject ViveRHand;
    public GameObject ViveFlare;
    public GameObject ViveMap;
    [Header("Oculus")]
    public GameObject OculusLSword;
    public GameObject OculusRSword;
    public GameObject OculusLHand;
    public GameObject OculusRHand;
    public GameObject OculusFlare;
    public GameObject OculusMap;
    [Header("PC")]
    public GameObject PCSdk;
    public GameObject PCSdkCamera;
    public GameObject PCSwordHud;
    public GameObject PCFlareHud;
    public GameObject PCHandsHud;
    public GameObject PCMapHud;
    public GameObject PCMenu;
    // Update is called once per frame
    void Update () {
        if (checkSdk.PC)
        {
            PCSwitch();
        }
        if (checkSdk.VIVE)
        {
            Vive = true;
            Oculus = false;
        }
        else if (checkSdk.OCULUS)
        {
            Vive = false;
            Oculus = true;
        }

        Flare();
        Swords();
        Hands();
        Map();
	}

    public void Swords()
    {
      if(SwordsOn)
        {
            if (checkSdk.PC)
            {
                PCSwordHud.SetActive(true);
            }
            else if (checkSdk.VIVE)
            {
                ViveLSword.SetActive(true);
                ViveRSword.SetActive(true);
            }
            else if (checkSdk.OCULUS)
            {
                OculusLSword.SetActive(true);
                OculusRSword.SetActive(true);
            }

        }
        else if (!SwordsOn)
        {
            OculusLSword.SetActive(false);
            OculusRSword.SetActive(false);
            ViveLSword.SetActive(false);
            ViveRSword.SetActive(false);
            PCSwordHud.SetActive(false);
        }
    }
    public void Map()
    {
        if (MapOn)
        {
            if (checkSdk.PC)
            {
                PCMapHud.SetActive(true);
                PCMenu.SetActive(true);
                PCSdk.GetComponent<PCController>().enabled = false;
                PCSdkCamera.GetComponent<PCController>().enabled = false;
            }
            else if (checkSdk.VIVE)
            {
                ViveMap.SetActive(true);
                ViveRHand.SetActive(true);
            }
            else if (checkSdk.OCULUS)
            {
                OculusMap.SetActive(true);
                OculusRHand.SetActive(true);
            }

        }
        else if (!MapOn)
        {
            ViveMap.SetActive(false);
            OculusMap.SetActive(false);
            PCMapHud.SetActive(false);
            PCMenu.SetActive(false);
            PCSdk.GetComponent<PCController>().enabled = true;
            PCSdkCamera.GetComponent<PCController>().enabled = true;
        }
    }
    public void Hands()
    {
        if (HandsOn)
        {
            if (checkSdk.PC)
            {
                PCHandsHud.SetActive(true);
            }
            else if (checkSdk.VIVE)
            {
                ViveLHand.SetActive(true);
                ViveRHand.SetActive(true);
            }
            else if (checkSdk.OCULUS)
            {
                OculusLHand.SetActive(true);
                OculusRHand.SetActive(true);
            }

        }
        else if (!HandsOn)
        {
            
            OculusRHand.SetActive(false);
            PCHandsHud.SetActive(false);
            ViveRHand.SetActive(false);
            if (!FlareOn)
            {
                OculusLHand.SetActive(false);
                ViveLHand.SetActive(false);
            }
            if (!MapOn)
            {
                OculusRHand.SetActive(false);
                ViveRHand.SetActive(false);
            }
        }
    }
    public void Flare()
    {
        if (FlareOn)
        {
            if (checkSdk.PC)
            {
                PCFlareHud.SetActive(true);
            }
            else if (checkSdk.VIVE)
            {
                ViveFlare.SetActive(true);
                ViveLHand.SetActive(true);
            }
            else if (checkSdk.OCULUS)
            {
                OculusFlare.SetActive(true);
                OculusLHand.SetActive(true);
            }

        }
        else if (!FlareOn)
        {
            OculusFlare.SetActive(false);
            ViveFlare.SetActive(false);
            PCFlareHud.SetActive(false);
        }
    }

    private bool isOn;

    public void PCSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
          
            SwordsOn = true;
            FlareOn = false;
            MapOn = false;
            HandsOn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
         
            SwordsOn = false;
            FlareOn = true;
            MapOn = false;
            HandsOn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
        
            SwordsOn = false;
            FlareOn = false;
            MapOn = false;
            HandsOn = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           
                SwordsOn = false;
                FlareOn = false;
                MapOn = true;
                HandsOn = false;
  
        }
    }

    public void SwitchToSwords()
    {
        if (Vive )
        {
            
            SwordsOn = true;
            FlareOn = false;
            MapOn = false;
            HandsOn = false;
        }
        else if (Oculus  )
        {
      
            SwordsOn = true;
            FlareOn = false;
            MapOn = false;
            HandsOn = false;
        }
    }
    public void SwitchToFlare()
    {
        if (Vive)
        {
          
            SwordsOn = false;
            FlareOn = true;
            MapOn = false;
            HandsOn = false;
        }
       else if (Oculus)
        {
            
            SwordsOn = false;
            FlareOn = true;
            MapOn = false;
            HandsOn = false;
        }
    }
    public void SwitchToMap()
    {
        if (Vive)
        {
           
            SwordsOn = false;
            FlareOn = false;
            MapOn = true;
            HandsOn = false;
        }
       else if (Oculus)
        {
           
            SwordsOn = false;
            FlareOn = false;
            MapOn = true;
            HandsOn = false;
        }
    }
    public void SwitchToHands()
    {
        if (Vive)
        {
         
            SwordsOn = false;
            FlareOn = false;
            MapOn = false;
            HandsOn = true;
        }
       else if (Oculus)
        {
         
            SwordsOn = false;
            FlareOn = false;
            MapOn = false;
            HandsOn = true;
        }
    }

}
