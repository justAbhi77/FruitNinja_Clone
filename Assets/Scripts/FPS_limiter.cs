using UnityEngine;

public class FPS_limiter : MonoBehaviour
{
    [SerializeField,Range(30,160)]
    int targetFrrt=69;
    [SerializeField]
    bool fpslmt;

    void Start()
    {
        if (fpslmt)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFrrt;
        }
    }
}
