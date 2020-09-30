using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>
{
    public Action Activate = delegate { };

   /* public void Update()
    {
        InputKey();

    }*/
    public void InputKey( bool isActive)
    {
        if (isActive)
        {
            Activate();
        }
      
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }*/
    }


}
