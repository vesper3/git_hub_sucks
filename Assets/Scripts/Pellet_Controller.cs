using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Laser_Pellet_Controller.cs:
Has References to: Game_Manager, Pellet_Shooter_Controller,
Default pellet is enemy pellet, auto deletes iteself on collision
Governs the local behavior of given pellets
Beams are pellets that are rotating spring shapes
When the laser pellets hit something they do something corresponding to the type of collision, then self destruct
Signals Laser_Controller when two colored pellets collide
Deletes when it collides with an uncolored pellet
*/

public class Pellet_Controller : MonoBehaviour
{
    private Game_Manager GM;
    private Pellet_Shooter_Controller LC;
    
    public float speed;


    public enum colors { red, blue, green, yellow, cyan, magenta, white };
    public colors color;

    private colors otherColor;

    void Start ()
    {
		GM = GameObject.FindObjectOfType<Game_Manager>();
    }
	
	void Update ()
    {
        transform.position +=(-1*transform.forward*speed*Time.deltaTime);
    }

    private void FixedUpdate()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {   
        //otherColor = other.GetComponent<Pellet_Controller>().color;
        print("I hit something!");
        if (this.color == colors.red)
        {
            print("Red bullet fired ");
        }

        if (other.gameObject.tag == "Pellet")
        {
            print(other.GetComponent<Pellet_Controller>().color);
            print("Pellets Collided");
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "Player")
        {
            if (GM.DEBUG == true)
                print("I am hitting a player");
            Destroy(gameObject);
            //Heal that Player

        }
        else if (other.gameObject.tag == "Enemy")
        {
            if (GM.DEBUG == true)
                print("I am hitting an enemy");
            Destroy(gameObject);

            //Damage that Enemy
        }
    } 
}
