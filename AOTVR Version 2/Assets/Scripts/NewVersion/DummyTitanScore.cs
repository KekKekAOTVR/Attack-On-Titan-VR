using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTitanScore : MonoBehaviour {

  

    public ScoreController scoreController;
    public SpeedMoniter speed;
    public float RespawnTime;

    public GameObject NeckNotSlashed;
    public GameObject NeckSlashed;

    public AudioSource Slice;
	// Use this for initialization
	void Start () {
        scoreController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreController>();
        speed = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpeedMoniter>();
        NeckNotSlashed.GetComponent<MeshRenderer>().enabled = true;
        NeckSlashed.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade")
        {
            Destroy(GetComponent<BoxCollider>());
            if(scoreController.StreakCombo != 8) {
                scoreController.StreakCombo = scoreController.StreakCombo * 2;
            }

            NeckNotSlashed.GetComponent<MeshRenderer>().enabled = false;
            NeckSlashed.SetActive(true);

            scoreController.HitPoints = speed.Speed * scoreController.StreakCombo + scoreController.AmountforNoramlSlice;
            scoreController.TotalScore = scoreController.TotalScore + scoreController.HitPoints;

            StartCoroutine(RespawnTitan());

            Slice.Play();
        }
    }
  
    IEnumerator RespawnTitan()
    {
        RespawnTime = Random.Range(10, 20);
        yield return new WaitForSeconds(RespawnTime);
        gameObject.AddComponent<BoxCollider>().isTrigger = true;
        NeckNotSlashed.GetComponent<MeshRenderer>().enabled = true;
        NeckSlashed.SetActive(false);
    }
   
}
