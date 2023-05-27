using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace DefaultNamespace
{
    public class MarshallingExample : MonoBehaviour
    {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        delegate void LogCallback(IntPtr request, int size);
        [DllImport("test-plugin", CallingConvention = CallingConvention.Cdecl)]
        private static extern void registerLogCallback(LogCallback callback);

        [DllImport("test-plugin")]
        private static extern void passString(string value);

        [DllImport("test-plugin")]
        private static extern void passInt(int value);

        [DllImport("test-plugin")]
        private static extern void passFloat(float value);
#endif

        void Start()
        {
            registerLogCallback(OnLogCallback);

            passString("hoge");
            passString(null);
            passInt(100);
            passFloat(3.14f);
        }

        [MonoPInvokeCallback(typeof(LogCallback))]
        private static void OnLogCallback(IntPtr request, int size)
        {
            string str = Marshal.PtrToStringAnsi(request, size);
            UnityEngine.Debug.Log(str);
        }
    }

}