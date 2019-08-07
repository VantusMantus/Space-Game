﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private float speed = 150.0f;
    public float Speed { set { if (value > 0) speed = value; else speed = 0; } }
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    /*
    private Transform rotationBullet;
    public Transform RotationBullet { set { rotationBullet = value; } }
    */

    [SerializeField]
    private float damage = 1.0f;
    public float Damage { set { damage = value; } }
    private SpriteRenderer sprite;

    private int maxKillCount = 1;
    public int MaxKillCount { set { maxKillCount = value; } }


    private int killCount = 0;

    public Color color
    {
        set { sprite.color = value; }
    }

    private TrailRenderer trail;
    public float trailWidth = 0.25f;
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        trail = GetComponentInChildren<TrailRenderer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.5f);
        transform.rotation = parent.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, pos, step);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + (direction), step);
        //trail.startWidth = trailWidth;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyShip")
        {
            if (collision.gameObject.GetComponent<Unit>().armorPoints > 0)
            {
                collision.gameObject.GetComponent<Unit>().ReceiveDamage(damage);
                Destroy(gameObject);
            }
            
        }
        if (collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<Asteroid>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }


}
