using System;
using UnityEngine;

namespace DefaultNamespace
{
    [ExecuteInEditMode]
    public class WaterShaderFlow : MonoBehaviour
    {
        private Material _mat;
        private Renderer _rend;
        
        private void Awake()
        {
            _rend = GetComponent<Renderer>();
            _mat = _rend.materials[1];
        }

        void Update()
        {
            Vector4 waveSpeed = _mat.GetVector("WaveSpeed");
            float waveScale = _mat.GetFloat("_WaveScale");
            float t = Time.time / 20.0f;

            Vector4 offset4 = waveSpeed * (t * waveScale);
            Vector4 offsetClamped = new Vector4(Mathf.Repeat(offset4.x, 1.0f), Mathf.Repeat(offset4.y, 1.0f),
                Mathf.Repeat(offset4.z, 1.0f), Mathf.Repeat(offset4.w, 1.0f));
            _mat.SetVector("_WaveOffset", offsetClamped);
            _rend.materials[1] = _mat;
        }
    }
}