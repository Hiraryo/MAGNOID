using UnityEngine;

public class Sketch : MonoBehaviour
{
    [SerializeField] private Material mat;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(null,dest,mat);
    }
}
