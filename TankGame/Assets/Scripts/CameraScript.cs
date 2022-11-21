using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (player1.transform.position.x +5 > transform.position.x || player2.transform.position.x -5 > transform.position.x)
        {
            transform.Translate(Vector2.right * 10 * Time.deltaTime);
        }
        if (player2.transform.position.x -5 < transform.position.x || player1.transform.position.x +5 < transform.position.x)
        {
            transform.Translate(Vector2.left * 10 * Time.deltaTime);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.85f, 100f), transform.position.y, transform.position.z);

    }
   
}
