using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RandomPlatformScale : MonoBehaviour
{
    [SerializeField] List<GameObject> platforms;

    //Change to "GameEnginesMidterm--RandomScaleDLL" for the random scaling dll
    //Change to "GameEnginesMidterm--RestoreDLL" for the random scaling dll
    //You can leave everything else the same when switching, it'll still call the function when using the restore dll,
    //however the function will not change anything
    [DllImport("GameEnginesMidterm--RandomScaleDLL")]
    private static extern float RandomScaleValue(float minValue, float maxValue);

    void Start()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            Debug.Log("X Scale Before Random: " + platforms[i].transform.localScale.x);

            platforms[i].transform.localScale = new Vector3(platforms[i].transform.localScale.x * RandomScaleValue(0.6f, 1.4f), 1, 1);

            Debug.Log("X Scale After Random: " + platforms[i].transform.localScale.x);
        }
    }
}
