using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareBulletDestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyFlare());
	}
	IEnumerator DestroyFlare()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }

}
