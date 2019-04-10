using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class RankingData : ScriptableObject
{
    public float[] goldScoreTimes = new float[6];
    public float[] silverScoreTimes = new float[6];
    public float[] bronzeScoreTimes = new float[6];
}
