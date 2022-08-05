using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefAccess : IDatabaseAccess
{
    private List<string> keys;

    public PlayerPrefAccess()
    {
        this.keys = new List<string>();
    }

    public bool saveByUpdate { get; set; }

    public void registerKey(string[] keys)
    {
        this.keys.AddRange(keys);
    }

    public void addKey(string key)
    {
        this.keys.Add(key);
    }

    public void openDB()
    {
        
    }

    public void closeDB()
    {
        
    }

    public void dropDB()
    {
        this.clearDB();
    }

    public void clearDB()
    {
        PlayerPrefs.DeleteAll();
        this.saveByUpdate = true;
    }

    public string getValue(string key)
    {
        if (PlayerPrefs.HasKey(key)) {
            return PlayerPrefs.GetString(key);
        }
        
        PlayerPrefs.SetString(key, string.Empty);
        return string.Empty;
    }

    public void setValue(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        this.saveByUpdate = true;
    }

    public void removeValue(string key)
    {
        PlayerPrefs.DeleteKey(key);
        this.saveByUpdate = true;
    }

    public void saveDB()
    {
        PlayerPrefs.Save();
    }

    public Dictionary<string, object> exportDB()
    {
        return null;
    }

    public void update(float dt)
    {
        if (this.saveByUpdate) {
            PlayerPrefs.Save();
            this.saveByUpdate = false;
        }
    }
}
