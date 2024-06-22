using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SavedSettings.GUI
{
    /// <summary>
    /// Syncs the drop down with the anti-aliasing setting.
    /// </summary>
    [RequireComponent(typeof(TMP_Dropdown))]
    public class AntiAliasingDropdown : BaseUILoadSetting
    {
        void Start()
        {
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            options.Add(new TMP_Dropdown.OptionData("Disabled"));
            options.Add(new TMP_Dropdown.OptionData("2x Multi Sampling"));
            options.Add(new TMP_Dropdown.OptionData("4x Multi Sampling"));
            options.Add(new TMP_Dropdown.OptionData("8x Multi Sampling"));

            dropdown.options = options;
            LoadValue();

            dropdown.onValueChanged.AddListener(delegate
            {

                switch (dropdown.value)
                {
                    case 1:
                        QualitySettings.antiAliasing = 2;
                        break;
                    case 2:
                        QualitySettings.antiAliasing = 4;
                        break;
                    case 3:
                        QualitySettings.antiAliasing = 8;
                        break;
                    default:
                        QualitySettings.antiAliasing = 0;
                        break;
                }
            });
        }

        /// <summary>
        /// Called by ResetSettings and DiscardSettings after the settings are changed.
        /// </summary>
        public override void LoadValue()
        {
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            switch (QualitySettings.antiAliasing)
            {
                case 2:
                    dropdown.value = 1;
                    break;
                case 4:
                    dropdown.value = 2;
                    break;
                case 8:
                    dropdown.value = 3;
                    break;
                default:
                    dropdown.value = 0;
                    break;
            }
        }
    }
}