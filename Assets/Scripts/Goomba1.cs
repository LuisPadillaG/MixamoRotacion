using UnityEngine;

public class Goomba1 : MonoBehaviour
{
    GameObject jugador;
    Vector3 rotacion, posicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        rotacion = Vector3.zero;
        posicion = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(rotacion);
        rotacion.y = Herramientas.CalcularAnguloBidimensional(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(jugador.transform.position.x, jugador.transform.position.z));

        posicion.x += Mathf.Cos(rotacion.y * Mathf.Deg2Rad) * Time.deltaTime * 2.5f;
        posicion.z -= Mathf.Sin(rotacion.y * Mathf.Deg2Rad) * Time.deltaTime * 2.5f;
        this.transform.position = posicion;
    }
}
