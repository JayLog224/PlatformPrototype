using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

namespace Managers
{
    public class InputManager : SingletonObject<InputManager>
    {
        public float AxisHorizontal { get { return Input.GetAxisRaw("Horizontal"); } }
        public bool PressedJump { get { return Input.GetKeyDown(KeyCode.Space); } }
        public bool HeldJump { get { return Input.GetKey(KeyCode.Space); } }
        public bool ReleasedJump { get { return Input.GetKeyUp(KeyCode.Space); } }
    }
}
