/*
PlayerManager.cs
Author - Amr Ghoneim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    #region Singleton
        public static PlayerManager instance;

        void Awake() {
            instance = this;
        }
    #endregion

    public GameObject player;
    public Slider slider;
    public Image hitScreen;

    void Start() {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    void Update() {
        slider.value = calculateHealth();
        if(health > maxHealth) {
            health = maxHealth;
        }
        if(health <= 0) {
            StartCoroutine(playerDeath());
        }
        if(hitScreen != null) {
            if(hitScreen.GetComponent<Image>().color.a > 0) {
                var color = hitScreen.GetComponent<Image>().color;
                color.a -= 0.001f;
                hitScreen.GetComponent<Image>().color = color;
            }
        }
        if(transform.position.y < 11) {
            health -= 0.1f;
        }
    }

    float calculateHealth() {
        return health/maxHealth;
    }

    IEnumerator playerDeath() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

    IEnumerator waitForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Enemy") {
            var color = hitScreen.GetComponent<Image>().color;
            color.a = 0.8f;
            StartCoroutine(waitForSeconds(2.0f));
            hitScreen.GetComponent<Image>().color = color;
        }
    }
}
