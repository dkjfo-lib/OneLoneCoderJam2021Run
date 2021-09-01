using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXPlaylist", menuName = "Pipes/SFXPlaylist")]
public class Pipe_SoundsPlay : ScriptableObject
{
    public List<PlayClipData> awaitingClips;
}

[System.Serializable]
public class PlayClipData
{
    public ClipsCollection clipCollection;
    public Vector3 position;
}