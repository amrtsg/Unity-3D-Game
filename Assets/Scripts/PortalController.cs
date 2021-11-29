/*
PortalController.cs
Author - Amr Ghoneim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    //public Vector3 rotationDirection;
    //public float rotationSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //rotationSpeed = 3f;
        //rotationDirection = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(rotationDirection * Time.deltaTime * rotationSpeed);
    }

    void OnCollisionEnter(Collision col) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
