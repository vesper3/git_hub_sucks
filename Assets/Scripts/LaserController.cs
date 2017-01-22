using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public Pellet_Shooter_Controller yellow_shooter;
    public Pellet_Shooter_Controller cyan_shooter;
    public Pellet_Shooter_Controller magenta_shooter;
    public Pellet_Shooter_Controller white_shooter;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void yellowShoot()
    {
        print("yellow shot");
        yellow_shooter.Shoot();
    }

    public void cyanShoot()
    {
        cyan_shooter.Shoot();
    }
    
    public void magentaShoot()
    {
        magenta_shooter.Shoot();
    } 
    public void whiteShoot()
    {
        white_shooter.Shoot();
    }


}
