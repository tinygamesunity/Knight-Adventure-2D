using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour {
    [SerializeField] private int _maxHealth;
    private int _currentHealth;


    private void Start() {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;

        DetectDeath(); 
    }

    public void DetectDeath() {
        if (_currentHealth <=0 ) {
            Destroy(gameObject);
        }
    }
}
