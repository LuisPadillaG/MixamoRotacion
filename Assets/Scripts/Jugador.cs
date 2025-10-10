using System;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    CharacterController characterController;
    Vector3 velocidad, rotacion;
    public GameObject esfera;
    public Animator animator;
    int estado_objetivo;
    GameObject camara;
    GameObject objetoRotaYcamara; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        rotacion = Vector3.zero;
        estado_objetivo = 0;
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        objetoRotaYcamara = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        {
            objetoRotaYcamara.transform.rotation = camara.transform.rotation;
            Vector3 rotacionTemporal = new Vector3(0, objetoRotaYcamara.transform.eulerAngles.y, 0);
            objetoRotaYcamara.transform.rotation = Quaternion.Euler(rotacionTemporal);
            //Debug.Log(camara.transform.TransformDirection(new Vector3(1,0,0)));
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
                Vector3 vectorVer = objetoRotaYcamara.transform.TransformDirection(velocidad);
                rotacion.y = Herramientas.CalcularAnguloBidimensional(Vector2.zero, new Vector2(vectorVer.x, vectorVer.z));

            } 
            if (characterController.isGrounded) 
            { 
                if (Input.GetButtonDown("Jump")) 
                { 
                    velocidad.y = 10; 
                    estado_objetivo = 2; 
                } 
            }
            else
            {
                velocidad.y -= 30 * Time.deltaTime;
            } 
            if (estado_objetivo != animator.GetInteger("Estado")) 
            { 
                animator.SetInteger("Estado", estado_objetivo); 
                animator.SetTrigger("CambiarEstado"); 
            }

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), 400 * Time.deltaTime);
            characterController.Move(objetoRotaYcamara.transform.TransformDirection(velocidad) * Time.deltaTime); 
        } 
    } 
}
