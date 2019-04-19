using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    
 

    private CheckSDK checkSDK;

    public GameObject PCmenu;
    public GameObject Vivemenu;
    public GameObject Oculusmenu;

    private bool Vive;
    private bool Oculus;

	// Use this for initialization
	void Start () {
        checkSDK = GetComponent<CheckSDK>();

        PCmenu.SetActive(false);
        Vivemenu.SetActive(false);
        Oculusmenu.SetActive(false);
        if (checkSDK.OCULUS)
        {
            RadialMenu.Rotate(45, 0, 0);
        }
     
	}
    public Transform RadialMenu;
	// Update is called once per frame
	void Update () {
        if (checkSDK.PC)
        {
            PCMenu();
    
        }
        else if (checkSDK.VIVE)
        {
            Vive = true;
            Oculus = false;
           
        }
        else if (checkSDK.OCULUS)
        {
            Vive = false;
            Oculus = true;

           
            
        }
	}

    public bool On = false;

    public void PCMenu()
    {


        if (!On)
        {
           
            if (Input.GetKeyDown(KeyCode.Escape)){

                PCmenu.SetActive(true);
                On = true;
                
            }
        }
        else if (On)
        {
            if (Input.GetKeyDown(KeyCode.Escape)){

                PCmenu.SetActive(false);
                On = false;
                
            }
          


        }
        
    }
    public void VRMenu()
    {
        if (!On)
        {

            if (Vive)
            {
                Vivemenu.SetActive(true);
                On = true;
            }
            else if (Oculus)
            {
                Oculusmenu.SetActive(true);
                On = true;
            }



        }
      
        
        
      

        else if (On)

        {
            if (Vive)
            {
                Vivemenu.SetActive(false);
                On = false;
            }

            if (Oculus)
            {

                Oculusmenu.SetActive(false);
                On = false;
            }

        }
        
         
        
      
        
    }
}
