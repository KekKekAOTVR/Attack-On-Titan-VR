using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODMScript : MonoBehaviour {

    private CheckSDK checkSdk;
    private SwitchWeapons switchWeapons;
    private SwordAndGasCount swordAndGasCount;
	// Use this for initialization
	void Start () {
        checkSdk = GetComponent<CheckSDK>();
        switchWeapons = GetComponent<SwitchWeapons>();
        swordAndGasCount = GetComponent<SwordAndGasCount>();
	}
    private void FixedUpdate()
    {
        
        if (checkSdk.PC)
        {
            if (switchWeapons.SwordsOn)
            {
                Physics.Raycast(PCRaycastStart.position, PCRaycastStart.forward, out PCHit, RaycastDistance);

                
            }

        }
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {

                Physics.Raycast(ViveRaycastStartLeft.position, ViveRaycastStartLeft.forward, out ViveLeftHit, RaycastDistance);
                Physics.Raycast(ViveRaycastStartRight.position, ViveRaycastStartRight.forward, out ViveRightHit, RaycastDistance);

            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
                Physics.Raycast(OcuRaycastStartLeft.position, OcuRaycastStartLeft.forward, out OculusLeftHit, RaycastDistance);
                Physics.Raycast(OcuRaycastStartRight.position, OcuRaycastStartRight.forward, out OculusRightHit, RaycastDistance);
            }
        }

        if (UsingGasLeft && LeftHookShot && swordAndGasCount.LeftGasCount != 0)
        {

            if (checkSdk.PC)
            {



                swordAndGasCount.LeftGasCount -= GasUsageSpeed;
                pcSdk.AddForce((LeftHook.transform.position - pcSdk.transform.position).normalized * speed);



            }
            if (checkSdk.VIVE)
            {

                
                swordAndGasCount.LeftGasCount -= GasUsageSpeed;
                viveSdk.AddForce((LeftHook.transform.position - viveSdk.transform.position).normalized * speed);
             //   viveSdk.transform.rotation = Quaternion.RotateTowards(viveSdk.transform.rotation, Quaternion.LookRotation(LeftHook.transform.position), turnspeed * Time.deltaTime);
            }
            if (checkSdk.OCULUS)
            {

              
                swordAndGasCount.LeftGasCount -= GasUsageSpeed;
                oculusSdk.AddForce((LeftHook.transform.position - oculusSdk.transform.position).normalized * speed);

            }

        }
        if (UsingGasRight && RightHookShot && swordAndGasCount.RightGasCount != 0)
        {

            if (checkSdk.PC)
            {


                swordAndGasCount.RightGasCount -= GasUsageSpeed;
                pcSdk.AddForce((RightHook.transform.position - pcSdk.transform.position).normalized * speed);

            }
            if (checkSdk.VIVE)
            {

               
                swordAndGasCount.RightGasCount -= GasUsageSpeed;
                viveSdk.AddForce((RightHook.transform.position - viveSdk.transform.position).normalized * speed);

            }
            if (checkSdk.OCULUS)
            {

               
                swordAndGasCount.RightGasCount -= GasUsageSpeed ;
                oculusSdk.AddForce((RightHook.transform.position - oculusSdk.transform.position).normalized * speed);

            }
        }


  


    }

    public Transform ViveHookLStart;
    public Transform ViveHookRStart;
    public Transform OculusHookLStart;
    public Transform OculusHookRStart;

    public AudioSource GasSound;
    public AudioSource HookSound;
    // Update is called once per frame
    void Update () {
        Physics.Raycast(PCGroundRaycastStart.position, PCGroundRaycastStart.forward, out GroundHit, RaycastGroundDistance);
        Debug.DrawRay(PCGroundRaycastStart.position, PCGroundRaycastStart.forward, Color.blue, RaycastGroundDistance);
       // if (GroundHit.collider.tag == "Ground")
       // {
       //     pcSdk.gameObject.GetComponent<PCWalker>().enabled = false;
       // }
       // else
       // {
       //     pcSdk.gameObject.GetComponent<PCWalker>().enabled = true;
      //  }

        //

        if (LeftHookShot)
        {
            lineL.enabled = true;
            PCLeftLine.enabled = true;

            if (checkSdk.VIVE)
            {
                lineL.SetPosition(0, ViveHookLStart.position);
                lineL.SetPosition(1, LeftHook.transform.position);
            }
            if (checkSdk.OCULUS)
            {
                lineL.SetPosition(0, OculusHookLStart.position);
                lineL.SetPosition(1, LeftHook.transform.position);
            }
            if (checkSdk.PC)
            {
                PCLeftLine.SetPosition(0, PCLeftHookStart.position);
                PCLeftLine.SetPosition(1, LeftHook.transform.position);
            }

        }
        else
        {
            lineL.enabled = false;
            PCLeftLine.enabled = false;
        }
        if (RightHookShot)
        {
            lineR.enabled = true;
            PCRightLine.enabled = true;
            if (checkSdk.VIVE)
            {
                lineR.SetPosition(0, ViveHookRStart.position);
                lineR.SetPosition(1, RightHook.transform.position);
            }
            if (checkSdk.OCULUS)
            {
                lineR.SetPosition(0, OculusHookRStart.position);
                lineR.SetPosition(1, RightHook.transform.position);
            }
            if (checkSdk.PC)
            {
                PCRightLine.SetPosition(0, PCRightHookStart.position);
                PCRightLine.SetPosition(1, RightHook.transform.position);
            }
        }
        else
        {
            lineR.enabled = false;
            PCRightLine.enabled = false;
        }

        //
        if (checkSdk.PC)
        {
           

            if (switchWeapons.SwordsOn)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {

                    if (PCHit.collider.tag == "Hookable" && !LeftHookShot)
                    {
                        LeftHookShot = true;
                        LeftHook = Instantiate(Hook, PCHit.point, Quaternion.identity);

                    }
                }
                else
                {
                    Destroy(LeftHook);
                    LeftHookShot = false;
                }
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (PCHit.collider.tag == "Hookable" && !RightHookShot)
                    {
                        RightHookShot = true;
                        RightHook = Instantiate(Hook, PCHit.point, Quaternion.identity);
                    }
                }
                else
                {
                    Destroy(RightHook);
                    RightHookShot = false;
                }
            }
           
            if (switchWeapons.SwordsOn)
            {
                if (Input.GetKey(KeyCode.Space) && LeftHookShot && swordAndGasCount.LeftGasCount != 0)
                {

                    UsingGasLeft = true;
                   
                }
                else
                {
                 
                    UsingGasLeft = false;
                }
                if (Input.GetKey(KeyCode.Space) && RightHookShot && swordAndGasCount.RightGasCount != 0)
                {

                    UsingGasRight = true;
                    
                }
                else
                {
               
                    UsingGasRight = false;
                }

            }

        }
        //

        if (swordAndGasCount.RightGasCount < 0)
        {
            swordAndGasCount.RightGasCount = 0;
            UsingGasRight = false;
        }
        if (swordAndGasCount.LeftGasCount < 0)
        {
            swordAndGasCount.LeftGasCount = 0;
            UsingGasLeft = false;
        }
       
        if(switchWeapons.HandsOn || switchWeapons.FlareOn || switchWeapons.MapOn)
        {
            UsingGasLeft = false;
            UsingGasRight = false;
            LeftHookShot = false;
            RightHookShot = false;
            GasSound.Stop();
        }

    }

    RaycastHit ViveLeftHit;
    RaycastHit ViveRightHit;

    RaycastHit OculusLeftHit;
    RaycastHit OculusRightHit;

    RaycastHit PCHit;
    RaycastHit GroundHit;

    public float RaycastGroundDistance;

    public float GasUsageSpeed;
    public float speed;
    public float RaycastDistance;
    public float turnspeed;
    [Header("Vive")]
    public Transform ViveRaycastStartLeft;
    public Transform ViveRaycastStartRight;
    [Header("Vive")]
    public Transform OcuRaycastStartLeft;
    public Transform OcuRaycastStartRight;
    [Header("PC")]
    public Transform PCRaycastStart;
    public Transform PCGroundRaycastStart;
    public Transform PCLeftHookStart;
    public Transform PCRightHookStart;
    public LineRenderer PCLeftLine;
    public LineRenderer PCRightLine;
    
    

    
    public bool UsingGasLeft;
    public bool UsingGasRight;

    public bool LeftHookShot;
    public bool RightHookShot;

    [Header("Objects")]
    public GameObject Hook;
    private GameObject LeftHook;
    private GameObject RightHook;

    [Header("SDKS")]
    public Rigidbody pcSdk;
    public Rigidbody viveSdk;
    public Rigidbody oculusSdk;

    public LineRenderer lineL;
    public LineRenderer lineR;




    public void VRODMShootHookRight()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
 
               
                if(ViveRightHit.collider.tag == "Hookable" && !RightHookShot)
                {
                    RightHookShot = true;
                    RightHook = Instantiate(Hook, ViveRightHit.point, Quaternion.identity);
                    HookSound.Play();
                }
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
              
              
                if (OculusRightHit.collider.tag == "Hookable" && !RightHookShot)
                {
                    RightHookShot = true;
                    RightHook = Instantiate(Hook, OculusRightHit.point, Quaternion.identity);
                    HookSound.Play();
                }
            }
        }
    }
    public void VRODMShootHookLeft()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
                if (ViveLeftHit.collider.tag == "Hookable" && !LeftHookShot)
                {
                    LeftHookShot = true;
                    LeftHook = Instantiate(Hook, ViveLeftHit.point, Quaternion.identity);
                    HookSound.Play();
                }
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
                if (OculusLeftHit.collider.tag == "Hookable" && !LeftHookShot)
                {
                    LeftHookShot = true;
                    LeftHook = Instantiate(Hook, OculusLeftHit.point, Quaternion.identity);
                    HookSound.Play();
                }
            }
        }
    }

    public void VRODMReleaseHookLeft()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
                Destroy(LeftHook);
                LeftHookShot = false;
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
                Destroy(LeftHook);
                LeftHookShot = false;
            }
        }
    }
    public void VRODMReleaseHookRight()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
                Destroy(RightHook);
                RightHookShot = false;
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
                Destroy(RightHook);
                RightHookShot = false;
            }
        }
    }

    public void VRODMGasRightPress()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
                
               
                    UsingGasRight = true;

              
            }
        }
        if (checkSdk.OCULUS)
        {
          
                    UsingGasRight = true;

           
        }
    }
    public void VRODMGasLeftPress()
    {
        if (checkSdk.VIVE)
        {
         
                    UsingGasLeft = true;


           
        }
        if (checkSdk.OCULUS)
        {
           
               
              
                    UsingGasLeft = true;

          
        }
    }

    public void VRODMGasRightRelease()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
               
                UsingGasRight = false;
                GasSound.Stop();
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
               
                UsingGasRight = false;
                GasSound.Stop();
            }
        }
    }
    public void VRODMGasLeftRelease()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.SwordsOn)
            {
                GasSound.Stop();
                UsingGasLeft = false;
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.SwordsOn)
            {
                GasSound.Stop();
                UsingGasLeft = false;
            }
        }
    }

}
