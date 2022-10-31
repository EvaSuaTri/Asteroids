using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationSpeed = 10;
    public GameObject bala;
    public GameObject boquilla;
    public GameObject particulasMuerte;
    public GameObject escudoNave;
    public bool tieneEscudo = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {   
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", false);
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate(bala, boquilla.transform.position, transform.rotation);
            Destroy(temp, 2.5f);
        }
       
    }

    public void Muerte()
    {

        GameObject temp = Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);


        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());
        }


    }
   

    IEnumerator Respawn_Coroutine()
    {
        collider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);

        collider.enabled = true;
        sprite.enabled = true;

        GameManager.instance.vidas -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);


        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Escudo")
        {
            collision.gameObject.GetComponent<PowerUpControler>().Muerte();
            EscudoPowerUpOn();
        }      
    }

    public void EscudoPowerUpOn()
    {
        tieneEscudo = true;
        escudoNave.SetActive(true);
        StartCoroutine(EscudoPowerDownRoutine());
    }
    public IEnumerator EscudoPowerDownRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        escudoNave.SetActive(false);
        tieneEscudo = false;
    }
   
}
