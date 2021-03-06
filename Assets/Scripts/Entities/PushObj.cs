﻿using UnityEngine;
using System.Collections;

public class PushObj : MonoBehaviour
{
    public bool HasBeenLaidDown;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!HasBeenLaidDown)
            {
                col.GetComponent<Player>().HasPushObj = true;
                Destroy(gameObject);
            }
            else
            {
                HasBeenLaidDown = false;
            }
        }
    }
}
