using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AICop : MonoBehaviour {
    public GameObject player;
    NavMeshAgent nav_mesh;
    Animation anim;
    VelocityReporter vReporter;
    public GameObject[] waypoints;
    int currWaypoint = -1;
    public enum AIStates { Patrol, Chase, Flying, Eating }
    AIStates AIstate;
    public float chaseDistance;
    public GameObject gameOverHud;
    bool gameOver = false;
    int gameOverTime;
    float flyTime = 0, startTime = 0;
    public GameObject spawnPoint;
    
    //public bool canFire;
    // Use this for initialization
    void Start()
    {
        nav_mesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
        vReporter = player.GetComponent<VelocityReporter>();
        gameOver = false;
        AIstate = AIStates.Patrol;
        startTime = 0;
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            if( (int)Time.time - gameOverTime > 3)
            {
                print("Shifting scene now");
                SceneManager.LoadScene("MainMenu");
                gameOver = false;
                return;
            }
            return;
        }
        switch (AIstate)
        {
            case AIStates.Patrol:
                patrol();
                break;
            case AIStates.Chase:
                chase();
                break;
            case AIStates.Flying:
                fly();
                break;
            case AIStates.Eating:
                setState(AIStates.Flying);
                break;
        }

    }
    private void fly()
    {
        flyTime += Time.deltaTime;
        
        if (flyTime > 5)
        {
            this.transform.rotation = Quaternion.Euler(0,0,0);
            this.transform.position = spawnPoint.transform.position;
            nav_mesh.enabled = true;
            nav_mesh.isStopped = false;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            setState(AIStates.Patrol);
            this.GetComponent<Rigidbody>().useGravity = true;
            SetNextWaypoint();

            print("Spawning new cop");
        }
    }
    private void ChaseWaypoint()
    {
        Vector3 targetVel = vReporter.Velocity;
        Vector3 predictedPosition = vReporter.prevPos + vReporter.Velocity * Time.deltaTime;
        nav_mesh.SetDestination(predictedPosition);
        nav_mesh.speed = 7 + Mathf.Min((Time.time - startTime)/30,7);
    }
    private void SetNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            print("Error: Length of waypoints zero");
            return;
        }
        nav_mesh.speed = 3;
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        nav_mesh.SetDestination(waypoints[currWaypoint].transform.position);

    }
    private void endGame()
    {
        nav_mesh.isStopped = true;
        //player.GetComponent<Animator>().SetBool("caught",true);
        print("Game Over");
        gameOver = true;
        gameOverTime = (int)Time.time;
        Animator gameOverAnimator = gameOverHud.GetComponent<Animator>();
        anim.Play("Whistle");
        gameOverAnimator.Play("GameOver");
    }

    private void patrol()
    {
        
        Vector3 distanceToPlayer = (player.transform.position - this.transform.position);
        float dir = Vector3.Dot(this.transform.forward, distanceToPlayer);

        if (distanceToPlayer.magnitude < 3)
        {
            print("Calling endgame");
            endGame();
            return;
        }
        if (!nav_mesh.pathPending && nav_mesh.remainingDistance < 0.5f)
        {
            SetNextWaypoint();
        }
        if (distanceToPlayer.magnitude < chaseDistance - 10 && dir > 0)
            setState(AIStates.Chase);
        anim.Play("Walk");
    }
    public void setState(AIStates state)
    {
        switch (state)
        {
            case AIStates.Flying:
                flyTime = 0;
                nav_mesh.isStopped = true;
                nav_mesh.enabled = false;
                
                break;
            case AIStates.Chase:
                AudioManager.getInstance().playAlert();
                break;
            case AIStates.Eating:
                AudioManager.getInstance().playEat();
                anim.Play("Eating");
                this.GetComponent<Rigidbody>().useGravity = false;
                break;
        }
        AIstate = state;

    }
    private void chase()
    {
        Vector3 distanceToPlayer = (player.transform.position - this.transform.position);
        float dir = Vector3.Dot(this.transform.forward, distanceToPlayer);

        if (distanceToPlayer.magnitude < 3)
        {
            print("Calling endgame");
            endGame();
            return;
        }
        if (distanceToPlayer.magnitude > chaseDistance || dir < 0)
        {
            AIstate = AIStates.Patrol;
            return;
        }
        if (!nav_mesh.pathPending && nav_mesh.remainingDistance < 1.5f)
        {
            AIstate = AIStates.Patrol;
            SetNextWaypoint();
        }
        else
        {
            ChaseWaypoint();
        }
        anim.Play("Run");
    }
}
