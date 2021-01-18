using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Renderer playerRenderer;
    private bool moveLeft;
    private bool moveRight;
    private bool jump;
    private float horizontalMove;
    private float verticalMove;

    public float speed = 5;
    private float maxWidth;
    Scene currentScene;
    string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();

        moveLeft = false;
        moveRight = false;
        jump = false;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);

        //Translating the screen max pos vector to a world max pos
        Vector3 targetWidth = Camera.main.ScreenToWorldPoint(upperCorner);

        float playerWidth = playerRenderer.bounds.extents.x;

        //Saving the the max width of screen in World space
        maxWidth = targetWidth.x - playerWidth;

        // Create a temporary reference to the current scene.
        currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }

    //I am pressing the left button
    public void PointerDownLeft()
    {
        Debug.Log("cliqeeei");
        moveLeft = true;
    }

    //I am not pressing the left button
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    //Same thing with the right button
    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerDownJump()
    {
        jump = true;
    }

    public void PointerUpJump()
    {
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }

    //Now let's add the code for moving
    private void MovementPlayer()
    {
        //If i press the left button
        if (moveLeft)
        {
            horizontalMove = -speed;
        }

        //if i press the right button
        else if (moveRight)
        {
            horizontalMove = speed;
        }

        //if i am not pressing any button
        else
        {
            horizontalMove = 0;
        }

        if(jump){
            verticalMove = speed;
        }else{
            verticalMove = 0;

        }
    }

    //add the movement force to the player
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, verticalMove);
       


        // if (sceneName == "Game")
        // {
        //     gameObject.transform.position = new Vector2(Mathf.Clamp(gameObject.transform.position.x, playerRenderer.bounds.extents.x - 9.9f, 1.35f * maxWidth), gameObject.transform.position.y);

        //     if (gameObject.transform.position.x > 1.34f * maxWidth)
        //     {
        //         SceneManager.LoadScene("Game2");
        //     }
        // }
        // else
        // {
        //     gameObject.transform.position = new Vector2(Mathf.Clamp(gameObject.transform.position.x, playerRenderer.bounds.extents.x - 10.9f, 1.2f * maxWidth), gameObject.transform.position.y);

        //     if (gameObject.transform.position.x <= playerRenderer.bounds.extents.x - 10.8f)
        //     {
        //         SceneManager.LoadScene("Game");
        //     }

        // }

    }
}