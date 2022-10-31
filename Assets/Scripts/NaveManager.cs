using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveManager : MonoBehaviour
{

   
    public float limitX = 9.23f;
    public float limitY = 5.3f;
    public GameObject naveEnemiga;
    private bool nave = true;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nave)
        {
            if (GameManager.instance.puntuacion >= 1000)
            {
                CrearNave();
                nave = false;
                Invoke("NuevaNave", 60f);
                
            }
        }

        

    }

    void CrearNave()
    {
     
        Vector3 position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

        Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 0f));
        GameObject temp = Instantiate(naveEnemiga, position, Quaternion.Euler(rotation));
        temp.GetComponent<NaveControler>().manager = this;

    }

    void NuevaNave()
    {
        nave = true;
    }
}
