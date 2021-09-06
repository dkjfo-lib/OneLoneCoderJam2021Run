using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimator : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite[] Walking;
    public Sprite Falling;
    [Space]
    public GroundDetector GroundDetector;
    public IMovement movement;

    private void Start()
    {
        movement = transform.parent.parent.GetComponent<IMovement>();
    }

    void Update()
    {
        if (!GroundDetector.onGround)
        {
            SpriteRenderer.sprite = Falling;
        }
        else if (movement.CurrentInput != Vector2.zero)
        {
            int id = (int)((Time.timeSinceLevelLoad % .5f) * 4f);
            SpriteRenderer.sprite = Walking[id];
        }
        else
        {
            SpriteRenderer.sprite = Walking[0];
        }
    }
}
