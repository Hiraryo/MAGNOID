//Modelの計算結果をViewで受け取り、画面に反映させる
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StageView : MonoBehaviour
{
    /// <summary>
    /// 環境光の種類
    /// </summary>
    ///
    public enum EnvironmentLight
    {
        Morning,
        Noon,
        Night
    }

    //環境光を準備
    static EnvironmentLight[] EnvLight = { EnvironmentLight.Morning, EnvironmentLight.Noon, EnvironmentLight.Night };

    private Vector3 _direction;
    // Start is called before the first frame update
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
