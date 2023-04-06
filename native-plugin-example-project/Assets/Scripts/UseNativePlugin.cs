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
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
        try
        {
            _calculator = new AndroidJavaObject($"{CalculatorConstants.PackageName}.{CalculatorConstants.ClassName}", gameObject.name);
            var current = 0.0f;

            current = _calculator.Call<float>(CalculatorConstants.MethodName.Add, 10);
            sb.AppendLine("currentValue:" + current.ToString());
            current = _calculator.Call<float>(CalculatorConstants.MethodName.Subtract, 5);
            sb.AppendLine("currentValue:" + current.ToString());
            // ※UnityPlayer.UnitySendMessageはGameObject名指定なので､当然だがローカル関数は使えなかった
            _calculator.Call(CalculatorConstants.MethodName.Multiply, 2, "OnCalculationComplete");
            _calculator.Call(CalculatorConstants.MethodName.Divide, 5, "OnCalculationComplete");
        }
        catch (Exception e)
        {
            sb.AppendLine($"exception:{e.GetType()} message:{e.Message} stackTrace:{e.StackTrace}");
        }
#endif

        _resultOutput.text = sb.ToString();
    }

#if !UNITY_EDITOR && UNITY_ANDROID
    private void OnCalculationComplete(string result)
    {
        var log = "currentValue:" + float.Parse(result);
        UnityEngine.Debug.Log(log);
        _resultOutput.text = $"{_resultOutput.text}\n{log}";
    }
#endif

    private void OnDestroy()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        _calculator?.Dispose();
        _calculator = null;
#endif
    }
}
