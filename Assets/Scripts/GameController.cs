using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private static int _health = 10;
    private static int _maxHealth = 10;
    private static float _moveSpeed = 5f;
    private static float _fireRate = 0.5f;

    public Text healthText;

    public static int health { get => _health; set => _health = value; }
    public static int maxHealth { get => _maxHealth; set => _maxHealth = value; }
    public static float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public static float fireRate { get => _fireRate; set => _fireRate = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + _health;
    }


    public static void DamagePlayer(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(int heal)
    {
        _health = Mathf.Min(_maxHealth, _health + heal);
    }

    private static void KillPlayer()
    {

    }


}
