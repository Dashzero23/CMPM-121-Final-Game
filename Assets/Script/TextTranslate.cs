using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GM;
    public TextMeshProUGUI languageText;
    public TextMeshProUGUI undoText;
    public TextMeshProUGUI redoText;
    public TextMeshProUGUI saveText;
    public TextMeshProUGUI saveFieldText;
    public TextMeshProUGUI loadText;
    public TextMeshProUGUI loadFieldText;

    public TMP_FontAsset defaultFont;
    public TMP_FontAsset japaneseFont;
    private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

    private string currentLanguage = "English"; // Default language

    void Start()
    {
        // Initialize translations for each language
        translations.Add("English", new Dictionary<string, string>() { {"Language", "English"}, {"Undo", "Undo"}, {"Redo", "Redo"}, {"Save", "Save"}, {"Load", "Load"}, {"SaveField", "Enter save name"}, {"LoadField", "Enter load name"} });
        translations.Add("Vietnamese", new Dictionary<string, string>() { {"Language", "Tiếng Việt"}, {"Undo", "Hoàn tác"}, {"Redo", "Làm lại"}, {"Save", "Lưu"}, {"Load", "Tải"}, {"SaveField", "Nhập tên lưu"}, {"LoadField", "Nhập tên tải"} });
        translations.Add("Chinese", new Dictionary<string, string>() { {"Language", ""}, {"Undo", ""}, {"Redo", ""}, {"Save", ""}, {"Load", ""}, {"SaveField", ""}, {"LoadField", ""} });

        // Set initial language
        UpdateLanguageUI();
    }

    // Call this method when the language toggle button is pressed
    public void ToggleLanguage()
    {
        // Cycle to the next language
        currentLanguage = GetNextLanguage(currentLanguage);

        // Update UI based on the new language
        UpdateLanguageUI();
    }

    // Example function to update UI based on the language choice
    private void UpdateLanguageUI()
    {
        // Get the dictionary for the current language
        Dictionary<string, string> currentLanguageDict;
        if (translations.TryGetValue(currentLanguage, out currentLanguageDict))
        {
            UpdateFontBasedOnLanguage();
            // Update text fields based on the dictionary
            languageText.text = currentLanguageDict["Language"];
            undoText.text = currentLanguageDict["Undo"];
            redoText.text = currentLanguageDict["Redo"];
            saveText.text = currentLanguageDict["Save"];
            loadText.text = currentLanguageDict["Load"];
            saveFieldText.text = currentLanguageDict["SaveField"];
            loadFieldText.text = currentLanguageDict["LoadField"];
        }
        else
        {
            Debug.LogWarning("Translation not found for language: " + currentLanguage);
        }
    }

    private void UpdateFontBasedOnLanguage()
    {
        // Check the current language and update the font accordingly
        switch (currentLanguage)
        {
            case "English":
                SetFonts(defaultFont);
                break;
            case "Vietnamese":
                SetFonts(defaultFont);
                break;
            case "Japanese":
                SetFonts(japaneseFont);
                break;
            default:
                // Set a default font if needed
                SetFonts(defaultFont);
                break;
        }
    }

    private void SetFonts(TMP_FontAsset font)
    {
        // Set fonts for all TextMeshPro components
        languageText.font = font;
        undoText.font = font;
        redoText.font = font;
        saveText.font = font;
        loadText.font = font;
        saveFieldText.font = font;
        loadFieldText.font = font;
    }

    // Helper method to get the next language in the list
    private string GetNextLanguage(string currentLanguage)
    {
        List<string> languageList = new List<string>(translations.Keys);
        int currentIndex = languageList.IndexOf(currentLanguage);
        int nextIndex = (currentIndex + 1) % languageList.Count;
        return languageList[nextIndex];
    }
}