using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareScript : MonoBehaviour {

    private CheckSDK checkSdk;
    private SwitchWeapons switchWeapons;

	// Use this for initialization
	void Start () {

        checkSdk = GetComponent<CheckSDK>();
        switchWeapons = GetComponent<SwitchWeapons>();
        
	}
	
	// Update is called once per frame
	void Update () {
        PCFlare();
        
	}

 

    public void PCFlare()
    {
        if (checkSdk.PC)
        {
            if (switchWeapons.FlareOn)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("Shoot");
                    if (!fired)
                    {
                        fired = true;
                        StartCoroutine(FlareReloadDelay());
                        barrelEndPC.gameObject.GetComponent<AudioSource>().PlayOneShot(flareShotSound);
                        Rigidbody bulletInstance;
                        bulletInstance = Instantiate(flareBullet, barrelEndPC.position, barrelEndPC.rotation) as Rigidbody; //INSTANTIATING THE FLARE PROJECTILE
                        bulletInstance.AddForce(barrelEndPC.forward * bulletSpeed); //ADDING FORWARD FORCE TO THE FLARE PROJECTILE
                        Instantiate(muzzleParticles, barrelEndPC.position, barrelEndPC.rotation);   //INSTANTIATING THE GUN'S MUZZLE SPARKS

                    }
                }              
            }
        }
        
    }

    public Rigidbody flareBullet; 
    public GameObject muzzleParticles;
    public AudioClip flareShotSound;
    public int bulletSpeed = 2000;

    public Transform barrelEndVive;
    public Transform barrelEndOculus;
    public Transform barrelEndPC;

    public bool fired;

    public void VRFlare()
    {
        if (checkSdk.VIVE)
        {
            if (switchWeapons.FlareOn)
            {
             
                if (!fired)
                {
                    barrelEndVive.gameObject.GetComponent<AudioSource>().PlayOneShot(flareShotSound);
                    Rigidbody bulletInstance;
                    bulletInstance = Instantiate(flareBullet, barrelEndVive.position, barrelEndVive.rotation) as Rigidbody; //INSTANTIATING THE FLARE PROJECTILE
                    bulletInstance.AddForce(barrelEndVive.forward * bulletSpeed); //ADDING FORWARD FORCE TO THE FLARE PROJECTILE
                    Instantiate(muzzleParticles, barrelEndVive.position, barrelEndVive.rotation);   //INSTANTIATING THE GUN'S MUZZLE SPARKS
                    fired = true;
                    StartCoroutine(FlareReloadDelay());
                }
            }
        }
        if (checkSdk.OCULUS)
        {
            if (switchWeapons.FlareOn)
            {
            
         if (!fired)
                {
                    barrelEndOculus.gameObject.GetComponent<AudioSource>().PlayOneShot(flareShotSound);
                Rigidbody bulletInstance;
                bulletInstance = Instantiate(flareBullet, barrelEndOculus.position, barrelEndOculus.rotation) as Rigidbody; //INSTANTIATING THE FLARE PROJECTILE
                bulletInstance.AddForce(barrelEndOculus.forward * bulletSpeed); //ADDING FORWARD FORCE TO THE FLARE PROJECTILE
                Instantiate(muzzleParticles, barrelEndOculus.position, barrelEndOculus.rotation);   //INSTANTIATING THE GUN'S MUZZLE SPARKS	
                    fired = true;
                    StartCoroutine(FlareReloadDelay());
            }
        }
        }
    }
    public float delay;
    IEnumerator FlareReloadDelay()
    {
        yield return new WaitForSeconds(delay);
        fired = false;
    }




}
