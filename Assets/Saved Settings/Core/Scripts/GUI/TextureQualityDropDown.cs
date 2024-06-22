using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SavedSettings.GUI
{
    /// <summary>
    /// Syncs the drop down with the master texture limit setting.
    /// </summary>
    [RequireComponent(typeof(TMP_Dropdown))]
    public class TextureQualityDropDown : BaseUILoadSetting
    {
        void Start()
        {
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            options.Add(new TMP_Dropdown.OptionData("Full Resolution"));
            options.Add(new TMP_Dropdown.OptionData("1/2"));
            options.Add(new TMP_Dropdown.OptionData("1/4"));
            options.Add(new TMP_Dropdown.OptionData("1/8"));
            dropdown.options = options;
            LoadValue();
            dropdown.onValueChanged.AddListener(delegate { QualitySettings.globalTextureMipmapLimit = dropdown.value; });
        }

        public override void LoadValue()
        {
            GetComponent<TMP_Dropdown>().value = QualitySettings.globalTextureMipmapLimit;
        }
    }
}
