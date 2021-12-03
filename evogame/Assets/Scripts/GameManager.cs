using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Joystick joystick;

    private Vector3 commandDirection;

    public GameObject player;

    private Rigidbody playerRb;

    public float playerSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var deltaPosition = joystick.Direction;

            commandDirection = deltaPosition.normalized;

            commandDirection = new Vector3(commandDirection.x, 0, commandDirection.y);

            var playerPos = player.transform.position;

            var playerlookatPosition = playerPos + commandDirection;

            Vector3 targetDir = playerlookatPosition - playerPos;

            player.transform.rotation = Quaternion.LookRotation(targetDir);

            Vector3 targetVelocity = (player.transform.forward * playerSpeed);

            targetVelocity.y = playerRb.velocity.y;

            playerRb.velocity = targetVelocity;

            float magnitude = playerRb.velocity.magnitude;
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerRb.velocity = Vector3.zero;
        }
    }

}
