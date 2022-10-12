using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int spelerBeurt = 1;
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        GameObject[] speler = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in speler)
        {
            if (g.GetComponent<TankControler>().playerNumber == 1)
            {
                player1 = g;
            }
            else if (g.GetComponent<TankControler>().playerNumber == 2)
            {
                player2 = g;
            }
        }
        Invoke("Init", 0.1f);
    }
    void Init() 
    {
        if (spelerBeurt == 1)
        {
            player1.GetComponent<TankControler>().IsActive(true);
            player2.GetComponent<TankControler>().IsActive(false);
        }
        else if (spelerBeurt == 2)
        {
            player1.GetComponent<TankControler>().IsActive(true);
            player2.GetComponent<TankControler>().IsActive(false);
        }
    }
    public void WisselBeurt() 
    {
        if (spelerBeurt == 1)
        {
            spelerBeurt = 2;
            player1.GetComponent<TankControler>().IsActive(false);
            player2.GetComponent<TankControler>().IsActive(true);
        }
        else if (spelerBeurt == 2)
        {
            spelerBeurt = 1;
            player1.GetComponent<TankControler>().IsActive(true);
            player2.GetComponent<TankControler>().IsActive(false);
        }
    }
}
