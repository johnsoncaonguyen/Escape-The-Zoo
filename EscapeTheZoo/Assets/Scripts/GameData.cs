using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[System.Serializable]
public class GameData {

    public List<float> scores = new List<float>();
    int scoreLength = 3;
    static string path = Application.dataPath + "/scores1.dat";
    
    public void updateScore(float score)
    {
        scores.Add(score);
        scores.Sort();
        scores.Reverse();
        if(scores.Count > scoreLength)
            scores.RemoveAt(scoreLength);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate);
        Debug.Log("Saving scores");
        bf.Serialize(file, scores);
        file.Close();
    }
    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        try
        {
            file = File.Open(path, FileMode.Open);
            scores = (List<float>)bf.Deserialize(file);
            file.Close();
        }
        catch (FileNotFoundException)
        {
        }
    }
}
