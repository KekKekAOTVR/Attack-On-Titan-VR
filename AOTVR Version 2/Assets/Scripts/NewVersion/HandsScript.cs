using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsScript : MonoBehaviour {

    private CheckSDK checkSdk;
    private SwitchWeapons switchWeapons;
    private SwordAndGasCount swordAndgasCount;

    public Transform PCRaycastStart;
    RaycastHit PCHit;
    public float RaycastDistance;
    // Use this for initialization
    void Start()
    {
        checkSdk = GetComponent<CheckSDK>();
        switchWeapons = GetComponent<SwitchWeapons>();
        swordAndgasCount = GetComponent<SwordAndGasCount>();
    }

    // Update is called once per frame
    void Update () {
        if (checkSdk.PC)
        {
            if (switchWeapons.HandsOn)
            {
                Debug.Log("MakeRaycastPC");
                Physics.Raycast(PCRaycastStart.position, PCRaycastStart.forward, out PCHit, RaycastDistance);
                
            }

        }
        PickUpObject();
    }
    public void PickUpObject()
    {
        if (switchWeapons.HandsOn)
        {
            if(PCHit.collider.tag == "Gas")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if(swordAndgasCount.LeftGasCount != 100)
                    {
                        swordAndgasCount.LeftGasCount = 100;
                        Destroy(PCHit.transform.gameObject);
                    }
                    if(swordAndgasCount.RightGasCount != 100)
                    {
                        swordAndgasCount.RightGasCount = 100;
                        Destroy(PCHit.transform.gameObject);
                    }

              
                }
            }
            if(PCHit.collider.tag == "Sword")
            {              
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (swordAndgasCount.LeftSwordCount != 5)
                        {
                            swordAndgasCount.LeftSwordCount = 5;
                        Destroy(PCHit.transform.gameObject);
                    }
                        if (swordAndgasCount.RightSwordCount != 5)

                        {
                            swordAndgasCount.RightSwordCount = 5;
                        Destroy(PCHit.transform.gameObject);
                    }

              
                }                
            }
        }
    }
 
}
