using System;
using System.Collections.Generic;

public class GameModuleManager : Singleton<GameModuleManager>
{
    private Dictionary<Type, GameModule> mModuleDictionary = new Dictionary<Type, GameModule>();
    public T GetOpenModule<T>() where T : GameModule, new()
    {
        T module = GetModule<T>();
        if (module == null)
        {
            module = new T();

            Type type = typeof(T);
            mModuleDictionary.Add(type, module);

            module.OnOpen();
        }
        return module;

    }

    public GameModule GetOpenModule(string typeName)//lua调用
    {
        Type type = Type.GetType(typeName);

        GameModule module = GetModule(type);
        if (module == null)
        {
            module = Activator.CreateInstance(type) as GameModule;
            if (module != null)
            {
                mModuleDictionary.Add(type, module);
                module.OnOpen();
            }
        }
        return module;
    }

    public void CloseModule<T>() where T : GameModule
    {
        Type type = typeof(T);
        if (mModuleDictionary.ContainsKey(type))
        {
            mModuleDictionary[type].OnClose();
            mModuleDictionary.Remove(type);
        }
    }

    public T GetModule<T>() where T : GameModule
    {
        Type type = typeof (T);
        if (mModuleDictionary.ContainsKey(type))
        {
            return mModuleDictionary[type] as T;
        }
        return null;
    }
    public GameModule GetModule(Type moduleType) 
    {
        if (mModuleDictionary.ContainsKey(moduleType))
        {
            return mModuleDictionary[moduleType];
        }
        return null;
    }

    public GameModule GetModule(string typeName)//lua
    {
        Type type = Type.GetType(typeName);

        return GetModule(type);
    }

    public void ClearModule()
    {
        foreach(KeyValuePair<Type,GameModule> pair in mModuleDictionary)
        {
            if (pair.Value != null)
            {
                pair.Value.OnClose();
            }
        }
        mModuleDictionary.Clear();
    }
}
