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
    public TextMeshProUGUI instruction;
    public TextMeshProUGUI winCon;
    public TextMeshProUGUI winRes;
    public TextMeshProUGUI languageText;
    public TextMeshProUGUI undoText;
    public TextMeshProUGUI redoText;
    public TextMeshProUGUI saveText;
    public TextMeshProUGUI saveFieldText;
    public TextMeshProUGUI loadText;
    public TextMeshProUGUI loadFieldText;

    public TMP_FontAsset defaultFont;
    public TMP_FontAsset arabicFont;
    public TMP_FontAsset chineseFont;
    private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

    private string currentLanguage = "English"; // Default language

    void Start()
    {
        // Initialize translations for each language
        translations.Add("English", new Dictionary<string, string>() { 
            {"Language", "English"}, 
            {"Undo", "Undo"}, 
            {"Redo", "Redo"}, 
            {"Save", "Save"}, 
            {"Load", "Load"}, 
            {"SaveField", "Enter save name"}, 
            {"LoadField", "Enter load name"}, 
            {"Instruction", "Use WASD to move around, Q to reap crop, E to sow carrot"}, 
            {"WinCon", "Have 10 carrots on the field to win"}, 
            {"WinRes", "You Win!\nClick to restart"} });
        translations.Add("Chinese", new Dictionary<string, string>() { 
            {"Language", "语言"}, {"Undo", "撤销"}, 
            {"Redo", "重做"}, {"Save", "保存"}, 
            {"Load", "加载"}, {"SaveField", "创造存档名"}, 
            {"LoadField", "输入存档名"}, 
            {"Instruction", ""}, 
            {"WinCon", ""}, 
            {"WinRes", ""} });
        translations.Add("Arabic", new Dictionary<string, string>() {
            {"Language", "العربية"},
            {"Undo", "تراجع"},
            {"Redo", "إعادة"},
            {"Save", "حفظ"},
            {"Load", "تحميل"},
            {"SaveField", "أدخل اسم الحفظ"},
            {"LoadField", "أدخل اسم التحميل"},
            {"Instruction", "استخدم WASD للتحرك، Q للحصاد، E لزراعة الجزر"},
            {"WinCon", "امتلك 10 جزر في الحقل للفوز"},
            {"WinRes", "أنت فائز!\nانقر لإعادة التشغيل"}});
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
            instruction.text = currentLanguageDict["Instruction"];
            winCon.text = currentLanguageDict["WinCon"];
            winRes.text = currentLanguageDict["WinRes"];
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
            case "Arabic":
                SetFonts(arabicFont);
                break;
            case "Chinese":
                SetFonts(chineseFont);
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
