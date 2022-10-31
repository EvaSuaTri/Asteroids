using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int asteroides_min = 2;
    public int asteroides_max = 4;
    public int asteroides;
    public float limitX = 10;
    public float limitY = 5;
    public GameObject asteroide;
    // Start is called before the first frame update
    void Start()
    {
      

        
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroides <= 0)
        {
            asteroides_min += 2;
            asteroides_min += 4;
            CrearAsteroides();
        }
    }

    void CrearAsteroides()
    {
        int asteroides = Random.Range(asteroides_min, asteroides_max);

        for (int i = 0; i < asteroides; i++)
        {
            
            Debug.Log("Instanciando asteoide:" + i);
            Vector3 position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while(Vector3.Distance(position, new Vector3 (0, 0))<2)
            {
                position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }

            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroide, position, Quaternion.Euler(rotation));
            temp.GetComponent<AsteroidControler>().manager = this;
        }
    }
}
