using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float limitX = 8.5f;
    public float limitY = 4.5f;
    public GameObject powerUp;
    private bool powerUpC = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpC)
        {
            if (GameManager.instance.puntuacion >= 1000)
            {
                CrearPowerUp();
                powerUpC = false;
                Invoke("NuevoPowerUp", 30f);

            }
        }
    }

    void CrearPowerUp()
    {

        Vector3 position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

        Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 0f));
        GameObject temp = Instantiate(powerUp, position, Quaternion.Euler(rotation));
        temp.GetComponent<PowerUpControler>().manager = this;

    }

    void NuevoPowerUp()
    {
        powerUpC = true;
    }
}
