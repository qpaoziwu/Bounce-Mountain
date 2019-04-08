using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class RankingData : ScriptableObject
{
    public float[] goldScoreTimes = new float[SceneManager.sceneCountInBuildSettings];
    public float[] silverScoreTimes = new float[SceneManager.sceneCountInBuildSettings];
    public float[] bronzeScoreTimes = new float[SceneManager.sceneCountInBuildSettings];
}
