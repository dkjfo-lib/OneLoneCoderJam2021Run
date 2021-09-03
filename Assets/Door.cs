using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Door : MonoBehaviour
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpen) return;

        var player = collision.GetComponent<PlayerSinglton>();
        if (player == null) return;

        StartCoroutine(SpawnBot());
    }

    IEnumerator SpawnBot()
    {
        yield return new WaitForSeconds(.3f);
        foreach (var light in Lights)
        {
            light.color = colorOn;
        }

        yield return new WaitForSeconds(.1f);
        SpriteRenderers.sprite = Sprites[0];

        yield return new WaitForSeconds(.1f);
        SpriteRenderers.sprite = Sprites[1];
        Instantiate(bot, transform.position, Quaternion.identity);
    }
}
