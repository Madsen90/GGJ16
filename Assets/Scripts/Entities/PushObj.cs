using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player":
                break;
            default:
                break;
        }
    }
}
