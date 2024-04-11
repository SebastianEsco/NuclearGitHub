using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FueraDeMapa : MonoBehaviour
{
    PlayerController controller;
    GameObject jugador;
    void Start()
    {
        jugador = GameObject.Find("Jugador");
        controller = jugador.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("GameOver"))
        {
            Debug.Log("TOCO EL TRIGGER GAMEOVER");
            controller.vivo = false;
        }
    }
}
