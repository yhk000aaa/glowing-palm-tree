using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDatabaseAccess
{
    bool saveByUpdate { get; set; }
    void registerKey(string[] keys);
    void addKey(string key);
    void openDB();
    void closeDB();
    void dropDB();
    void clearDB();
    string getValue(string key);
    void setValue(string key, string value);
    void removeValue(string key);
    void saveDB();
    Dictionary<string, object> exportDB();
    void update(float dt);
}
