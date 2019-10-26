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

            result.Clicks.Add(new Click
            {
                Point = new Point(w / 2, h / 2),
            });
            result.SaveParameters = true;
            result.ShowFinalDialog = true;

            return result;
        }
    }

    public sealed class Parameters : ICloneable
    {
        public List<Click> Clicks { get; set; } = new List<Click>();
        public bool SaveParameters { get; set; }
        public bool ShowFinalDialog { get; set; }

        public object Clone()
        {
            Parameters result = new Parameters
            {
                SaveParameters = SaveParameters,
                ShowFinalDialog = ShowFinalDialog,
            };

            foreach (var item in Clicks)
            {
                result.Clicks.Add(new Click
                {
                    Point = item.Point,
                    Count = item.Count,
                    DelayBefore = item.DelayBefore,
                    Enabled = item.Enabled,
                });
            }

            return result;
        }

        public bool Equals(Parameters paramsObj)
        {
            if (Object.ReferenceEquals(this, paramsObj))
                return true;

            bool result = paramsObj != null;

            if (result)
                result = (Clicks == null && paramsObj.Clicks == null)
                    || (Clicks != null && paramsObj.Clicks != null && Clicks.Count == paramsObj.Clicks.Count);

            if (result)
            {
                for (int i = 0; i < Clicks.Count; i++)
                {
                    result = result
                        && Clicks[i].Point == paramsObj.Clicks[i].Point
                        && Clicks[i].Count == paramsObj.Clicks[i].Count
                        && Clicks[i].DelayBefore == paramsObj.Clicks[i].DelayBefore
                        && Clicks[i].Enabled == paramsObj.Clicks[i].Enabled;

                    if (!result)
                        return false;
                }
            }

            result = result && SaveParameters == paramsObj.SaveParameters
                && ShowFinalDialog == paramsObj.ShowFinalDialog;

            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parameters);
        }

        public override int GetHashCode()
        {
            int hash;

            if (Clicks?.Count > 0)
            {
                hash = Clicks[0].Point.X ^ Clicks[0].Point.Y;
                foreach (var item in Clicks)
                {
                    hash = hash * (item.Point.X ^ item.Point.Y);
                }
            }
            else
            {
                hash = Convert.ToInt32(SaveParameters) * 1 + Convert.ToInt32(ShowFinalDialog) * 2;
            }

            return hash;
        }
    }

    public sealed class Click : ICloneable
    {
        public Point Point { get; set; }
        public int Count { get; set; } = 1;
        public int DelayBefore { get; set; } = 100;
        public bool Enabled { get; set; }

        public object Clone()
        {
            return new Click
            {
                Point = Point,
                Count = Count,
                DelayBefore = DelayBefore,
                Enabled = Enabled,
            };
        }
    }
}
