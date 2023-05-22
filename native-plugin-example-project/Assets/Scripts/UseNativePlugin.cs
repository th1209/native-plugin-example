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
#elif UNITY_ANDROID
    [DllImport("test-native-plugin")]
    private static extern IntPtr createExportTest();

    [DllImport("test-native-plugin")]
    private static extern void freeExportTest(IntPtr instance);

    [DllImport("test-native-plugin")]
    private static extern int getResult(IntPtr instance, int num);
#elif UNITY_IOS
    [DllImport("__Internal", EntryPoint = "printHelloWorld")]
    private static extern Int32 PrintHelloWorld();
#endif
    
    

#if !UNITY_EDITOR && UNITY_ANDROID
    private AndroidJavaObject _calculator;

    private static class CalculatorConstants
    {
        public static readonly string PackageName = "com.th1209.calculation";
        public static readonly string ClassName = "NativeCalculator";
        public static class MethodName
        {
            public static readonly string Add = "Add";
            public static readonly string Subtract = "Subtract";
            public static readonly string Multiply = "Multiply";
            public static readonly string Divide = "Divide";
        }
    }
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
#elif UNITY_ANDROID 
        IntPtr instanceHandle = createExportTest();
        sb.AppendLine("nativeHandle:" + instanceHandle.ToString());

        int result = getResult(instanceHandle, 10);
        sb.AppendLine("result:" + result.ToString());

        freeExportTest(instanceHandle);
#elif UNITY_IOS
        sb.AppendLine($"result:" + PrintHelloWorld());
#endif

        _resultOutput.text = sb.ToString();
    }

    private void OnDestroy()
    {

    }
}
