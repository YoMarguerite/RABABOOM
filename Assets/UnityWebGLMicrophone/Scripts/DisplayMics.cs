using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityWebGLMicrophone
{
    public class DisplayMics : MonoBehaviour
    {
        public Text Label1;
        public Text Label2;
#if UNITY_WEBGL && !UNITY_EDITOR
        void Awake()
        {
            Microphone.Init();
            Microphone.QueryAudioInput();
        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        void Update()
        {
            Microphone.Update();

            string[] devices = Microphone.devices;
            float[] volumes = Microphone.volumes;
            Label1.text = string.Format("Microphone count {0}", devices.Length);

            for (int index = 0; index < devices.Length; ++index)
            {
               string deviceName = devices[index];
               if (deviceName == null)
               {
                    deviceName = string.Empty;
               }
               Label2.text = deviceName + " : " + volumes[index];
            }
        }
#endif

        //        void OnGUI()
        //        {
        //            GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        //            GUILayout.FlexibleSpace();

        //            string[] devices = Microphone.devices;

        //#if UNITY_WEBGL && !UNITY_EDITOR
        //            float[] volumes = Microphone.volumes;
        //#endif

        //            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        //            GUILayout.FlexibleSpace();
        //            GUILayout.Label(string.Format("Microphone count={0}", devices.Length));
        //            GUILayout.FlexibleSpace();
        //            GUILayout.EndHorizontal();

        //            for (int index = 0; index < devices.Length; ++index)
        //            {
        //                string deviceName = devices[index];
        //                if (deviceName == null)
        //                {
        //                    deviceName = string.Empty;
        //                }

        //                GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        //                GUILayout.FlexibleSpace();
        //#if UNITY_WEBGL && !UNITY_EDITOR
        //                GUILayout.Label(string.Format("Device Name={0} Volume={1}", deviceName, volumes[index]));
        //#else
        //                GUILayout.Label(string.Format("Device Name={0}", deviceName));
        //#endif
        //                GUILayout.FlexibleSpace();
        //                GUILayout.EndHorizontal();
        //            }

        //            GUILayout.FlexibleSpace();
        //            GUILayout.EndVertical();
        //        }
    }
}
