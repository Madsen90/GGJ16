using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public Door Door;
	void Awake ()
	{
	    Door.RemainingKeys++;
	}

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Door.RemainingKeys--;
            Destroy(gameObject);
        }
    }
}
