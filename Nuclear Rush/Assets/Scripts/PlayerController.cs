using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Piso piso;
    Rigidbody rb;
    public float fuerzaSalto;
    private void Start()
    {
        piso = GetComponent<Piso>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Presionando A o D");
            if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
               // Debug.Log("Presionando A y D");
                piso.velocidad = piso.velocidadInicial;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("Presionando D");
                piso.velocidad = piso.velocidadInicial + 2;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //Debug.Log("Presionando A");
                piso.velocidad = piso.velocidadInicial - 2;
            }
        }
        else
        {
            piso.velocidad = piso.velocidadInicial;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode.Impulse);
        }
    }
}
