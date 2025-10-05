using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallonhallinta : MonoBehaviour
{
    private bool liikkuu = false; // EI LIIKU ENNENKUN KLIKKAA
    public float speed = 6f;      // PALLON VAUHTI
    private Vector3 direction;    // PALLON SUUNTA
    private int score = 0; // PISTEEN LASKU
    public float raycastDistance = 1.1f; // TARAKASTAA ONKO PALLO ALUSTALLA

    void Start()
    {
        liikkuu = false;
        direction = Vector3.right;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!liikkuu)
            {
                liikkuu = true;
            }
            else
            {
                direction = direction == Vector3.right ? Vector3.forward : Vector3.right;
            }
        }

        if (liikkuu)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (!palloAlustalla())
        {
            GameOver();
        }
    }

    bool palloAlustalla()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }

    void GameOver()
    {
        liikkuu = false;
        Debug.Log("Peli loppui!");

    }

    void OnTriggerEnter(Collider jotain)
    {
        if (jotain.gameObject.CompareTag("Diamond"))
        {
            Destroy(jotain.gameObject);
            score += 1;
            Debug.Log("Score: " + score);
        }
    }

    /*

     KOOODI NÄYTTI TÄLTÄ KUN YRITIN SAADA PARTIKKELIA, MUTTA EN SAANUT TOIMIMAAN NIIN PALASIN KOODISSA TAKAISIN ETTEN HAJOTA SITÄ ENEMPÄÄ

        void OnTriggerEnter(Collider jotain)
    {
        if (jotain.gameObject.CompareTag("Diamond"))
        {
            GameObject osa = Instantiate(partikkeli, jotain.gameObject.transform.position, Quaternion.identity);

            if (jotain.gameObject != null)
            {
                Destroy(jotain.gameObject);
                Destroy(osa.gameObject, 1f);
            }

            score += 1;
            Debug.Log("Score: " + score);
        }
    }


    */
}