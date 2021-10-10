using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMechanic : MonoBehaviour
{

    public Transform brokenObject;
    public float magnitudeCol, radius, power, upwards;

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
        Instantiate(brokenObject, transform.position, transform.rotation);
        //brokenObject.localScale = transform.localScale;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            if (hit.attachedRigidbody)
            {
                hit.attachedRigidbody.AddExplosionForce(power, explosionPos, radius, upwards);
            }
        }
    }

}
