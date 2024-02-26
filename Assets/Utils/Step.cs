using System.Globalization;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Represents a step of the simulation
    /// </summary>
    public class Step
    {
        public float Time { get; private set; }
        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public string Shape { get; private set; }
        public string Color { get; private set; }

        private Step(float time, float x, float y, float z, float dirY, string shape, string color) :
            this(time,
                new Vector3(x, y, z),
                new Vector3(0.0f, dirY, 0.0f),
                shape,
                color){}
            
        private Step(float time, Vector3 position, Vector3 rotation, string shape, string color)
        {
            Time = time;
            Position = position;
            Rotation = rotation;
            Shape = shape;
            Color = color;
        }
        //private Step(float time, float x, float y, float z) : this(time, new Vector3(x, y, z)) { }

        /*
        private Step(float time, Vector3 position)
        {
            Time = time;
            Position = position;
        }
        */

        public static Step FromLine(string[] line)
        {
            CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            NumberFormatInfo ni = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
            ni.NumberDecimalSeparator = ".";

            float time = float.Parse(line[0], ni);
            //float time = float.Parse(line[indexes[0]], ni);
            float x = float.Parse(line[1], ni);
            //float x = float.Parse(line[indexes[1]], ni);
            float y = float.Parse(line[2], ni);
            //float y = float.Parse(line[indexes[2]], ni);
            float z = float.Parse(line[3], ni);
            //float z = float.Parse(line[indexes[3]], ni);
            float dirY = float.Parse(line[4], ni);
            //float dirY = float.Parse(line[indexes[4]], ni);
            string shape = string.Copy(line[5]);
            //string shape = string.Copy(line[indexes[5]]);
            string color = string.Copy(line[6]);
            //string color = string.Copy(line[indexes[6]]);
            return new Step(time, x, y, z, dirY, shape, color);
        }

        /*
        public static Step FromLine(string[] line, int[] indexes)
        {
            // WebGL doesn't detect the correct decimal separator so it has to be set
            CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            NumberFormatInfo ni = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
            ni.NumberDecimalSeparator = ".";

            float time = float.Parse(line[indexes[0]], ni);
            float x = float.Parse(line[indexes[1]], ni);
            float y = float.Parse(line[indexes[2]], ni);
            //float z = line.Length > 3 ? float.Parse(line[indices[3]], ni) : 0.0f;
            return new Step(time, x, y, 0.0f);
        }
        */
    }
}