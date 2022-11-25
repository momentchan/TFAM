using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class HDRISkyRotation : MonoBehaviour
{

    [SerializeField] Volume volume;
    [SerializeField] float rot;
    private void Update()
    {
            SetHdriRotation(rot);
    }
    void SetHdriRotation(float rot)
    {
        HDRISky sky;
        volume.profile.TryGet(out sky);
        sky.rotation.value = rot;
    }
}