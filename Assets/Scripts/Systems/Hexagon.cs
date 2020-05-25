using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;

    [SerializeField]
    private FloatVariable playerScore;

    [SerializeField] private FloatVariable multiplier;
    
    
    [SerializeField]
    private BoolVariable readyToSpawn;



    // Use this for initialization
    void Start () {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;

        shrinkSpeed = (playerScore.Value / (multiplier.Value + 1)) + 1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= 0.3f)
        {
	        playerScore.SetValue(playerScore.Value + 1);
	        readyToSpawn.Value = true;
            Destroy(gameObject);
        }

	}
}
