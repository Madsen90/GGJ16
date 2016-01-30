using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public Door Door;
    float t;

    void Awake()
    {
        Door.RemainingKeys++;
        t = Random.Range(0, Mathf.PI * 2);
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Door.RemainingKeys--;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        t += Time.deltaTime;
        var x = Mathf.Cos(t * 2) * Time.deltaTime * 0.4f;
        var y = Mathf.Cos(t * 1.6f) * Time.deltaTime * 0.4f;

        transform.Translate(x, y, 0);
    }
}
