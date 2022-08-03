using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
        }
    }
}
