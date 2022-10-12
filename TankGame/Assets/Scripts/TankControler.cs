using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class TankControler : MonoBehaviour
{
    public int playerNumber = 1;
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bulletToFire;
    [SerializeField]
    float speed = 5;
    bool isActive = false;
    public Animator animator;
    float movementSpeed = 5;
    float horizontalMovement = 0f;
    void Start()
    {

    }
    void Update()
    {
        if (isActive)
        {
            horizontalMovement = Input.GetAxisRaw("Player") * movementSpeed;
            animator.SetFloat("Driving", Mathf.Abs(horizontalMovement));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke("WisselBeurt", 0.1f);
            }

            if (playerNumber == 1)
            {
                transform.Translate(new Vector2(Input.GetAxis("Player") * 5 * Time.deltaTime, 0));
                barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Barrel") * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                    b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * speed, ForceMode2D.Impulse);
                }
            }



            if (playerNumber == 2)
            {
                transform.Translate(new Vector2(Input.GetAxis("Player") * 5 * Time.deltaTime, 0));
                barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Barrel2") * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                    b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * speed, ForceMode2D.Impulse);
                }
            }
        }
         
    }
    void WisselBeurt()
    {
        GameObject.Find("GameManager").GetComponent<TurnManager>().WisselBeurt();
    }
    public void IsActive(bool a) 
    {
        if (a == true)
        {
            isActive = true;
        }
        else 
        {
            isActive = false;
        }
    }
}
