using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mj.gist;

public class GlobalEffect : MonoBehaviour
{
    [SerializeField] private RenderTexture source;
    [SerializeField] private RenderTexture output;

    private PingPongRenderTexture rt;

     private Shader effect;
    [SerializeField] private Material effectMat;

    void Start()
    {
        rt = new PingPongRenderTexture(source);
    }

    void Update()
    {
        effectMat.SetTexture("_Source", source);
        effectMat.SetTexture("_MainTex", rt.Read);
        effectMat.SetFloat("_DT", Time.deltaTime);

        Graphics.Blit(rt.Read, rt.Write, effectMat);
        rt.Swap();
    }
}
