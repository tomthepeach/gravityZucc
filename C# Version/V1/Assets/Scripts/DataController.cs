using System.Collections;
using System.IO;
using System;
public class DataController
{
    public var velocities = new List<List<Vector3>>();
    public var positions = new List<List<Vector3>>();
    public var forces = new List<List<Vector3>>();

    public var masses = new List<List<float>>();

    public void SaveData()
    {
        DateTime currentDateTime = DateTime.Now;

        // Save data to file
        StreamWriter writer = new StreamWriter("sim_data_" + currentDateTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv");
        writer.WriteLine("time,index,mass,x,y,z,vx,vy,vz,fx,fy,fz");

        for(int i=0; i < times.length; i++)
        {
            for (int j = 0; j < masses[i].length; j++)
            {
                string line = string.Join(",", times[i], j, masses[i][j], positions[i][j][0], positions[i][j][1], positions[i][j][2], velocities[i][j][0], velocities[i][j][1], velocities[i][j][2], forces[i][j][0], forces[i][j][1], forces[i][j][2]);
                writer.WriteLine(line);
            }
        }

        writer.Flush();
        writer.Close();
    }
}
