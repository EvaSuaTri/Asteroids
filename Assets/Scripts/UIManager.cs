using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = Time.time.ToString("00.00");
        if(GameManager.instance.vidas <= 0)
        {
            gameOver.SetActive(true);
            vidas.text = ("0");
        }
        if (GameManager.instance.vidas == 1)
        {
            vidas.text = ("1");
        }
        if (GameManager.instance.vidas == 2)
        {
            vidas.text = ("2");
        }

        puntuacion.text = GameManager.instance.puntuacion.ToString();
    }
}
