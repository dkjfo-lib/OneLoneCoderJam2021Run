using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public PlayerSinglton playerPrefab;

    void Start()
    {
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitUntil(() => PlayerSinglton.thePlayer == null);
        Time.timeScale = .5f;
        yield return new WaitForSeconds(2);
        Time.timeScale = 1;
        var curScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(curScene);
    }
}
