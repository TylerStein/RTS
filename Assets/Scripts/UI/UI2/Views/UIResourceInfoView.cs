using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RTS.UI.Views
{
    public class UIResourceInfoView : MonoBehaviour
    {
        public Text displayWood;
        public Text displayStone;

        public void SetWoodResourceValue(int value)
        {
            displayWood.text = value.ToString();
        }

        public void SetStoneResourceValue(int value)
        {
            displayStone.text = value.ToString();
        }
    }
}