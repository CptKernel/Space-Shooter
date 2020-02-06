using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // This will make the player start at (0, 0, 0).  
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // We want variables here so we dont have to manually adjust speed all of the time.
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
