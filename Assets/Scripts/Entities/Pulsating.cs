using UnityEngine;
using System.Collections;

public class Pulsating : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    float t;


	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        t = Random.Range(0, Mathf.PI * 3);
    }
	
	void Update () {
        t += Time.deltaTime * 3;
        spriteRenderer.color = new Color(0.8f + Mathf.Sin(t) * 0.2f, 0.8f + Mathf.Sin(t) * 0.2f, 0.8f + Mathf.Sin(t) * 0.2f);
    }
}
