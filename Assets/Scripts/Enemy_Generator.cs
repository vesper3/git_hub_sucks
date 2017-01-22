using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Enemy_Generator.cs: (basically a level controller)
Has References to: Game_Manager, 
Generates Asteroids and Enemies
A primary function takes stage number as input from Game_Manager, then starts spawning, otherwise idle
Generates different combinations of enemies in pseudo-random configurations depending on the stage
Generally, asteroids will spawn randomly(outside of the map) if they are allowed in a stage, except first stage
Each stage can allow or disallow asteroids impacting level win condition
Stage 1: Asteroids only, random colors and configuration(asteroids are hard coded here)
Stage 2: Scout swarms from the top, 3 random primary color swarms
Stage 3: More scout swarms from the top, extra enemies from the bottom at the end(7), last is random secondary color
Stage 4: Enemies swarm from all sides randomly, 3 primary swarms, 3 secondary swarms afterwards
Stage 5: Introduces a single turrent centered, random primary color
Stage 6:
...
Boss Stage: Three turrents in opposing positions(secondary colors), after defeated, generate random fighters(6 waves, 3 primary, 3 secondary),
		concentric rings around centered boss, outer ring is split into secondary colors, inner ring is random primary colors
*/

public class Enemy_Generator : MonoBehaviour
{
    public Game_Manager GM;

    public GameObject Asteroid;
    public GameObject Scout;
    public GameObject Swarm;
    public GameObject Fighter;
    public GameObject Turrent;
    public GameObject Missile;
    public GameObject Boss;

    public float s_width = 360.0f;//Screen.width;
    public float s_height = 130.0f;//Screen.height;

    public int stage;

    public float timer;

    public float rand;

    public float stage_1_delay = 5.0f;
    public int stage_1_asteroids = 12;
    public int stage_1_asteroid_groups = 3;
    public int stage_1_asteroids_per_group = 10;

    public float stage_2_delay = 5.0f;
    public int stage_2_scouts = 12;
    public int stage_2_scouts_per_group = 10;
    public int stage_2_scout_groups = 3;

    public float stage_3_delay = 10.0f;
    public int stage_3_fighters = 12;
    public int stage_3_scouts_per_group = 15;
    public int stage_3_scout_groups = 6;

    public int stage_4_fighters = 3;

    public int stage_5_scouts = 21;

    void Start()
    {

    }

    public void Activate_Stage(int start_stage)
    {
        if (start_stage == 0)
        {
            Debug.Log("Game is now in standby...");
        }
        else if (start_stage == -1)
        {
            Debug.Log("Actvating Debug Stage 1");
            stage = 1;
            timer = stage_1_delay + Time.fixedTime;
        }
        else if (start_stage == -2)
        {
            Debug.Log("Actvating Debug Stage 2");
            stage = 2;
            timer = stage_2_delay + Time.fixedTime;
        }
        else if (start_stage == -3)
        {
            Debug.Log("Actvating Debug Stage 3");
            stage = 3;
        }
        else if (start_stage == -4)
        {
            Debug.Log("Actvating Debug Stage 4");
            stage = 4;
        }
        else if (start_stage == -5)
        {
            Debug.Log("Actvating Debug Stage 5");
            stage = 5;
        }
        else if (start_stage == 1)
        {
            Debug.Log("Actvating Stage 1");
            stage = 1;
        }
        else if (start_stage == 2)
        {
            Debug.Log("Actvating Stage 2");
            stage = 2;
            timer = stage_2_delay + Time.fixedTime;
        }
        else if (start_stage == 3)
        {
            Debug.Log("Actvating Stage 3");
            stage = 3;
        }
        else if (start_stage == 4)
        {
            Debug.Log("Actvating Stage 4");
            stage = 4;
        }
        else if (start_stage == 5)
        {
            Debug.Log("Actvating Stage 5");
            stage = 5;
        }
        else
        {
            Debug.Log("Not Debug stage number or not valid");
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if(stage == 0)
        {

        }
        /*if (stage == -1)
        {
            //asteroids
            if (timer <= Time.fixedTime)
            {
                Debug.Log("Placing Asteroid");
                GameObject asteroid = (GameObject)Instantiate(Asteroid, generate_random_direction(direction.any), Quaternion.identity);
                Enemy_Controller EC = asteroid.GetComponent<Enemy_Controller>();
                EC.movement_speed = 0.5f;
                --stage_1_asteroids;
                timer = stage_1_delay + Time.fixedTime;
            }
            if (stage_1_asteroids == 0)
            {
                stage = 0;
            }
        }
        else if (stage == -2)
        {
            //scouts
            if (timer <= Time.fixedTime)
            {
                Debug.Log("Placing Scout");
                GameObject scout = (GameObject)Instantiate(Scout, generate_random_direction(direction.any), Quaternion.identity);
                --stage_2_scouts;
                timer = stage_2_delay + Time.fixedTime;
            }
            if (stage_2_scouts == 0)
            {
                stage = 0;
            }
        }
        else if (stage == -3)
        {
            //fighters
            if (timer <= Time.fixedTime)
            {
                Debug.Log("Placing Fighter");
                GameObject fighter = (GameObject)Instantiate(Fighter, generate_random_direction(direction.any), Quaternion.identity);
                --stage_3_fighters;
                timer = stage_3_delay + Time.fixedTime;
            }
            if (stage_3_fighters == 0)
            {
                stage = 0;
            }
        }
        else if (stage == -4)
        {
            //turrents
            for (int i = 0; i < 3; ++i)
            {
                Debug.Log("Placing turrent");
                GameObject turrent = (GameObject)Instantiate(Turrent, generate_random_direction(direction.onscreen), Quaternion.identity);
            }
            stage = 0;
        }
        else if (stage == -5)
        {
            //scout swarm
            Debug.Log("Placing swarm");
            GameObject swarm = (GameObject)Instantiate(Swarm, generate_random_direction(direction.any), Quaternion.identity);
            stage = 0;
        }*/
        else if (stage == 1)
        {
            Stage1();
        }
        else if (stage == 2)
        {
            Stage2();
        }
        else if (stage == 3)
        {
            Stage3();
        }
        else if (stage == 4)
        {
            Stage4();
        }
        else if (stage == 5)
        {
            Stage5();
        }
    }

    public void Stage1()
    {
        //Asteroids from above, in waves
        if (timer <= Time.fixedTime)
        {
            for (int i = 0; i < stage_1_asteroids_per_group; ++i)
            {
                Debug.Log("Placing Astroid, Behavior: Default, From Above");
                GameObject asteroid = (GameObject)Instantiate(Asteroid, generate_random_direction(direction.up), Quaternion.identity);
                Enemy_Controller EC = asteroid.GetComponent<Enemy_Controller>();
                EC.movement_speed = 0.5f;
                if (i == 0)
                    EC.color = Pellet_Controller.colors.red;
                else if (i == 1)
                    EC.color = Pellet_Controller.colors.green;
                else
                    EC.color = Pellet_Controller.colors.blue;
            }

            --stage_1_asteroid_groups;
            timer = stage_2_delay + Time.fixedTime;
        }
        if (stage_1_asteroid_groups == 0)
        {
            stage = 0;
        }
    }

    public void Stage2()
    {
        //Three waves of scouts, each wave is a different color, default behavior, from above
        if (timer <= Time.fixedTime)
        {
            for (int i = 0; i < stage_2_scouts_per_group; ++i)
            {
                Debug.Log("Placing Scout, Behavior: Default, From Above");
                GameObject scout = (GameObject)Instantiate(Scout, generate_random_direction(direction.up), Quaternion.identity);
                Enemy_Controller EC = scout.GetComponent<Enemy_Controller>();
                if (i == 0)
                    EC.color = Pellet_Controller.colors.red;
                else if (i == 1)
                    EC.color = Pellet_Controller.colors.green;
                else
                    EC.color = Pellet_Controller.colors.blue;
            }

            --stage_2_scout_groups;
            timer = stage_2_delay + Time.fixedTime;
        }
        if (stage_2_scout_groups == 0)
        {
            stage = 0;
        }
    }

    public void Stage3()
    {
        //6 randomly colored waves from above of scouts, + 1 lone scout from below
        rand = (float)Random.Range(1, 4);
        if (stage_3_scout_groups > 0 && timer <= Time.fixedTime)
        {
            for (int i = 0; i < stage_3_scouts_per_group; ++i)
            {
                Debug.Log("Placing Scout, Behavior: Default, From Above");
                GameObject scout = (GameObject)Instantiate(Scout, generate_random_direction(direction.up), Quaternion.identity);
                Enemy_Controller EC = scout.GetComponent<Enemy_Controller>();
                if (rand == 0)
                    EC.color = Pellet_Controller.colors.red;
                else if (rand == 1)
                    EC.color = Pellet_Controller.colors.green;
                else
                    EC.color = Pellet_Controller.colors.blue;
            }

            --stage_3_scout_groups;
            timer = stage_3_delay + Time.fixedTime;
        }
        if (stage_3_scout_groups == 0 && timer <= Time.fixedTime)
        {
            Debug.Log("Placing Scout, Behavior: Default, From Below");
            GameObject scout = (GameObject)Instantiate(Scout, generate_random_direction(direction.down), Quaternion.identity);
            Enemy_Controller EC = scout.GetComponent<Enemy_Controller>();
            if (rand == 0)
                EC.color = Pellet_Controller.colors.red;
            else if (rand == 1)
                EC.color = Pellet_Controller.colors.green;
            else
                EC.color = Pellet_Controller.colors.blue;
            stage = 0;
        }
    }

    public void Stage4()
    {
        //Spawn 3 fighters from above, and continue to spawn asteroids from above
        for (int i = 0; i < stage_4_fighters; ++i)
        {
            Debug.Log("Placing Scout, Behavior: Default, From Above");
            GameObject fighter = (GameObject)Instantiate(Fighter, generate_random_direction(direction.up), Quaternion.identity);
            Enemy_Controller EC = fighter.GetComponent<Enemy_Controller>();
            if (i == 0)
                EC.color = Pellet_Controller.colors.red;
            else if (i == 1)
                EC.color = Pellet_Controller.colors.green;
            else
                EC.color = Pellet_Controller.colors.blue;
        }
        stage = 1;
    }

    public void Stage5()
    {

    }

    public enum direction { up, down, left, right, horizontal, vertical, any, onscreen };
    public Vector3 generate_random_direction(direction dir)
    {
        int a = (int)Mathf.Round(s_width / 2);
        int b = (int)Mathf.Round(s_width / 8);
        int c = (int)Mathf.Round(s_height / 2);
        int d = (int)Mathf.Round(s_height / 8);
        int z_inner_bound = a + b;
        int z_outer_bound = z_inner_bound + b;
        int x_inner_bound = c + d;
        int x_outer_bound = x_inner_bound + d;
        float z_right = Random.Range(z_inner_bound, z_outer_bound);
        float z_left = Random.Range(-z_outer_bound, -z_inner_bound);
        float x_down = Random.Range(x_inner_bound, x_outer_bound);
        float x_up = Random.Range(-x_outer_bound, -x_inner_bound);
        //Values outside of the screen, random between up/down, left/right
        float x_out = Random.value > 0.5f ? z_left : z_right;
        float z_out = Random.value > 0.5f ? x_up : x_down;
        //Values somewhere within the screen bounds
        float x_in = Random.Range(-c, c);
        float z_in = Random.Range(-a, a);
        /*Debug.Log(s_width);
        Debug.Log(s_height);
        Debug.Log(x_inner_bound);
        Debug.Log(x_outer_bound);
        Debug.Log(z_inner_bound);
        Debug.Log(z_outer_bound);
        Debug.Log(x_in);
        Debug.Log(z_in);*/

        if (dir == direction.any)
        {
            return new Vector3(x_out, 0.0f, z_out);
        }
        else if (dir == direction.onscreen)
        {
            return new Vector3(x_in, 0.0f, z_in);
        }
        else if (dir == direction.up)
        {
            return new Vector3(x_up, 0.0f, z_in);
        }
        else if (dir == direction.down)
        {
            return new Vector3(x_down, 0.0f, z_in);
        }
        else if (dir == direction.left)
        {
            return new Vector3(x_in, 0.0f, z_left);
        }
        else if (dir == direction.right)
        {
            return new Vector3(x_in, 0.0f, z_right);
        }
        else if (dir == direction.horizontal)
        {
            return new Vector3(x_in, 0.0f, z_out);
        }
        else if (dir == direction.vertical)
        {
            return new Vector3(x_out, 0.0f, z_in);
        }
        else
        {
            return new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
