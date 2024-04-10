using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Pajaro : MonoBehaviour
{

    Piso piso;
    Rigidbody rb;
    public float fuerzaSalto;
    //public bool puedeSaltar = true;
    // float gravedadInicial; // Almacena el valor de la gravedad inicial
    public float velocidadCaida = 3f;
    public float velocidadSubida = 5f;
    private bool subiendo = false;

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


        //if (Input.GetKeyDown(KeyCode.S) )
        //{
        //    if (gravedadW < 0)
        //    {
        //        gravedadActual = (gravedadW); // Invierte el valor de la gravedad -(gravedad)
        //        Physics.gravity = new Vector3(0, gravedadActual, 0); // Aplica la nueva gravedad


        //    }
        //    Debug.Log("presion tecla w");

        //    //Debug.Log(gravedad);
        //    //gravedad = 90f;
        //}

        if (Input.GetKeyDown(KeyCode.W))
        {
            subiendo = true;
            rb.velocity = new Vector3(0, velocidadSubida, 0); // Aplica velocidad de subida
        }

        // Si se suelta la tecla W o si el pájaro no está subiendo, cae con la gravedad normal
        if (Input.GetKeyUp(KeyCode.W) || !subiendo)
        {
            rb.velocity += Vector3.down * velocidadCaida * Time.deltaTime; // Aplica gravedad
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    puedeSaltar = true;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    puedeSaltar = false;
    //}
}
