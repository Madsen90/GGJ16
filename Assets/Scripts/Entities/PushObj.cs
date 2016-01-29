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
                GameObject player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().hasPushObj = true;
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
