using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 3;
    [SerializeField] Animator animator;
    public bool FinishedTask = false;

    void FixedUpdate()
    {
        Vector2 dir = new();
        if (!DialogueSystem.Instance.Talking)
        {
            if (Input.GetKey(KeyCode.W))
                dir.y += 1;
            if (Input.GetKey(KeyCode.S))
                dir.y -= 1;
            if (Input.GetKey(KeyCode.A))
                dir.x -= 1;
            if (Input.GetKey(KeyCode.D))
                dir.x += 1;
        }
        animator.SetFloat("X", dir.x);
        animator.SetFloat("Y", dir.y);
        dir.Normalize();
        rb.velocity = dir * speed;
    }
}
