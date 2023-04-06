package com.th1209.calculation;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class NativeCalculator
{
    private float _lastResult = 0.0f;
    private String _gameObjectName;

    public NativeCalculator(String gameObjectName)
    {
        _lastResult = 0.0f;
        _gameObjectName = gameObjectName;
    }

    public float Add(int num)
    {
        _lastResult += num;
        Log.d("NativeCalculator", String.format("Add value:%f", _lastResult));
        return _lastResult;
    }

    public float Subtract(int num)
    {
        _lastResult -= num;
        Log.d("NativeCalculator", String.format("Subtract value:%f", _lastResult));
        return _lastResult;
    }

    public void Multiply(int num, String onComplete)
    {
        _lastResult *= num;
        Log.d("NativeCalculator", String.format("Multiply gameObjectName:%s value:%f", _gameObjectName, _lastResult));
        UnityPlayer.UnitySendMessage(_gameObjectName, onComplete, String.valueOf(_lastResult));
    }

    public void Divide(int num, String onComplete) throws Exception
    {
        if (num == 0)
        {
            throw new Exception("Zero division.");
        }
        _lastResult /= num;
        Log.d("NativeCalculator", String.format("Divide gameObjectName:%s value:%f", _gameObjectName, _lastResult));
        UnityPlayer.UnitySendMessage(_gameObjectName, onComplete, String.valueOf(_lastResult));
    }
}
