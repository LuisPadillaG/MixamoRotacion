using UnityEngine;

public class Goomba3 : MonoBehaviour
{
    GameObject jugador;
    Vector3 posicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        posicion = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(jugador.transform.position);
        this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0);

        // Goomba persigue al jugador
        posicion = Vector3.MoveTowards(this.transform.position, jugador.transform.position, Time.deltaTime * 2);
        posicion.y = 0;


        this.transform.position = posicion;
    }
}
