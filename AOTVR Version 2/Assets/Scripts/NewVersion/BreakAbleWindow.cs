using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAbleWindow : MonoBehaviour {

    public int SpeedNeedToBreak = 10;

    public GameObject BrokenWindow;
    public Transform BrokenWindowPosition;
    public GameObject NotBrokenWindow;
    private GameObject WindowBroken;
	// Update is called once per frame
	void Update () {
		
	}
    private void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SDKPlayer")
        {
           
           // if(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > SpeedNeedToBreak)
           // {
                StartCoroutine(RespawnGlass());
            //}
        }
    }
    IEnumerator RespawnGlass()
    {
        
        gameObject.GetComponent<BoxCollider>().enabled = false;
        WindowBroken = Instantiate(BrokenWindow, BrokenWindowPosition.position,BrokenWindowPosition.rotation);
        WindowBroken.transform.SetParent(NotBrokenWindow.transform.parent,false);
        WindowBroken.transform.position = BrokenWindowPosition.position;
        NotBrokenWindow.SetActive(false);

        yield return new WaitForSeconds(20);

        NotBrokenWindow.SetActive(true);
        Destroy(WindowBroken);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
