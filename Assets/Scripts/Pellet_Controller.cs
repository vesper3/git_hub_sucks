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
        print("I hit something!");

        if (other.gameObject.tag == "Pellet")
        {
            if (this.color == colors.red && other.GetComponent<Pellet_Controller>().color == colors.green)
            {
                print("Red and Green Collided ");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else if (this.color == colors.blue && other.GetComponent<Pellet_Controller>().color == colors.green)
            {
                print("Blue and Green Collided");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else if (this.color == colors.blue && other.GetComponent<Pellet_Controller>().color == colors.red)
            {
                print("Blue and Red collided");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else if (this.color == colors.red && other.GetComponent<Pellet_Controller>().color == colors.cyan)
            {
                print("Red and Cyan Collided ");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else if (this.color == colors.blue && other.GetComponent<Pellet_Controller>().color == colors.yellow)
            {
                print("Blue and Yellow Collided");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else if (this.color == colors.green && other.GetComponent<Pellet_Controller>().color == colors.magenta)
            {
                print("Green and Magenta collided");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                print("Unneeded collision");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
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
