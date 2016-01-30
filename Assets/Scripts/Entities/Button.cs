using UnityEngine;
using System.Collections;

public class Button : Key {
    
    public override void OnTriggerEnter2D(Collider2D col)
    {
        Door.RemainingKeys--;
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        Door.RemainingKeys++;
    }
}
