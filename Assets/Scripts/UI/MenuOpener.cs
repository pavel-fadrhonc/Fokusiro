using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class MenuOpener : MonoBehaviour
    {
        public GameObject menu;
        
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ToggleMenu);
        }

        private void ToggleMenu()
        {
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
            Time.timeScale = menu.gameObject.activeSelf ? 0f : 1f;
        }

        private void Update()
        {
            if (Keyboard.current.xKey.wasPressedThisFrame ||
                Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                ToggleMenu();
            }
        }
    }
}