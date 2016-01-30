using UnityEngine;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public int RemainingKeys = 0;
    
    void Update ()
	{
        if (RemainingKeys == 0)
	    {
	        Destroy(gameObject);
	    }
	}
}
