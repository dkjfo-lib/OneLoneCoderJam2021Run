using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWall : MonoBehaviour
{
    public bool shouldBeOpen;
    public bool isOpen;
    [Space]
    public Sprite[] sprites;
    
    BoxCollider2D BoxCollider2D;
    SpriteRenderer SpriteRenderer;

    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(KeepUpdated());
    }

    IEnumerator KeepUpdated()
    {
        while (true)
        {
            yield return new WaitUntil(() => isOpen != shouldBeOpen);
            isOpen = shouldBeOpen;
            if (shouldBeOpen)
            {
                // open
                yield return new WaitForSeconds(.1f);
                SpriteRenderer.sprite = sprites[1];

                yield return new WaitForSeconds(.1f);
                BoxCollider2D.enabled = false;
                SpriteRenderer.sprite = sprites[2];
            }
            else
            {
                //close 
                yield return new WaitForSeconds(.1f);
                SpriteRenderer.sprite = sprites[1];

                yield return new WaitForSeconds(.1f);
                BoxCollider2D.enabled = true;
                SpriteRenderer.sprite = sprites[0];
            }
        }
    }
}
