using UnityEngine;
using UI;

namespace Inputs
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private WindowManager _windowManager;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _windowManager.ReturnToPreviousState();
            }
        }
    }
}