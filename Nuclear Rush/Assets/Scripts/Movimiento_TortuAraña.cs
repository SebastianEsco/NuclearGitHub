using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_TortuAraña : MonoBehaviour
{
    Piso piso;
    Rigidbody rb;
    public float fuerzaSalto;
    public bool puedeSaltar = true;
   // float gravedadInicial; // Almacena el valor de la gravedad inicial
    public float gravedadW = 90f;
    public float gravedadS = -90f;
    public float gravedadActual;

    private void Start()
    {
        piso = GetComponent<Piso>();
        rb = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        Debug.Log(Physics.gravity);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                piso.velocidad = piso.velocidadInicial;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                piso.velocidad = piso.velocidadInicial + 2;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                piso.velocidad = piso.velocidadInicial - 2;
            }
        }
        else
        {
            piso.velocidad = piso.velocidadInicial;
        }


        if (Input.GetKeyDown(KeyCode.S) && puedeSaltar)
        {
            if(gravedadW < 0)
            {
                gravedadActual = (gravedadW); // Invierte el valor de la gravedad -(gravedad)
                Physics.gravity = new Vector3(0, gravedadActual, 0); // Aplica la nueva gravedad
                puedeSaltar = true;
                
            }
            Debug.Log("presion tecla w");

            //Debug.Log(gravedad);
            //gravedad = 90f;
        }

        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar)
        {
            if(gravedadS > 0)
            {
                gravedadActual = gravedadS; // Restaura la gravedad inicial
                Physics.gravity = new Vector3(0, gravedadActual, 0); // Aplica la nueva gravedad
                puedeSaltar = true;
                Debug.Log("Cambio con tecla S");
            }
            Debug.Log("presion tecla s");
           // gravedad = -90f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        puedeSaltar = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        puedeSaltar = false;
    }
}