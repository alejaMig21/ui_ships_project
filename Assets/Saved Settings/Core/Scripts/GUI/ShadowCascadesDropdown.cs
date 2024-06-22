using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SavedSettings.GUI
{
    /// <summary>
    /// Syncs the drop down with the shadow cascade setting.
    /// </summary>
    [RequireComponent(typeof(TMP_Dropdown))]
    public class ShadowCascadesDropdown : BaseUILoadSetting
    {
        void Start()
        {
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            options.Add(new TMP_Dropdown.OptionData("No Cascades"));
            options.Add(new TMP_Dropdown.OptionData("Two Cascades"));
            options.Add(new TMP_Dropdown.OptionData("Four Cascades"));
            dropdown.options = options;
            LoadValue();
            dropdown.onValueChanged.AddListener(delegate
            {

                switch (dropdown.value)
                {
                    case 1:
                        QualitySettings.shadowCascades = 2;
                        break;
                    case 2:
                        QualitySettings.shadowCascades = 4;
                        break;
                    default:
                        QualitySettings.shadowCascades = 0;
                        break;
                }
            });
        }

        public override void LoadValue()
        {
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            switch (QualitySettings.shadowCascades)
            {
                case 2:
                    dropdown.value = 1;
                    break;
                case 4:
                    dropdown.value = 2;
                    break;
                default:
                    dropdown.value = 0;
                    break;
            }
        }
    }
}
