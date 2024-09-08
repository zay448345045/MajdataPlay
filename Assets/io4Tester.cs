using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

public class io4Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[StructLayout(LayoutKind.Explicit)]
public struct IO4Report : IInputStateTypeInfo
{
    public FourCC format => new('H', 'I', 'D');

    [FieldOffset(0)] public byte reportId;

    [InputControl(name = "button1", displayName = "button1", bit = 5)]
    [InputControl(name = "button2", displayName = "button2", bit = 4)]
    [InputControl(name = "button3", displayName = "button3", bit = 7)]
    [FieldOffset(29)] public byte buttons1;
}

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
[InputControlLayout(stateType = typeof(IO4Report))]
public class IO4Device : InputDevice
{
    static IO4Device()
    {
        Initialize();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        InputSystem.RegisterLayout<IO4Device>(
            matches: new InputDeviceMatcher()
                .WithInterface("HID")
                //.WithProduct("I/O CONTROL BD;15257   ;01;91;3EEE;6679B;00;GOUT=14_ADIN=8,E_ROTIN=4_COININ=2_SWIN=2,E_UQ1=41,6;")
                .WithCapability("vendorId", 0x0CA3) // Sony Entertainment¡£
                .WithCapability("productId", 0x0021)
        );
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init() { }
}