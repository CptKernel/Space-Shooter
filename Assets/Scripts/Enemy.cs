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
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6.5)
        {
            float randomX = Random.Range(-9.5f, 9.4f);
            transform.position = new Vector3(randomX, 6f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if other is player
        // Destroy player
        // Damage us
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        // if other is laser
        // destroy laser
        // destroy us
        if (other.transform.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        Debug.Log("Hit: " + other.transform.name);
    }
}
