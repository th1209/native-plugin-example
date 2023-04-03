using System;
using System.Runtime.InteropServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class UseNativePlugin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultOutput;
    
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
        Assert.IsNotNull(_resultOutput);

        StringBuilder sb = new StringBuilder();

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        IntPtr instanceHandle = createExportTest();
        sb.AppendLine("nativeHandle:" + instanceHandle.ToString());

        int result = getResult(instanceHandle, 10);
        sb.AppendLine("result:" + result.ToString());

        freeExportTest(instanceHandle);
#endif

        _resultOutput.text = sb.ToString();
    }
}
