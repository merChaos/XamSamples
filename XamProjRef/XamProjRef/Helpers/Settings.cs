// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace XamProjRef1
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private const string SessionTokenKey = "Session_Token";
    private static readonly string SettingsDefault = string.Empty;

    #endregion


    public static string GeneralSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
      }
      set
      {
        //if value has changed then save it!
        if (AppSettings.AddOrUpdateValue(SettingsKey, value))
          AppSettings.Save();
      }
    }

    public static SessionToken Session
    {
        get
        {
            return AppSettings.GetValueOrDefault(SessionTokenKey,default(SessionToken));
        }
        set
        {
            //if value has changed then save it!
            if (AppSettings.AddOrUpdateValue(SessionTokenKey, value))
                AppSettings.Save();
        }
    }

    public static void AddSettings(string key, string value)
    {
        if (AppSettings.AddOrUpdateValue(key, value))
            AppSettings.Save();
    }

    public static void AddSettings<T>(string key, T value)
    {
        if (AppSettings.AddOrUpdateValue(key, value))
            AppSettings.Save();   
    }


    public static T GetSettings<T>(string key)
    {
        return AppSettings.GetValueOrDefault(key,default(T));
    }

  }
}