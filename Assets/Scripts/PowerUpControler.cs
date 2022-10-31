using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpControler : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;
    public PowerUpManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direcction = direcction * speed;
        rb.AddForce(direcction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Muerte()
    {        
        Destroy(gameObject);
    }

}
