using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class UseNativePlugin : MonoBehaviour
{
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    [DllImport("test-plugin")]
    private static extern IntPtr createExportTest();

    [DllImport("test-plugin")]
    private static extern void freeExportTest(IntPtr instance);

    [DllImport("test-plugin")]
    private static extern int getResult(IntPtr instance, int num);
#endif

    void Start()
    {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        IntPtr instanceHandle = createExportTest();
        Debug.Log("nativeHandle:" + instanceHandle.ToString());

        int result = getResult(instanceHandle, 10);
        Debug.Log("result:" + result.ToString());

        freeExportTest(instanceHandle);
#endif
    }
}
