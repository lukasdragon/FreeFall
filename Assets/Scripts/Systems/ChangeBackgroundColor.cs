using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour
{
    bool _doColorSwitch;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    float TimeUntilStart = 16.8f;


    private int beat = 0;
    
    public void UpdateColor()
    {
        beat++;
        if (beat > 2 && _doColorSwitch)
        {
            cam.backgroundColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            beat = 0;
        }
        else if (Time.timeSinceLevelLoad >= TimeUntilStart)
        {
            _doColorSwitch = true;
        }
    }
}