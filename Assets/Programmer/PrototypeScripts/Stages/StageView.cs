using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StageView : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 環境光の種類
    /// </summary>
    public enum EnvironmentLight
    {
        Morning,Noon,Night
    }
    static EnvironmentLight[] EnvLight = { EnvironmentLight.Morning, EnvironmentLight.Noon, EnvironmentLight.Night };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Lighting(int Date)
    {

    }
}
