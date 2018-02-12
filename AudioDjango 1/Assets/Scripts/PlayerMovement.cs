using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    Vector2 input;  //Derection of Travel
    private Rigidbody2D player; //The players physics collider

    //Animator anim;
	//AudioSource moveAudio;

    public float moveSpeed = 5; //default movement speed
    public float speed = 0; // variable movement speed
    public float diagSpeed = 0.7f; // diagonal walking speed
	public bool isMoving = false; // Disallow events when walking
    

    public bool canMove = false; // Cannot move while interacting 

    void Awake()  //On launch
    {
        player = GetComponent<Rigidbody2D>();  
        //anim = GetComponent<Animator>();
        canMove = true;
		//moveAudio = GetComponent<AudioSource> ();
    }

	/*On every tick. Acts as an event listener and responds with movement based on the users keyboard input*/

    void Update(){  

		if (!canMove) {
			player.velocity = Vector2.zero;
			//moveAudio.Stop ();
			//anim.SetBool("isWalking", false);
			return;
		}

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

		/*if(isMoving && !moveAudio.isPlaying)	{
			//moveAudio.Play ();
		}
		else if(!isMoving){
			//moveAudio.Stop ();
		} */


        if (new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) != Vector2.zero)
        {
			isMoving = true;
            //anim.SetBool("isWalking", true);
            //anim.SetFloat("input_x", input.x);
           // anim.SetFloat("input_y", input.y);
        }
        else {
			isMoving = false;
            //anim.SetBool("isWalking", false);
        }

        if (input.x != 0 && input.y != 0)
        {
            speed = diagSpeed * moveSpeed;
        }
        else {
            speed = moveSpeed;
        }

        player.velocity = input * speed;
    }


}