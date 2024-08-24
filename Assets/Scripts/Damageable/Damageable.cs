using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;
    public UnityEvent damageableDeath;
    public UnityEvent<int, int> healthChanged;
    PlayerController playerController;
    Animator animator;

    [SerializeField]
    private int _maxHealth = 100;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get { return _health; }
        set
        {
            if (CompareTag("Player"))
            {
                playerController.currentHealth = value;
            }
            else
            {
                _health = value;
            }
            //Lesson 18
            healthChanged.Invoke(_health, MaxHealth);
            animator.SetTrigger("Hit");
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;

    private float timeSinceHit = 0;

    [SerializeField]
    public float invincibilityTime = 0.25f;

    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            if (_isAlive == false)
            {
                Death();
            }
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<Monster>();
    }

    private void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
            return;
        }
    }

    public bool GetHit(int damage)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            
            isInvincible = true;
            Debug.Log(Health);
            return true;
        }
        return false;
    }
    public bool GetHit(int damage, Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;

            damageableHit?.Invoke(damage, knockback);


            return true;
        }
        return false;
    }

    public bool Heal(int healthRestore)
    {
        if (IsAlive && Health < MaxHealth)
        {
            int maxheal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxheal, healthRestore);
            Health += actualHeal;

            return true;
        }
        return false;
    }
    public bool playerDeath = false;
    Monster monster;
    public void Death()
    {

        if (CompareTag("Player"))
        {
            playerDeath = true;
            SceneManager.LoadScene("GameOverScene");
        }
        else if (CompareTag("Enemy"))
        {
            if (!monster)
            {
                monster = GetComponent<Monster>();
            }
            if(monster)
                monster.Dead();
        }
    }
}
