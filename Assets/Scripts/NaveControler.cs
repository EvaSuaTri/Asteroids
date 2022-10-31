using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControler : MonoBehaviour
{

    public float speed = 1f;
    Rigidbody2D rb;
    public NaveManager manager;
    public GameObject balaEnemiga;
    public GameObject boquillaEnemiga;
    private bool disparo = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcction = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 0f));
        direcction = direcction * speed;
        rb.AddForce(direcction);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (disparo)
        {
            GameObject temp = Instantiate(balaEnemiga, boquillaEnemiga.transform.position, transform.rotation);
            Destroy(temp, 1f);
            disparo = false;
            Invoke("Disparo", 0.5f);
        }
        
    }

    public void Muerte()
    {        
        GameManager.instance.puntuacion += 400;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();

        }
    }

    private void Disparo()
    {
        disparo = true;
    }
}
