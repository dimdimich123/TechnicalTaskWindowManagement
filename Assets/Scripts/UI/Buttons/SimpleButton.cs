using UnityEngine.UI;

namespace UI.Buttons
{
    public class SimpleButton
    {
        private Button _button;

        public SimpleButton(Button button)
        {
            _button = button;
        }

        public void Subscribe(UnityEngine.Events.UnityAction method)
        {
            _button.onClick.AddListener(method);
        }

        public void Unsubscribe()
        {
            _button.onClick.RemoveAllListeners();
        }

        ~SimpleButton()
        {
            Unsubscribe();
        }
    }
}