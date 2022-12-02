using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float grafity = 10;
    [SerializeField] private Text itemsText;
    [SerializeField] private Text timeText;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject win;
    [SerializeField] GameObject particle;
    [SerializeField] GameObject portalParticle;
    [SerializeField] AudioSource colaAudio;
    [SerializeField] AudioSource walkAudio;
    [SerializeField] AudioSource runAudio;
    private CharacterController controller;
    private int items;
    private float timer;
    private Vector3 direction;
    private bool isWin = false;
    private bool isWalk = false;
    private bool isRun = false;

    void Start()
    {
        timer = 150;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(timer).ToString();
        if (timer <= 0 && !isWin)
        {
            Dead();
        }
        if (items >= 10)
        {   
            portalParticle.SetActive(true);
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
            if (direction.magnitude > 0)
            {
                if (isWalk == false)
                {
                    walkAudio.Play();
                    isWalk = true;
                }
            }
            else
            {
                if (isWalk == true)
                {
                    walkAudio.Stop();
                    isWalk = false;
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isRun == false)
            {
                runAudio.Play();
                walkAudio.Stop();
                speed = 15;
                isRun = true;
            }
        }
        else
        {
            if (isRun == true)
            {
                runAudio.Stop();
                walkAudio.Play();
                speed = 10;
                isRun = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1.6f;
        }
        else controller.height = 3.2f;

        direction.y -= grafity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            items += 1;
            itemsText.text = "SpaceCola: " + items.ToString() + " / 10";
            Instantiate(particle, other.transform.position, particle.transform.rotation);
            Destroy(other.gameObject);
            colaAudio.Play();
        }
        if (other.CompareTag("Finish") && items >= 1)
        {
            Win();
        }  
        if (other.CompareTag("GameOver"))
        {
            Dead();
        }  
    }

    private void Dead()
    {
        gameOver.SetActive(true);
        FindObjectOfType<PlayerLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    private void Win()
    {
        isWin = true;
        win.SetActive(true);
        FindObjectOfType<PlayerLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
