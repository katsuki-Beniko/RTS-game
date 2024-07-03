using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ������Ϸ�����е����ñ�
/// </summary>
public class ConfigManager
{
    private Dictionary<string, ConfigData> loadList;//��Ҫ��ȡ�����ñ�

    private Dictionary<string, ConfigData> configs;//�Ѿ�������ɵ����ñ�

    public ConfigManager()
    {
        loadList = new Dictionary<string, ConfigData>();
        configs = new Dictionary<string, ConfigData>();
    }

    //ע��Ҫ���ص����ñ�
    public void Register(string file,ConfigData config)
    {
        loadList[file] = config;
    }

    //�����������ñ�
    public void LoadAllConfigs()
    {
        foreach(var item in loadList)
        {
            TextAsset textAsset = item.Value.LoadFile();
            item.Value.Load(textAsset.text);
            configs.Add(item.Value.fileName,item.Value);
        }
        loadList.Clear();
    }

    public ConfigData GetConfigData(string file)
    {
        if(configs.ContainsKey(file))
        {
            return configs[file];
        }
        else
        {
            return null;
        }
    }
}
