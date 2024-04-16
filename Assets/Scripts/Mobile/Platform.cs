using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class WebGLHandler : MonoBehaviour
{
  [DllImport("__Internal")]
  public static extern bool IsMobileBrowser();
}



public class Platform
{
    public static bool IsMobileBrowser()
    {
        #if UNITY_EDITOR
            return false;
        #elif UNITY_WEBGL
            return WebGLHandler.IsMobileBrowser();
        #else
            return false;
        #endif
    }
}
