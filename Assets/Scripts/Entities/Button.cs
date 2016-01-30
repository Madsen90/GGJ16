using UnityEngine;
using System.Collections;

public class Button : Key
{
    public Sprite off, on;

    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {

        GetComponent<SpriteRenderer>().sprite = on;
        Door.RemainingKeys--;
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        GetComponent<SpriteRenderer>().sprite = off;

        Door.RemainingKeys++;
    }
}
