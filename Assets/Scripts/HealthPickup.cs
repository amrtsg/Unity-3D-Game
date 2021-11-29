/*
HealthPickup.cs
Author - Amr Ghoneim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerManager playerScript;
    public GameObject player;
    public Vector3 rotationDirection;
    public float rotationSpeed = 3f;
    public float extraHealthAmount;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 3f;
        extraHealthAmount = 50f;
        playerScript = player.GetComponent<PlayerManager>();
        rotationDirection = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection * Time.deltaTime * rotationSpeed);
    }

    void OnCollisionEnter(Collision col) {
        if(playerScript.health < playerScript.maxHealth) {
            playerScript.health += 50f;
            Destroy(gameObject);
        }
    }
}
