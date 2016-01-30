using UnityEngine;
using System.Collections;

public class FreezeObj : MonoBehaviour {
    public bool HasBeenLaidDown;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!HasBeenLaidDown)
            {
                col.GetComponent<Player>().HasFreezeObj = true;
                Destroy(gameObject);
            }
            else
            {
                HasBeenLaidDown = false;
            }
        }
    }
}
