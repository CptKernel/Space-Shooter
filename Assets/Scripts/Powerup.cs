﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    // 0 = Triple shot
    // 1 = Speed
    // 2 = Sheilds
    [SerializeField]
    private int _powerupID;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                switch(_powerupID)
                {
                    case 0:
                        player.TripleShotPowerup();
                        break;
                    case 1:
                        player.SpeedPowerup();
                        break;
                    case 2:
                        Debug.Log("Collected Sheilds");
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;

                }
            }

            Destroy(this.gameObject);
        }
    }
}
