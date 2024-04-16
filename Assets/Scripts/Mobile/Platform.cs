using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Platform
{
    public static bool IsMobileBrowser()
    {
        #if UNITY_EDITOR
            return false;
        #elif UNITY_WEBGL
            return WebGLHandler.IsMobileBrowser();
        #endif
        
        return false;
    }
}
