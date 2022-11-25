using UnityEngine;

namespace mj.gist
{
    public class MultiframeEffect : MonoBehaviour
    {
        [SerializeField] private RenderTexture source;
        [SerializeField] private Material effectMat;

        private PingPongRenderTexture rt;

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
}