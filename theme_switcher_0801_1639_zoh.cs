// 代码生成时间: 2025-08-01 16:39:05
using UnityEngine;
using UnityEngine.UI;

public class ThemeSwitcher : MonoBehaviour
{
    /*
     * UI elements related to themes.
     */
    public GameObject lightThemeButton;
    public GameObject darkThemeButton;
    public Image background;
    public Color lightThemeColor = Color.white;
    public Color darkThemeColor = Color.black;

    private void Start()
    {
        // Initialize theme switcher with default theme.
        ApplyTheme(GetCurrentTheme());
    }

    /*
     * Method to switch between themes.
     * @param themeName The name of the theme to switch to.
     */
    public void SwitchTheme(string themeName)
    {
        try
        {
            switch (themeName)
            {
                case "Light":
                    ApplyTheme(lightThemeColor);
                    break;
                case "Dark":
                    ApplyTheme(darkThemeColor);
                    break;
                default:
                    Debug.LogError("Invalid theme: " + themeName);
                    break;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error switching theme: " + e.Message);
        }
    }

    /*
     * Applies the theme by changing the background color.
     * @param color The color to apply.
     */
    private void ApplyTheme(Color color)
    {
        background.color = color;
        // Update button colors to indicate the active theme.
        lightThemeButton.GetComponent<Image>().color = (color == lightThemeColor) ? Color.gray : Color.white;
        darkThemeButton.GetComponent<Image>().color = (color == darkThemeColor) ? Color.gray : Color.black;
    }

    /*
     * Gets the current theme based on the background color.
     */
    private string GetCurrentTheme()
    {
        if (background.color == lightThemeColor)
        {
            return "Light";
        }
        else if (background.color == darkThemeColor)
        {
            return "Dark";
        }
        else
        {
            Debug.LogError("Unknown theme color detected. Defaulting to Light theme.");
            return "Light";
        }
    }
}
