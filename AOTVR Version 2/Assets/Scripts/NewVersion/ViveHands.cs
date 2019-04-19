using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveHands : MonoBehaviour {

    public CheckSDK checkSdk;
    public SwitchWeapons switchWeapons;
    public SwordAndGasCount swordAndgasCount;

  
    // Use this for initialization
    void Start()
    {
     
    }

    public bool HandTouchingGas;
    public bool HandTouchingSword;

    public bool DestroyGas = false;
    public bool DestroySword = false;
    // Update is called once per frame
    void Update () {
		
	}
    GameObject EmptyGasCan;
    public GameObject emptyGasCan;
    public AudioSource GasSound;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gas")
        {
           
            if (switchWeapons.HandsOn)
            {
                HandTouchingGas = true;
               
            }

            if (DestroyGas)
            {
                DestroyGas = false;             
                EmptyGasCan = Instantiate(emptyGasCan, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                StartCoroutine(DestroyGasCan());
            }
        }
        if (other.tag == "Sword")
        {
             Debug.Log("Touching");
            if (switchWeapons.HandsOn)
            {
                HandTouchingSword = true;
             
            }
            if (DestroySword)
            {
                DestroySword = false;
                Destroy(other.gameObject);
            }
        }
    }
    IEnumerator DestroyGasCan()
    {
      
        yield return new WaitForSeconds(7);
        Destroy(EmptyGasCan);
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Gas" || !switchWeapons.HandsOn)
        {
                HandTouchingGas = false;
            if (DestroyGas)
            {
                DestroyGas = false;
                EmptyGasCan = Instantiate(emptyGasCan, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                StartCoroutine(DestroyGasCan());
            }

        }
        if (other.tag == "Sword" || !switchWeapons.HandsOn)
        {
            
                HandTouchingSword = false;
            if (DestroySword)
            {
                DestroySword = false;
                Destroy(other.gameObject);
            }
        }
    }
    public void GrabbingGas()
    {

        if (HandTouchingGas)
        {
            if (checkSdk.VIVE)
            {
                Debug.Log("PickUpGasVive");
                if (swordAndgasCount.LeftGasCount != 100)
                {
                    swordAndgasCount.LeftGasCount = 100;
                    DestroyGas = true;
                    GasSound.Play();
                }
                if (swordAndgasCount.RightGasCount != 100)
                {
                    swordAndgasCount.RightGasCount = 100;
                    DestroyGas = true;
                }
            }
            if (checkSdk.OCULUS)
            {
                Debug.Log("PickUpGasOculus");
                if (swordAndgasCount.LeftGasCount != 100)
                {
                    swordAndgasCount.LeftGasCount = 100;
                    DestroyGas = true;
                    GasSound.Play();
                }
                if (swordAndgasCount.RightGasCount != 100)
                {
                    swordAndgasCount.RightGasCount = 100;
                    DestroyGas = true;
                }
            }
        }

            
    }
    public void GrabbingSword()
    {
        if (HandTouchingSword)
        {
            if (checkSdk.VIVE)
            {
                Debug.Log("PickUpSwordVive");
                if (swordAndgasCount.LeftSwordCount != 5)
                {
                    swordAndgasCount.LeftSwordCount = 5;
                    DestroySword = true;
                }
                if (swordAndgasCount.RightSwordCount != 5)
                {
                    swordAndgasCount.RightSwordCount = 5;
                    DestroySword = true;
                }
            }
            if (checkSdk.OCULUS)
            {
                Debug.Log("PickUpSwordOculus");
                if (swordAndgasCount.LeftSwordCount != 5)
                {
                    swordAndgasCount.LeftSwordCount = 5;
                    DestroySword = true;
                }
                if (swordAndgasCount.RightSwordCount != 5)
                {
                    swordAndgasCount.RightSwordCount = 5;
                    DestroySword = true;
                }
            }
        }
    }
}
