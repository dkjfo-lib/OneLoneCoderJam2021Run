using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DoorSpawner : MonoBehaviour
{
    public SpriteRenderer SpriteRenderers;
    [Space]
    public Color colorOn;
    public Color colorOff;
    public Light2D[] Lights;
    [Space]
    public Sprite[] Sprites;
    [Space]
    public GameObject bot;
    public bool isOpen = false;
    [Space]
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public ClipsCollection sounds_open;
    [Space]
    [Range(0, 1)] public float chanceToSpawn = .33f;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpen) return;
        if (Random.Range(0f, 1f) > chanceToSpawn) return;

        var player = collision.GetComponent<PlayerSinglton>();
        if (player == null) return;

        isOpen = true;
        StartCoroutine(SpawnBot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen) return;
        if (Random.Range(0f, 1f) > chanceToSpawn) return;

        var player = collision.GetComponent<PlayerSinglton>();
        if (player == null) return;

        isOpen = true;
        StartCoroutine(SpawnBot());
    }

    IEnumerator SpawnBot()
    {
        yield return new WaitForSeconds(.3f);
        foreach (var light in Lights)
        {
            light.color = colorOn;
        }

        Pipe_SoundsPlay.AddClip(new PlayClipData(sounds_open, transform.position));
        yield return new WaitForSeconds(.1f);
        SpriteRenderers.sprite = Sprites[0];

        yield return new WaitForSeconds(.1f);
        SpriteRenderers.sprite = Sprites[1];
        Instantiate(bot, transform.position, Quaternion.identity);
    }
}
