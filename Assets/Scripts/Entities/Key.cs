using System.Collections.Generic;

using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public List<Door> Doors;
    float t;

    void Awake()
    {
        Doors.ForEach(door => door.RemainingKeys++);
        t = Random.Range(0, Mathf.PI * 2);
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Doors.ForEach(door => door.RemainingKeys--);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        t += Time.deltaTime;
        var x = Mathf.Cos(t * 2) * Time.deltaTime * 0.1f;
        var y = Mathf.Cos(t * 1.6f) * Time.deltaTime * 0.1f;

        transform.Translate(x, y, 0);
    }
}
