using System;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    CharacterController characterController;
    Vector3 velocidad, rotacion;
    public GameObject esfera;
    public Animator animator;
    int estado_objetivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        rotacion = Vector3.zero;
        estado_objetivo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        {

            // velocidad.x =1; 

            velocidad.x = Input.GetAxis("Horizontal") * 2.5f;

            velocidad.z = Input.GetAxis("Vertical") * 2.5f;

            if (characterController.isGrounded && estado_objetivo == 2)

            {

                estado_objetivo = 0;

            }

            if (velocidad.x == 0 && velocidad.z == 0)

            {

                if (estado_objetivo != 2)

                {

                    estado_objetivo = 0;

                }

            }

            else

            {

                if (estado_objetivo != 2)

                {

                    estado_objetivo = 1;

                }

                rotacion.y = Herramientas.CalcularAnguloBidimensional(new Vector2(0, 0), new Vector2(velocidad.x, velocidad.z));

            }

            velocidad.y -= 30 * Time.deltaTime;

            if (characterController.isGrounded)

            {

                if (Input.GetButtonDown("Jump"))

                {

                    velocidad.y = 10;

                    estado_objetivo = 2;

                }

            }

            if (estado_objetivo != animator.GetInteger("Estado"))

            {

                animator.SetInteger("Estado", estado_objetivo);

                animator.SetTrigger("CambiarEstado");

            }

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), 400 * Time.deltaTime);
            characterController.Move(velocidad * Time.deltaTime); 
        }

    }

}
