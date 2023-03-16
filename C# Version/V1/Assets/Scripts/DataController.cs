using System.Collections;
using System.IO;
using System;
using UnityEngine;
using System.Collections.Generic;
public class DataController
{
    public List<List<Vector3>> velocities = new List<List<Vector3>>();
    public List<List<Vector3>> positions = new List<List<Vector3>>();
    public List<List<Vector3>> forces = new List<List<Vector3>>();

    public List<List<float>> masses = new List<List<float>>();
    public List<float> times = new List<float>();

    // For fps vs starcount graphs
    //public List<float> FPS = new List<float>();
    //public List<int> numberOfStars = new List<int>();

    public void SaveData()
    {
        DateTime currentDateTime = DateTime.Now;

        // Save data to file
        StreamWriter writer = new StreamWriter("sim_data_" + currentDateTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv");
        writer.WriteLine("time,index,mass,x,y,z,vx,vy,vz,fx,fy,fz");

        for(int i=0; i < times.Count; i++)
        {
            for (int j = 0; j < masses[i].Count; j++)
            {
                string line = string.Join(",", times[i], j, masses[i][j], positions[i][j][0], positions[i][j][1], positions[i][j][2], velocities[i][j][0], velocities[i][j][1], velocities[i][j][2], forces[i][j][0], forces[i][j][1], forces[i][j][2]);
                writer.WriteLine(line);
            }
        }

        writer.Flush();
        writer.Close();
    }

//     public void AddData(float time, List<Body> bodies)
//     {

//     }
}
