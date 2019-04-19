using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ViveHorseScript : MonoBehaviour {

   public CheckSDK checkSdk;
   public SwitchWeapons switchWeapons;
   public ViveHorseScript viveHorseScript;

    public GameObject HorseObject;
    public GameObject PlayAreaObject;
    public GameObject LeftController;
    // Use this for initialization
    void Start()
    {
      
    }
    public bool HandInSaddle;
    public bool OnHorse;
    public bool StandingOnHorse;
    // Update is called once per frame
    void Update () {

        if (OnHorse && !StandingOnHorse)
        {
         
            if (checkSdk.VIVE)
            {
                viveSdk.position = GetOnHorse.position;
                viveSdk.rotation = GetOnHorse.rotation;
            }
            if (checkSdk.OCULUS)
            {
                oculusSdk.position = GetOnHorse.position;
                oculusSdk.rotation = GetOnHorse.rotation;
            }
        }
        if(OnHorse && StandingOnHorse)
        {
            if (checkSdk.VIVE)
            {
                viveSdk.position = standOnHorse.position;
                viveSdk.rotation = standOnHorse.rotation;
            }
            if (checkSdk.OCULUS)
            {
                oculusSdk.position = standOnHorse.position;
                oculusSdk.rotation = standOnHorse.rotation;
            }
        }
     

	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Saddle")
        {
            if (switchWeapons.HandsOn)
            {
                HandInSaddle = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Saddle")
        {
            
                HandInSaddle = false;
            
        }
    }


    public Transform viveSdk;
    public Transform oculusSdk;
    public Transform GetOnHorse;
    public Transform GetOffHorse;
    public Transform standOnHorse;
   

    public void GetOnAndOffHorse()
    {
        if (HandInSaddle)
        {
            HandInSaddle = false;
            OnHorse = true;
            viveHorseScript.OnHorse = true;
            LeftController.GetComponent<VRTK_TouchpadControl>().controlOverrideObject = HorseObject;
    
            if (checkSdk.VIVE)
            {
                viveSdk.gameObject.GetComponent<Rigidbody>().useGravity = false;

            }
            if (checkSdk.OCULUS)
            {
                oculusSdk.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }
       else if (OnHorse)
        {
            OnHorse = false;
            StandingOnHorse = false;
            viveHorseScript.StandingOnHorse = false;
            viveHorseScript.OnHorse = false;
            LeftController.GetComponent<VRTK_TouchpadControl>().controlOverrideObject = null;
     
            if (checkSdk.VIVE)
            {
                Debug.Log("ViveOffHorse");
                viveSdk.position = GetOffHorse.position;
                viveSdk.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            if (checkSdk.OCULUS)
            {
                Debug.Log("OculusOffHorse");
                oculusSdk.position = GetOffHorse.position;
                oculusSdk.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    public void StandOnHorse()
    {
        if (OnHorse)
        {
            if (!StandingOnHorse)
            {
                StandingOnHorse = true;
                viveHorseScript.StandingOnHorse = true;
            
            }
            else if (StandingOnHorse)
            {
                StandingOnHorse = false;
                viveHorseScript.StandingOnHorse = false;
            }
        }
    }
    public Animator horseAnim;
    public void HorseAnimMoving()
    {
        if (OnHorse)
        {
            horseAnim.SetBool("Running", true);
        }
    }
    public void HorseAnim()
    {
        if (OnHorse || !OnHorse)
        {
            horseAnim.SetBool("Running", false);
        }
    }
}
