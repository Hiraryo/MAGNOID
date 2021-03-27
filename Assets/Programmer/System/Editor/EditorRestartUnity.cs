//このサイト（https://qiita.com/r-ngtm/items/c2ee6abea11e80cc5ba2）を参考にしました。
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Diagnostics;

public class EditorRestartUnity
{
    [MenuItem("File/Restart")]
    static void RestartUnity()
    {
        // 別のUnityを起動したあとに自身を終了
        Process.Start(EditorApplication.applicationPath);
        EditorApplication.Exit(0);
    }
}