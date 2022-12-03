using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20;
    private float rotationSpeed = 40;
    private Rigidbody playerRB;
    private Renderer playerRenderer;

    public Material[] material;
    public int colorIndex;
    public Color playerColor;

    public GameManager gameManager;
    public SpawnManager spawnManager;

    public float range = 24;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<Renderer>();
        ColorPlayer();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StayInMap();        
        if (!gameManager.isGameOver)
        {            
            //Player Controll        
            float forwardInput = Input.GetAxis("Vertical");
            playerRB.AddForce(gameObject.transform.forward * forwardInput * speed);
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

    //Check is ball collided has same color
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.ballCount--;
        var ballRenderer = other.GetComponent<Renderer>();
        var ballColor = ballRenderer.material.GetColor("_Color");

        //if player color == ball color, score++ and get the index of ball prefab to store new ball, else, lose
        if (playerColor == ballColor)
        {
            gameManager.UpdateScore();
            for (int i = 0; i < material.Length; i++)
            {
                if (material[i].color == ballColor)
                {
                    colorIndex = i;
                }
            }
        }
        else
        {
            gameManager.GameOver();
        }   
        Destroy(other.gameObject);
        ColorPlayer();
    }

    //set player new color and get that color
    void ColorPlayer()
    {
        playerRenderer.material.SetColor("_Color", material[Random.Range(0, material.Length)].color);
        playerColor = playerRenderer.material.GetColor("_Color");
    }

    //Make sure player stay inside the map
    void StayInMap()
    {
        if (transform.position.x >= range)
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        if (transform.position.x <= -range)
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        if (transform.position.z >= range)
            transform.position = new Vector3(transform.position.x, transform.position.y, range);
        if (transform.position.z <= -range)
            transform.position = new Vector3(transform.position.x, transform.position.y, -range);
    }
}
