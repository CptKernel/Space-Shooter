﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1.0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _tripleShotActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _powerUpDuration = 5.0f;
    [SerializeField]
    private float _speedPowerupAmount = 3.5f;
    [SerializeField]
    private bool _shieldsActive = false;
    [SerializeField]
    private GameObject _shieldVisual;
    private UIManager _uiManager;

    [SerializeField]
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The spawn manager is null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("The UI manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        // Clamp is useful for setting boundries like this. 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.91f, 0), 0);

        if (transform.position.x >= 10.24f)
        {
            transform.position = new Vector3(-11.26f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.26f)
        {
            transform.position = new Vector3(10.24f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        Vector3 offset = new Vector3(0, 1.05f, 0);
        _canFire = Time.time + _fireRate;

        if (_tripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        } else
        {
            Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
        }
    }

    public void AddToScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void Damage()
    {
        //if shields is active
        // deactivate shields
        // leave message, return
        if (_shieldsActive == true)
        {
            _shieldsActive = false;
            _shieldVisual.SetActive(false);
            return;
        }


        _lives--;

        _uiManager.UpdateLives(_lives);

        if (_lives == 0)
        {
            // Comunicate with spawn manager to stop spawning
            _spawnManager.OnPlayerDeath();
            _uiManager.GameOver();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotPowerup()
    {
        _tripleShotActive = true;
        StartCoroutine("TripleShotPowerDownRoutine");
    }

    public void SpeedPowerup()
    {
        _speed += _speedPowerupAmount;
        StartCoroutine("SpeedPowerDownRoutine");
    }

    public void ShieldsPowerup()
    {
        _shieldsActive = true;
        _shieldVisual.SetActive(true);
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(_powerUpDuration);
        _speed -= _speedPowerupAmount;
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(_powerUpDuration);
        _tripleShotActive = false;
    }
}
