using UnityEngine;

public class Camara : MonoBehaviour
{
    GameObject jugador;
    Vector3 rotacion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        jugador = GameObject.FindGameObjectWithTag("Player"); 
        rotacion = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = jugador.transform.position;
        rotacion.y -= Input.GetAxis("HorizontalCamara") * 100 * Time.deltaTime;
        rotacion.x -= Input.GetAxis("VerticalCamara") * 100 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q)) {
            rotacion.y = 0; 
        }
        /*if (Input.GetKey(KeyCode.L))
        {
            rotacion.y += 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            rotacion.y -= 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.I))
        {
            rotacion.y += 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotacion.y -= 100 * Time.deltaTime;
        }*/
        this.transform.rotation = Quaternion.Euler(rotacion);
    }
}
