using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1Ending : MonoBehaviour
{
    public GameObject[] botsToKill;
    public string nextScene;

    void Start()
    {
        StartCoroutine(WaitForBossToBeDead());
    }

    IEnumerator WaitForBossToBeDead()
    {
        yield return new WaitUntil(() => botsToKill.All(s => s == null));
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextScene);
    }
}
