using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float time = 0.00f;
    public Text text;
    void Update()
    {
        time += Time.deltaTime;
        text.text = "  " + time.ToString("0.00") + " s";
    }
}
