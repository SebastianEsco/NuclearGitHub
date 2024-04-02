using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 posicionInicial;
    Piso piso;
    Rigidbody rb;
    [SerializeField] float cantidadQueVaria, velocidadDeRecuperacion;
    public float fuerzaSalto;
    public bool puedeSaltar = true;
    private void Start()
    {
        piso = GetComponent<Piso>();
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }


    void Update()
    {
        Vector3 posicion = transform.position;
        

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
                piso.velocidad = piso.velocidadInicial + cantidadQueVaria;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //Debug.Log("Presionando A");
                piso.velocidad = piso.velocidadInicial - cantidadQueVaria;
            }
        }
        else
        {
            piso.velocidad = piso.velocidadInicial;
        }

        RaycastHit hit; //Castear Rasho laser
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1f, 1)) //Tirar el rayo para abajo
        {
            puedeSaltar = true; //Si le está pegando al suelo, puede saltar
        }
        
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar) //Apretar W y estar en el suelo
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode.Impulse);
            puedeSaltar = false;
        }


        if(transform.position.x < posicionInicial.x)
        {
            transform.position = new Vector3(posicion.x + (velocidadDeRecuperacion * Time.deltaTime), posicion.y, posicion.z);
        }
    }

}
