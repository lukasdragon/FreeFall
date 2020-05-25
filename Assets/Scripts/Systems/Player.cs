using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 600f;
    public float sensitivity = 5f;
    private float movement = 0f;
    [SerializeField]
    private FloatVariable playerScore;

    private void Start()
    {
        playerScore.Value = 0;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetAxis("Horizontal") > 0.01)
        {
            movement = Mathf.Lerp(movement, -1, Time.deltaTime * sensitivity);
         
        }else if (Input.GetAxis("Horizontal") < -0.01)
        {
            movement = Mathf.Lerp(movement, 1, Time.deltaTime * sensitivity);
        }
        else
        {
            movement = 0;
        }


        // movement = -Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Death();
    }




    private void Death()
    {
        float highScore = playerScore.Value;
        playerScore.Value = 0;

        if (highScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}