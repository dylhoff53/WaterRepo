using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public int lastStepPlayed;
    public int playedSound;

    public float currentX;
    public float lastX = 1;

    public float currentZ;
    public float lastZ = 1;

    public float timeChecker;


    public AudioSource[] footsteps;

    public float speed = 12f;

    public float stepInterval = 0.6f;
    public float lastStepSound;

    public AudioManager audioManager;

    public void Awake()
    {
        playedSound = Random.Range(0, 7);
        footsteps = new AudioSource[7];
    }

    public void Start()
    {
        SetupFootsteps();
    }

    // Update is called once per frame
    void Update()
    {
        timeChecker = Time.time;
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        currentX = transform.position.x;
        currentZ = transform.position.z;

        if (currentX != lastX && timeChecker - lastStepSound > stepInterval)
        {
            PlayFootstep();
            lastX = currentX;
            lastZ = currentZ;
            lastStepSound = Time.time;
        }
    }


    public void PlayFootstep()
    {
        while (playedSound == lastStepPlayed)
        {
            playedSound = Random.Range(1, 7);
        }
        Debug.Log(footsteps[playedSound]);
        FindObjectOfType<AudioManager>().Play("Step_" + playedSound.ToString());
        lastStepPlayed = playedSound;
    }


    public void SetupFootsteps()
    {
        for(int i = 0; i <= 6; i++)
        {
            footsteps[i] = FindObjectOfType<AudioManager>().sounds[i].source;
        }
    }
}
