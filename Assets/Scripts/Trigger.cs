using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerExit(Collider kol)
    {
        if (kol.gameObject.CompareTag("Sphere")) 
        {
            Invoke("Putoaminen", 0.5f);
        }
    }

    void Putoaminen()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            Rigidbody parentRigidbody = parentTransform.GetComponent<Rigidbody>();
            if (parentRigidbody != null)
            {
                parentRigidbody.useGravity = true;
                parentRigidbody.isKinematic = false;
            }
            Destroy(parentTransform.gameObject, 2f);
        }
    }
}