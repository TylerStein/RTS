using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

using RTS2.Assets;
namespace RTS2.UI
{
    public class AssetClickEvent : UnityEvent<EAssetType, string> { }

    public class AssetButtonList : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public GameObject labelPrefab;

        public GameObject listContainer;
        

        public Dictionary<EAssetType, List<string>> namesByLabel = new Dictionary<EAssetType, List<string>>();
        public Dictionary<string, Button> buttonsByName = new Dictionary<string, Button>();

        public AssetClickEvent onClick = new AssetClickEvent();

        public void ClearButtons() {
            foreach (Button btn in buttonsByName.Values) {
                btn.onClick.RemoveAllListeners();
                Destroy(btn.gameObject);
            }
            buttonsByName.Clear();
            namesByLabel.Clear();
        }

        public Button AddButton(EAssetType label, string name) {
            GameObject labelObject = namesByLabel.ContainsKey(label) ? FindLabelObject(label) : CreateLabelObject(label);
            GameObject newButtonObject = Instantiate(buttonPrefab, labelObject.transform);
            Button button = newButtonObject.GetComponent<Button>();
            Text buttonText = newButtonObject.GetComponentInChildren<Text>();
            buttonText.text = name;
            button.onClick.AddListener(() => {
                onClick.Invoke(label, name);
            });
            return button;
        }

        public void RemoveButton(EAssetType label, string name) {
            if (namesByLabel.ContainsKey(label)) {
                namesByLabel[label].Remove(name);
                Button b = buttonsByName[name];
                b.onClick.RemoveAllListeners();
                Destroy(b.gameObject);

                if (namesByLabel[label].Count == 0) {
                    namesByLabel.Remove(label);
                    Destroy(listContainer.transform.Find(label.ToString()).gameObject);
                }
                FormatContent();
            }
        }

        public List<Button> GetLabelContent(EAssetType label) {
            List<string> buttonNames = namesByLabel[label];
            List<Button> results = new List<Button>(buttonNames.Count);
            for (int i = 0; i < buttonNames.Count; i++) {
                results[i] = buttonsByName[buttonNames[i]];
            }
            return results;
        }

        public GameObject CreateLabelObject(EAssetType label) {    
            namesByLabel.Add(label, new List<string>());
            GameObject newLabel = Instantiate(labelPrefab, listContainer.transform);
            newLabel.name = label.ToString();
            Text labelText = newLabel.GetComponent<Text>();
            labelText.text = label.ToString();
            FormatContent();
            return newLabel;
        }

        public GameObject FindLabelObject(EAssetType label) {
            GameObject existingLabel = listContainer.transform.Find(label.ToString()).gameObject;
            return existingLabel;

        }

        public void FormatContent() {
            float top = 0;
            foreach (EAssetType label in namesByLabel.Keys) {
                GameObject labelObject = listContainer.transform.Find(label.ToString()).gameObject;
                RectTransform labelTransform = labelObject.GetComponent<RectTransform>();
                labelTransform.rect.Set(labelTransform.rect.x, top, labelTransform.rect.width, labelTransform.rect.height);
                top -= labelTransform.rect.height;
                foreach (string buttonName in namesByLabel[label]) {
                    Button buttonComponent = buttonsByName[buttonName];
                    RectTransform buttonTransform = buttonComponent.gameObject.GetComponent<RectTransform>();
                    buttonTransform.rect.Set(buttonTransform.rect.x, top, buttonTransform.rect.width, buttonTransform.rect.height);
                    top -= buttonTransform.rect.height;
                }
            }
        }
    }
}