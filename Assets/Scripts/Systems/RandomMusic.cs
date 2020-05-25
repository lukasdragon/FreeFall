using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomMusic : MonoBehaviour
{
    private int _nextClip;
    private double _nextStartTime;

    private int _toggle;
    [SerializeField] private AudioClip[] audioClipArray;
    [SerializeField] private AudioSource[] audioSourceArray;
   

    private void Awake()
    {
        _nextStartTime = AudioSettings.dspTime;
    }

    private void Start()
    {
        var clipToPlay = audioClipArray[Random.Range(0, audioClipArray.Length)];
        var duration = (double) clipToPlay.samples / clipToPlay.frequency;
        _nextStartTime += duration;

        audioSourceArray[_toggle].clip = clipToPlay;
        audioSourceArray[_toggle].Play();


        _toggle = 1 - _toggle;
    }


    private void LateUpdate()
    {
        if (AudioSettings.dspTime > _nextStartTime - 1)
        {
            var clipToPlay = audioClipArray[_nextClip];

            // Loads the next Clip to play and schedules when it will start
            audioSourceArray[_toggle].clip = clipToPlay;
            audioSourceArray[_toggle].PlayScheduled(_nextStartTime);

            // Checks how long the Clip will last and updates the Next Start Time with a new value
            var duration = (double) clipToPlay.samples / clipToPlay.frequency;
            _nextStartTime += duration;

            // Switches the toggle to use the other Audio Source next
            _toggle = 1 - _toggle;

            // Random audio clip
            _nextClip = Random.Range(0, audioClipArray.Length);
        }
    }
}