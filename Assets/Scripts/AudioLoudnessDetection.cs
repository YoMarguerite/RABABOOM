using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityWebGLMicrophone
{
    public class AudioLoudnessDetection : MonoBehaviour
    {
        int sampleWindow = 64;
        private AudioClip microphoneClip;

        string[] devices;
        float[] volumes;

#if UNITY_WEBGL && !UNITY_EDITOR
        void Awake()
        {
            Microphone.Init();
            Microphone.QueryAudioInput();
        }

        void Update()
        {
            Microphone.Update();

            devices = Microphone.devices;
            volumes = Microphone.volumes;            
        }
#else
        void Start()
        {
            MicrophoneToAudioClip();
        }


        public void MicrophoneToAudioClip()
        {
            string microphoneName = Microphone.devices[0];
            microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
        }
#endif

        public float GetLoudnessFromMicrophone()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (volumes.Length > 0)
            {
                return volumes[0];
            }else{
                return 0;
            }
#else
            return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
#endif
        }

        public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
        {
            int startPosition = clipPosition - sampleWindow;

            if (startPosition < 0)
                return 0;

            float[] waveData = new float[sampleWindow];
            clip.GetData(waveData, startPosition);

            float totalLoudness = 0;

            for (int i = 0; i < sampleWindow; i++)
            {
                totalLoudness += Mathf.Abs(waveData[i]);
            }

            return totalLoudness / (float)sampleWindow;
        }
    }
}