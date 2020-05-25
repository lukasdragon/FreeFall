using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityAtoms.BaseAtoms;


public class UIScore : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI highScoreText;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private FloatVariable playerScore;


    // Use this for initialization
    void Start () {
        highScoreText.text = "HIGH-SCORE: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0.00"); //2dp Number;
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "SCORE: " + playerScore.Value.ToString("0.00"); //2dp Number;
    }
}
