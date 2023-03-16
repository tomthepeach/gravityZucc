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

    public void SaveData()
    {
        Debug.Log("Saving data to file..."+ Directory.GetCurrentDirectory());
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

    public void LogData(float time, List<Body> bodies)
    {
        times.Add(time);
        List<Vector3> pos = new List<Vector3>();
        List<Vector3> vel = new List<Vector3>();
        List<Vector3> force = new List<Vector3>();
        List<float> mass = new List<float>();

        foreach (Body body in bodies)
        {
            pos.Add(body.transform.position);
            vel.Add(body.velocity);
            force.Add(body.netForce);
            mass.Add(body.mass);
        }

        positions.Add(pos);
        velocities.Add(vel);
        forces.Add(force);
        masses.Add(mass);
    }
}
