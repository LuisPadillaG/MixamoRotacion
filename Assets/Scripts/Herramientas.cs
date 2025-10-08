using UnityEngine;

public class Herramientas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float CalcularAnguloBidimensional(Vector2 punto1, Vector2 punto2)
    {
        float cateto_opuesto = punto2.y - punto1.y;
        float cateto_adyacente = punto2.x - punto1.x;
        float hipotenusa = Mathf.Sqrt(Mathf.Pow(cateto_adyacente, 2) + Mathf.Pow(cateto_opuesto, 2));
        float seno;
        Debug.Log(cateto_opuesto + " " + cateto_adyacente);

        if (punto2.x > punto1.x)
        {
            seno = Mathf.Asin(cateto_opuesto / hipotenusa);
            return -seno * 57.2957795131f;
        }
        else
        {
            seno = -Mathf.Asin(cateto_opuesto / hipotenusa);
            return 180 - seno * 57.2957795131f;
        }
    }
}
