using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject alusta;
    public GameObject timantti;
    private Vector3 viimeinenSijainti;
    private float koko;
    private bool peliLoppu = false;
    private Rigidbody alustaRigidbody; 

    void Start()
    {
        viimeinenSijainti = alusta.transform.position;
        koko = alusta.transform.localScale.x;


        alustaRigidbody = alusta.GetComponent<Rigidbody>();
        alustaRigidbody.isKinematic = true; 

   
        for (int i = 0; i < 20; i++)
        {
            AlustaSiirtymat();  
        }

        InvokeRepeating("AlustaSiirtymat", 2f, 0.2f); 
    }

    void Update()
    {

        if (peliLoppu)
        {
            CancelInvoke("AlustaSiirtymat");
        }
    }

    void SiirtymaX()
    {
        Vector3 sij = viimeinenSijainti;
        sij.x += koko;
        viimeinenSijainti = sij;


        GameObject newPlatform = Instantiate(alusta, sij, Quaternion.identity);
        newPlatform.GetComponent<Rigidbody>().isKinematic = true;

        int sat = Random.Range(0, 4);
        if (sat < 1)
        {
            Instantiate(timantti, new Vector3(sij.x, sij.y + 1, sij.z), timantti.transform.rotation);
        }
    }

    void SiirtymaZ()
    {
        Vector3 sij = viimeinenSijainti;
        sij.z += koko;  
        viimeinenSijainti = sij;


        GameObject newPlatform = Instantiate(alusta, sij, Quaternion.identity);
        newPlatform.GetComponent<Rigidbody>().isKinematic = true;

        int sat = Random.Range(0, 4);
        if (sat < 1)
        {
            Instantiate(timantti, new Vector3(sij.x, sij.y + 1, sij.z), timantti.transform.rotation);
        }
    }

    void AlustaSiirtymat()
    {
        if (peliLoppu)
        {
            return;  
        }

        int randomDirection = Random.Range(0, 6); 

        if (randomDirection < 3)
        {
            SiirtymaX();  
        }
        else
        {
            SiirtymaZ(); 
        }
    }

  
    public void EnableGravityOnPlatform(GameObject platform)
    {
        Rigidbody rb = platform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    void OnTriggerExit(Collider kol)
    {
        if (kol.gameObject.CompareTag("Sphere"))  
        {
            EnableGravityOnPlatform(gameObject);
        }
    }
}