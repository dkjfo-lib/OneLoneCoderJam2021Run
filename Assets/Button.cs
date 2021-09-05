using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public PlayerRespawn PlayerRespawn;
    public Animator Animator;
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public ClipsCollection ButtonPressed;

    bool pressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pressed) return;

        PlayerRespawn.wasWithBosses = true;
        pressed = true;
        Animator.SetTrigger("start");
    }
}
