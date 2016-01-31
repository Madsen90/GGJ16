using System;

using UnityEngine;
using System.Collections;

public class SetNoise : MonoBehaviour
{
	public float VolumeTarget;
    public float FadeDuration = 2;

    private AudioSource ritual;
    private AudioSource noise;

    private float timeLeft;
    private float startVolume;

    void Start ()
    {
        var sources = GameObject.Find("Camera").GetComponents<AudioSource>();
        ritual = sources[0];
        noise = sources[1];
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            var progress = (FadeDuration - timeLeft) / FadeDuration; //0,1
            var delta = VolumeTarget - startVolume; //1-0 = 1
            noise.volume = startVolume + delta * progress; // 0+1*0,1 = 0,1

            Debug.Log(String.Format("progress: {0}, delta: {1}, volume: {2}", progress, delta, noise.volume));

            timeLeft -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D()
    {
        if (noise.volume > VolumeTarget) return;
        timeLeft = FadeDuration;
        startVolume = noise.volume;
        Debug.Log(String.Format("FadeDuration: {0}, startVolume: {1}", FadeDuration, startVolume));
    }
}
