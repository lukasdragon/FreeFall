using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BoolVariable readyToSpawn;

    [SerializeField] private FloatVariable multiplier;
    [SerializeField] private FloatVariable playerScore;


    public GameObject hexagonPrefab;


    private int count = 0;


    // Update is called once per frame
    public void Spawn()
    {
        if (readyToSpawn.Value)
        {
            var prefab = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            prefab.gameObject.SetActive(true);
            readyToSpawn.Value = false;

            count++;
            CalculateMultiplier();
        }
    }


    private void CalculateMultiplier()
    {
        if (count < 50)
        {
            multiplier.Value = Mathf.Sqrt(playerScore.Value);
        }
        else
        {
            multiplier.Value = Mathf.Sqrt(count / 1.5f);
        }

    }

    private void Start()
    {
        readyToSpawn.SetValue(true);
    }
}