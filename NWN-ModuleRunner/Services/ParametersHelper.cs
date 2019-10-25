using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Services
{
    internal static class ParametersHelper
    {
        public const String PARAMETERS_PATH = "../../parameters.json";

        public static Parameters ReadOrDefaultParameters()
        {
            if (!File.Exists(PARAMETERS_PATH))
                return GetDefaultParameters();

            try
            {
                using (JsonTextReader jReader = new JsonTextReader(new StreamReader(PARAMETERS_PATH)))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    Parameters result = serializer.Deserialize<Parameters>(jReader);

                    return result;
                }
            }
            catch (IOException ex)
            {
                // TODO: Logging.
                return GetDefaultParameters();
            }
            catch (Exception ex)
            {
                // TODO: Logging.
                return GetDefaultParameters();
            }
        }

        public static bool TryWriteParameters(Parameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            try
            {
                using (JsonTextWriter jWriter = new JsonTextWriter(new StreamWriter(PARAMETERS_PATH)))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    serializer.Serialize(jWriter, parameters);

                    return true;
                }
            }
            catch (IOException ex)
            {
                // TODO: Logging.
            }
            catch (Exception ex)
            {
                // TODO: Logging.
            }

            return false;
        }

        public static Parameters GetDefaultParameters()
        {
            Parameters result = new Parameters();

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            result.Points.Add(new Point { X = w / 2, Y = h / 2 });
            result.SaveParameters = true;
            result.ShowFinalDialog = true;

            return result;
        }
    }

    public sealed class Parameters : ICloneable
    {
        public List<Point> Points { get; set; } = new List<Point>();
        public bool SaveParameters { get; set; }
        public bool ShowFinalDialog { get; set; }

        public object Clone()
        {
            return new Parameters
            {
                Points = Points.ToList(),
                SaveParameters = SaveParameters,
                ShowFinalDialog = ShowFinalDialog,
            };
        }

        public bool Equals(Parameters paramsObj)
        {
            if (Object.ReferenceEquals(this, paramsObj))
                return true;

            return paramsObj != null
                && ((Points == null && paramsObj.Points == null) || (Points != null && paramsObj.Points != null))
                && Points.All(x => paramsObj.Points.Contains(x))
                && SaveParameters == paramsObj.SaveParameters
                && ShowFinalDialog == paramsObj.ShowFinalDialog;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parameters);
        }

        public override int GetHashCode()
        {
            int hash;

            if (Points?.Count > 0)
            {
                hash = Points[0].X ^ Points[0].Y;
                foreach (var item in Points)
                {
                    hash = hash * (item.X ^ item.Y);
                }
            }
            else
            {
                hash = Convert.ToInt32(SaveParameters) * 1 + Convert.ToInt32(ShowFinalDialog) * 2;
            }

            return hash;
        }
    }
}
