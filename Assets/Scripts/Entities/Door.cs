using UnityEngine;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public int RemainingKeys = 0;
    private Vector3 _initpos;
    void Start()
    {
        _initpos = transform.position;
    }
    
    void Update ()
	{
        if (RemainingKeys == 0)
        {
            transform.position = new Vector3(9999,9999,0);
        }
        else
        {
            transform.position = _initpos;
        }
	}
}
