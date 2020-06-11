using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

namespace Managers
{
    public class InputManager : SingletonObject<InputManager>
    {
        public float AxisHorizontal { get { return Input.GetAxisRaw("Horizontal"); } }
        public bool AxisVertical { get { return Input.GetButtonDown("Jump"); } }
    }
}
