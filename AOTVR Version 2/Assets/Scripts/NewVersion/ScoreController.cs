using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour {

    public float TotalScore;
    public float HitPoints;
    public float StreakCombo = 1;
    public float AmountforNoramlSlice = 50;
    public float StreakDecrease;

    public Text Totalscore;
    public Text Hitpoints;
    public Text Streakcombo;
    public Text Totalscore2;
    public Text Hitpoints2;
    public Text Streakcombo2;
    // Use this for initialization
    void Start () {
        StartCoroutine(Streak());
        TotalScore = 0;
        HitPoints = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Totalscore.text = TotalScore.ToString();
        Totalscore2.text = TotalScore.ToString();
        Hitpoints.text = HitPoints.ToString();
        Hitpoints2.text = HitPoints.ToString();
        Streakcombo.text = StreakCombo.ToString();
        Streakcombo2.text = StreakCombo.ToString();
    }
    IEnumerator Streak()
    {

        yield return new WaitForSeconds(StreakDecrease);
        if (StreakCombo != 1)
        {
            StreakCombo = StreakCombo / 2;
        }
        StartCoroutine(Streak());
    }
}
