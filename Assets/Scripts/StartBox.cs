using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour {

    public Game_Manager GM;

    private bool red_hit=false;
    private bool green_hit=false;
    private bool blue_hit=false;

    // Use this for initialization
    void Start ()
    {
        //GM = GameObject.FindObjectOfType<Game_Manager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(red_hit && blue_hit && green_hit)
        {
            Destroy(this.gameObject);
            GM.StartGame();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //Assumes only thing hitting it is pellet
        if (other.GetComponent<Pellet_Controller>().color == Pellet_Controller.colors.green)
        {
            green_hit=true;
        }
        if (other.GetComponent<Pellet_Controller>().color == Pellet_Controller.colors.red)
        {
            red_hit = true;
        }
        if (other.GetComponent<Pellet_Controller>().color == Pellet_Controller.colors.blue)
        {
            blue_hit = true;
        }
    }
}
