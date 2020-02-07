using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move down at 4 m/s 
        // if bottom of screen, respawn at top with a new random x position
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6.5)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.4f), 6f, 0);
        }
    }
}
