using UnityEngine;
using System.Collections;

public class SetNoise : MonoBehaviour
{
	public int VolumeTarget;

    private AudioSource source;

    void Start ()
    {
        source = GameObject.Find("Camera").GetComponents<AudioSource>()[1];
    }

    void OnTriggerEnter()
    {
        source.volume = Mathf.Max(source.volume, VolumeTarget);
    }
}
