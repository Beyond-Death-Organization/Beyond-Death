using System;
using UnityEngine;

namespace Components
{
    public class SkyBoxController: MonoBehaviour
    {
        public Material state1;
        public Material state2;
        public Material state3;
        private static readonly int Property = Shader.PropertyToID("Fog Intensity");

        private void Start()
        {
            //skybox = GetComponent<Renderer> ();
            GameManager.Instance.OnNextLevel.AddListener(ChangeSkyBox);
        }
        public void ChangeSkyBox(int level)
        {
            switch (level)
            {
                case 3:
                    RenderSettings.skybox = state1;
                    break;
                case 6:
                    RenderSettings.skybox = state2;
                    //AudioManager.Instance.PlayMusic("MusicB",GetComponent<AudioSource>());
                    break;
                case 9:
                    RenderSettings.skybox = state3;
                    break;
            }
        }
    }
    
}