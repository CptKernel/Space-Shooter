using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
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
        Vector3 offset = new Vector3(0, 0.8f, 0);
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);

    }
}
