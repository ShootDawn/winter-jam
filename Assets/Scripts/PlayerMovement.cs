using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D playerRb;
    public bool[] knowledge = new bool[6];
    public Animator animator;
    

    public FMOD.Studio.EventInstance footstepsSFX;
    public int snow = 0;
    public InGameMusic musicPlayer;

    Vector2 movement;
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            knowledge[0] = false;
        }
        


    }
    // Update is called once per frame

    private void Update()
    {
        //Get arrow keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("xInput", movement.x);
        animator.SetFloat("yInput", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);


        if (movement.sqrMagnitude > 0) {
            if (!IsPlaying(footstepsSFX))
            {           
                footstepsSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Homeless/Walk");
                footstepsSFX.start();
                footstepsSFX.setParameterByName("FloorType", snow);
            }

        } else
        {
            footstepsSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            footstepsSFX.release();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            musicPlayer.levelBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicPlayer.levelBGM.release();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
    void FixedUpdate()
    {
        //Move
        playerRb.MovePosition(playerRb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    bool IsPlaying(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }
    private void OnDisable()
    {
        footstepsSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        footstepsSFX.release();
    }
    private void OnDestroy()
    {
        footstepsSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        footstepsSFX.release();
    }
}



