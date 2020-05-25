using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;


public class ScoreTimer : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;


    private int beats;


    // Update is called once per frame
    public void beat()
    {
        beats++;
        if (beats > 2)
        {
            playerScore.SetValue(playerScore.Value + 0.1f);

            beats = 0;
        }
    }
}