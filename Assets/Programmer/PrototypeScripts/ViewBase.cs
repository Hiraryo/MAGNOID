//画面遷移する時はこのクラスを継承して使う。
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ViewBase : MonoBehaviour
{
    protected void ChangeScene(string path)
    {
        SceneManager.LoadScene(path);
    }
}