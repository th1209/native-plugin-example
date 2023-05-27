using System;
using System.Runtime.InteropServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace DefaultNamespace
{

    public class MarshallingExample : MonoBehaviour
    {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        [DllImport("test-plugin")]
        private static extern void passString(string value);

        [DllImport("test-plugin")]
        private static extern void passInt(int value);

        [DllImport("test-plugin")]
        private static extern void passFloa(float value);
#endif

        void Start()
        {
            // passString("hoge");
            // passString(null);
            // passInt(100);
            UnityEngine.Debug.Log("Start start");
            passFloa(3.14f);
            UnityEngine.Debug.Log("Start end");
        }
    }

}