using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    [SerializeField] float projectingForce;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Slicable")
        {
            Debug.Log("Spatula Colidiu");
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * projectingForce, ForceMode.Impulse);
            rb.AddForce(Vector3.right * projectingForce, ForceMode.Impulse);
        }
    }
}
