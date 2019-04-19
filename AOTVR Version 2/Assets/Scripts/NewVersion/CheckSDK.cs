using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSDK : MonoBehaviour {

    public  bool PC;
    public  bool VIVE;
    public  bool OCULUS;

    public GameObject PCSDK;
    public GameObject VIVESDK;
    public GameObject OCULUSSDK;
    public GameObject VRControllers;

    public static bool VRON;
    public GameObject PCTemporary;
    public GameObject Loading;
   
	// Use this for initialization
	void Awake () {
        StartCoroutine(Wait());
        PCSDK.SetActive(false);
        Loading.SetActive(true);
        PCTemporary.SetActive(false);
        
	}
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1);
        Destroy(Loading);
        Check();
    }
    public void Check()
    {
        if (VIVESDK.activeInHierarchy)
        {
            VIVE = true;
            PC = false;
            OCULUS = false;
            Debug.Log("VIVE");
            VRON = true;
            VRControllers.SetActive(true);
            GetComponent<HandsScript>().enabled = false;
            GetComponent<PCHorseScript>().enabled = false;
        }
        else if (OCULUSSDK.activeInHierarchy)
        {
            VIVE = false;
            PC = false;
            OCULUS = true;
            Debug.Log("OCULUS");
            VRON = true;
            VRControllers.SetActive(true);
            GetComponent<HandsScript>().enabled = false;
            GetComponent<PCHorseScript>().enabled = false;
        }
        else if (!VIVESDK.activeInHierarchy && !OCULUSSDK.activeInHierarchy)
        {
            //    VIVE = false;
            //    PC = true;
            //    OCULUS = false;
            //    PCSDK.SetActive(true);
            //     VRControllers.SetActive(false);
            //   Debug.Log("PC");
            //   VRON = false;
            PCTemporary.SetActive(true);
            StartCoroutine(Quitting());
        }

    }
    IEnumerator Quitting()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

}
