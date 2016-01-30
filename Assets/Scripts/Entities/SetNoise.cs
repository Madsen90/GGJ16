using UnityEngine;
using System.Collections;

public class SetNoise : MonoBehaviour
{
	public float VolumeTarget;

    private AudioSource ritual;
    private AudioSource noise;

    void Start ()
    {
        var sources = GameObject.Find("Camera").GetComponents<AudioSource>();
        ritual = sources[0];
        noise = sources[1];
    }

    void OnTriggerEnter2D()
    {
        noise.volume = Mathf.Max(noise.volume, VolumeTarget);
        ritual.volume = 1 - noise.volume;
    }
}
