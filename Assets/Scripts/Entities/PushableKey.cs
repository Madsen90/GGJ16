using UnityEngine;
using System.Collections;

public class PushableKey : Pushable
{
    public Door Door;

    void Awake()
    {
        Door.RemainingKeys++;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Door.RemainingKeys--;
            Destroy(gameObject);
        }
    }
}
