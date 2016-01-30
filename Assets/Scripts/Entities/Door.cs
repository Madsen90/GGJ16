using UnityEngine;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public int RemainingKeys = 0;

    public int XOffset;
    public int YOffset;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
        Debug.Log("remaining keys: " + RemainingKeys);
	    if (RemainingKeys == 0)
	    {
	        Destroy(gameObject);
	    }
	}
}
