using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameranSeuranta : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 2f;

    private bool follow = true;

    void LateUpdate()
    {
        if (follow && target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }

    public void StopFollowing()
    {
        follow = false;
    }
}