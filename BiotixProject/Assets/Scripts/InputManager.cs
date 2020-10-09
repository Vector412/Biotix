using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>
{
    public Action Activate = delegate { };
    public Action Add = delegate { };

  
  
    public void InputKey( bool isActive)
    {
        if (isActive)
        {
            Activate();
        }
      
    }

    public void AddCount(bool isAdd)
    {
        if (isAdd)
        {
            Add();
        }
    }


}
