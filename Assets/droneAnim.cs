using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneAnim : MonoBehaviour
{
    public SpriteRenderer Flames;
    public Sprite[] FlameSprites;

    public DroneMovement Movement;

    void Start()
    {
        StartCoroutine(UpdateFlames());
    }

    IEnumerator UpdateFlames()
    {
        while (true)
        {

            yield return new WaitUntil(() => Movement.CurrentInput != Vector2.zero);

            Flames.color = Color.white;
            while (Movement.CurrentInput != Vector2.zero)
            {
                Flames.sprite = FlameSprites[0];
                yield return new WaitForSeconds(.1f);

                Flames.sprite = FlameSprites[1];
                yield return new WaitForSeconds(.1f);
            }

            Flames.color = new Color(1, 1, 1, 0);
        }
    }
}
