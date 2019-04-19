using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCHorseScript : MonoBehaviour {

    private CheckSDK checkSdk;
    private SwitchWeapons switchWeapons;

    public bool OnHorse;

    RaycastHit PCHit;

    public GameObject horse;

    // Use this for initialization
    void Start()
    {
        checkSdk = GetComponent<CheckSDK>();
        switchWeapons = GetComponent<SwitchWeapons>();

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (checkSdk.PC)
        {

            if (switchWeapons.HandsOn)
            {
                CreateRaycast();
                GetOnHorse();
            }
            if (OnHorse)
            {
                OnHorseControl();

            }

        }

        if (OnHorse && !StandingOnHorse)
        {
            PcSdk.position = HorseSeat.position;
            PcSdk.rotation = HorseSeat.rotation;
        }
        if (OnHorse && StandingOnHorse)
        {
            PcSdk.position = StandingOnHorseSeat.position;
            PcSdk.rotation = StandingOnHorseSeat.rotation;
        }

    }

    public Transform PCRaycastStart;
    public float RaycastDistance;
    public Transform HorseSeat;
    public Transform PcSdk;
    public Transform OffHorseSeat;
    public Transform StandingOnHorseSeat;
    public Transform PcParent;
    public float PlayerSensitivy;
    public void CreateRaycast()
    {
        Debug.Log("CreateRaycast");
        Physics.Raycast(PCRaycastStart.position, PCRaycastStart.forward, out PCHit, RaycastDistance);
    }
    public void GetOnHorse()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PCHit.collider.tag == "Saddle")
            {
                if (!OnHorse)
                {
                    OnHorse = true;
                    Debug.Log("GetOnHorse");
                    horse.transform.rotation = PcSdk.transform.rotation;
                    PcSdk.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    horse.GetComponent<PCWalker>().enabled = true;
                    horse.GetComponent<PCController>().enabled = true;
                    PcSdk.gameObject.GetComponent<PCWalker>().enabled = false;
                    PcSdk.gameObject.GetComponent<PCController>().enabled = false;
                    PcSdk.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    PcSdk.parent = horse.transform;
                    PcSdk.transform.eulerAngles = new Vector3(0, 0, 0);
                    PcSdk.gameObject.GetComponent<PCController>().sensitivityX = 0;
                }


            }
            else if (OnHorse)
            {
                OnHorse = false;
                Debug.Log("GetOffHorse");
                StandingOnHorse = false;
                PcSdk.position = OffHorseSeat.position;
                PcSdk.gameObject.GetComponent<Rigidbody>().useGravity = true;
                horse.GetComponent<PCWalker>().enabled = false;
                horse.GetComponent<PCController>().enabled = false;
                PcSdk.gameObject.GetComponent<PCWalker>().enabled = true;
                PcSdk.gameObject.GetComponent<PCController>().enabled = true;
                PcSdk.gameObject.GetComponent<CapsuleCollider>().enabled = true;
                PcSdk.parent = PcParent;
                PcSdk.gameObject.GetComponent<PCController>().sensitivityX = PlayerSensitivy;
            }




        }

    }

    public bool StandingOnHorse;
    public void OnHorseControl()
    {
        if (StandingOnHorse)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("SitOnHorse/SwitchToHands");
                
                StandingOnHorse = false;
            }
        }
        else if (!StandingOnHorse)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("StandOnHorse/SwitchToSwords");

                StandingOnHorse = true;
            }
       
        }
    }
}
