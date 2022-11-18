using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public TankControler player1;
    public TankControler player2;
    public GameObject player1EndScr;
    public GameObject player2EndScr;
    bool player1Won = false;
    bool player2Won = false;
    void Start()
    {
        
    }

    void Update()
    {
        float player1HP = player1.hpP1;
        float player2HP = player2.hpP2;
        if (player2HP <= 0) 
        {
            player1Won = true;
        } else if (player2HP >= 0) 
        {
            player1Won = false;
        }

        if (player1Won == true) 
        {
            player1EndScr.SetActive(true);
        } else if (player1Won == false) 
        {
            player1EndScr.SetActive(false);
        }

        if (player1HP <= 0) 
        {
            player2Won = true;
        } else if (player1HP >= 0) 
        {
            player2Won = false;
        } 

        if (player2Won == true) 
        {
            player2EndScr.SetActive(true);
        } else if (player2Won == false) 
        {
            player2EndScr.SetActive (false);
        }
    }
}
