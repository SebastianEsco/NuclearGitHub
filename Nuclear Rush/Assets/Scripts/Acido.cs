using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acido : MonoBehaviour
{
    PlayerController playerController;
    GameObject controller;
    bool enAcido;

    void Start()
    {
        controller = GameObject.Find("Jugador");
        playerController = controller.GetComponent<PlayerController>();
    }

    public void Update()
    {
        if(enAcido)
        {
            playerController.VelocidadEnAcido();
        }
        else
        {
            playerController.VelocidadFueraDeAcido();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Acido")) //Entro en acido, revisar si en medio segundo sigue ahí
        {
            Debug.Log("Tocó Acido");
            playerController.VelocidadEnAcido();
            Invoke("SecuenciaDeMuerteEnAcido", 0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Acido")) //Revisar si sigue en acido
        {
            enAcido = true;
            playerController.puedeSaltar = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Acido"))
        {
            enAcido = false;
            if (playerController.vivo)
            {
                Debug.Log("Se salvó");
            }
            
        }
    }

    public void SecuenciaDeMuerteEnAcido()
    {
        if (enAcido) //Despues de medio segundo, sigue en el acido, iniciar matación
        {
            Debug.Log("Cagó");
            playerController.SecuenciaDeMuerteEnAcido();
        }
    }
}
