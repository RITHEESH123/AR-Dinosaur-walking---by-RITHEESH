using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Drive : MonoBehaviour
{
    float speed = 1.0f;
    float rotationSpeed = 50.0f;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", 1.0f);
        }
        
        else if (translation < 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", -1.0f);
        }

        else
        {
            anim.SetBool("isRunning", false);
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");
        }
    }
}
