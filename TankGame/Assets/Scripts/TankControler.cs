using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    float speed;
    float changeSpeed = 10;
    bool isActive = false;
    public Animator animator;
    float movementSpeed = 5;
    float horizontalMovement = 0f;
    [SerializeField]
    private float movementTime = 2;
    private float startTime = 2;
    public float timerP1;
    public float timerP2;
    float health = 100;
    public float hpP1;
    public float hpP2;
    void Start()
    {

    }
    void Update()
    {
        if (playerNumber == 1)
        {
            hpP1 = health;
        }
        else if (playerNumber == 2)
        {
            hpP2 = health;
        }
        float bulletSpeed = FindObjectOfType<UI>().bulletSpeed;
        speed = changeSpeed / 100 * bulletSpeed;

        if (isActive)
        {

            horizontalMovement = Input.GetAxisRaw("Player") * movementSpeed;
            animator.SetFloat("Driving", Mathf.Abs(horizontalMovement));

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Invoke("WisselBeurt", 0.1f);

            }

            if (playerNumber == 1 && health > 0)
            {
                Invoke("PlayerMovement", 2.0f);
                barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Barrel") * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CancelInvoke("playerMovement");
                    GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                    b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * speed, ForceMode2D.Impulse);
                }
            }



            if (playerNumber == 2 && health > 0)
            {
                Invoke("PlayerMovement", 2.0f);
                barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Barrel2") * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CancelInvoke("playerMovement");
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
    void PlayerMovement()
    {
        if (movementTime >= 0 && isActive == true)
        {
            transform.Translate(new Vector2(Input.GetAxis("Player") * 5 * Time.deltaTime, 0));
           
            movementTime -= Time.deltaTime;
            if (playerNumber == 1)
            {

                timerP1 = movementTime;

            }
            else if (playerNumber == 2)
            {
                timerP2 = movementTime;
            }
        }
        if (movementTime <= 2 && isActive == false)
        {
            movementTime = startTime;
            if (playerNumber == 1)
            {
                timerP1 = startTime;
            }
            else if (playerNumber == 2)
            {
                timerP2 = startTime;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health = health - 10;
        }
    }
}
