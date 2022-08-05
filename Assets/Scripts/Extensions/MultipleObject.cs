using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitCalculate
{
    public const int CostContainsBuy = 1;
    public const int CostIgnoreBuy = 2;

    public const int EffectAddMultiply = 3;
    public const int EffectMultiplyPow = 4;
    public const int EffectMultiplyPowExtra = 11;
    public const int EffectAddNExtra = 12;


    public const int Add = 5;
    public const int Mul = 6;

    public const int Or = 7;
    public const int And = 8;

    public const int Max = 9;
    //是否是隔天完成，隔天清零，当前+1
    public const int Time = 10;
}


public class MultiplyObjectByDouble
{
    Dictionary<string, double> _ps;
    public double result;
    double _baseValue;
    int _calculate;

    public MultiplyObjectByDouble(double baseValue = 1, int calculate = UnitCalculate.Mul)
    {
        _baseValue = baseValue;
        _calculate = calculate;
        _ps = new Dictionary<string, double>();
        this.reset();
    }

    public void set(string key, double value, bool byAdd = false)
    {
        _ps[key] = value + (byAdd ? this.get(key) : 0);
        this.reset();
    }

    public double get(string key)
    {
        var cnt = 0.0;
        _ps.TryGetValue(key, out cnt);
        return cnt;
    }

    void reset()
    {
        this.result = _baseValue;
        foreach (var kvp in _ps) {
            if (_calculate == UnitCalculate.Add) {
                this.result += kvp.Value;
            }
            else if (_calculate == UnitCalculate.Mul) {
                this.result *= kvp.Value;
            }
        }
    }

    public void clear()
    {
        _ps.Clear();
        this.reset();
    }

}

public class MultiplyObjectByFloat
{
    Dictionary<string, float> _ps;
    public float result;
    float _baseValue;
    int _calculate;

    public MultiplyObjectByFloat(float baseValue = 1, int calculate = UnitCalculate.Mul)
    {
        _baseValue = baseValue;
        _calculate = calculate;
        _ps = new Dictionary<string, float>();
        this.reset();
    }

    public void set(string key, float value, bool byAdd = false)
    {
        _ps[key] = value + (byAdd ? this.get(key) : 0);
        this.reset();
    }

    public float get(string key)
    {
        var cnt = 0f;
        _ps.TryGetValue(key, out cnt);
        return cnt;
    }

    void reset()
    {
        this.result = _baseValue;
        foreach (var kvp in _ps) {
            if (_calculate == UnitCalculate.Add) {
                this.result += kvp.Value;
            }
            else if (_calculate == UnitCalculate.Mul) {
                this.result *= kvp.Value;
            }
        }
    }

    public void clear()
    {
        _ps.Clear();
        this.reset();
    }

}

public class MultiplyObjectByInt
{
    Dictionary<string, int> _ps;
    public int result;
    int _baseValue;
    int _calculate;

    public MultiplyObjectByInt(int baseValue = 1, int calculate = UnitCalculate.Mul)
    {
        _baseValue = baseValue;
        _calculate = calculate;
        _ps = new Dictionary<string, int>();
        this.reset();
    }

    public void set(string key, int value)
    {
        _ps[key] = value;

        this.reset();
    }

    void reset()
    {
        this.result = _baseValue;
        foreach (var kvp in _ps) {
            if (_calculate == UnitCalculate.Add) {
                this.result += kvp.Value;
            }
            else if (_calculate == UnitCalculate.Mul) {
                this.result *= kvp.Value;
            }
        }
    }
}

public class MultiplyObjectByBool
{
    Dictionary<string, bool> _ps;
    public bool result;
    bool _baseValue;
    int _calculate;

    public MultiplyObjectByBool(bool baseValue = false, int calculate = UnitCalculate.Or)
    {
        _baseValue = baseValue;
        _calculate = calculate;
        _ps = new Dictionary<string, bool>();
        this.reset();
    }

    public void set(string key, bool value)
    {
        _ps[key] = value;
        this.reset();
    }

    void reset()
    {
        this.result = _baseValue;
        foreach (var kvp in _ps) {
            if (_calculate == UnitCalculate.Or) {
                this.result = this.result || kvp.Value;
            }
            else if (_calculate == UnitCalculate.And) {
                this.result = this.result && kvp.Value;
            }
        }
    }
}