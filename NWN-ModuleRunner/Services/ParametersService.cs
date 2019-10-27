using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Services
{
    public sealed class ParametersService
    {
        private Parameters parameters;
        private Parameters prevParameters;

        public const String DEFAULT_PARAMETERS_PATH = "../../parameters.json";
        public String path { get; private set; }


        public ParametersService(String path = DEFAULT_PARAMETERS_PATH)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            this.path = path;
            parameters = ReadOrDefaultParameters(path);
            NormalizeParameters();
            prevParameters = parameters.Clone() as Parameters;
        }

        public ParametersService(Parameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            this.parameters = parameters;
            prevParameters = parameters.Clone() as Parameters;
        }


        private void NormalizeParameters()
        {
            if (parameters.Templates == null)
                parameters.Templates = new List<Template>(5);
            if (parameters.Templates.Count < 1)
                parameters.Templates.Add(new Template(null, true));

            foreach (var template in parameters.Templates)
            {
                NormalizeTemplate(template);
            }
        }

        private void NormalizeTemplate(Template template)
        {
            if (template.Clicks == null)
                template.Clicks = new List<Click>();
            if (template.Clicks.Count < 1)
                template.Clicks.Add(new Click());

            foreach (var click in template.Clicks)
            {
                if (click.Count < 1)
                    click.Count = 1;
            }
        }

        #region Template manipulations
        public void AddTemplate(String name)
        {
            parameters.Templates.Add(new Template(name, true));
        }

        public void RemoveTemplate(Template template)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template));

            if (parameters.Templates.Count > 1)
                parameters.Templates.Remove(template);
        }

        public void CloneTemplate(Template template)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template));

            Template copy = template.Clone() as Template;
            parameters.Templates.Add(copy);
        }
        #endregion

        #region Click manipulations
        public void AddClick(Template template)
        {
            CheckTemplate(template);

            AddClick(template, new Click());
        }

        public void AddClick(Template template, Click click)
        {
            CheckTemplate(template);
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            template.Clicks.Add(click);
        }

        public void RemoveClick(Template template, Click click)
        {
            CheckTemplate(template);
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            if (template.Clicks.Count > 1)
                template.Clicks.Remove(click);
        }

        public void RemoveAllClicks(Template template)
        {
            CheckTemplate(template);

            template.Clicks.Clear();
            template.Clicks.Add(new Click());
        }

        public void CloneClick(Template template, Click click)
        {
            CheckTemplate(template);
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            Click copy = click.Clone() as Click;
            template.Clicks.Add(copy);
        }

        public void ChangeClickPoint(Template template, Click click, Point newPoint)
        {
            CheckTemplate(template);
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            if (template.Clicks.Contains(click))
            {
                click.Point = newPoint;
            }
        }

        private void CheckTemplate(Template template)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template));
            if (!parameters.Templates.Contains(template))
                throw new ArgumentException($"Invlid template");
        }
        #endregion

        #region Read/Write/Default
        private Parameters ReadOrDefaultParameters(String path = DEFAULT_PARAMETERS_PATH)
        {
            if (!File.Exists(DEFAULT_PARAMETERS_PATH))
                return GetDefaultParameters();

            try
            {
                using (JsonTextReader jReader = new JsonTextReader(new StreamReader(path)))
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

        public bool TryWriteParameters()
        {
            return TryWriteParameters(path);
        }

        public bool TryWriteParameters(String path)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            try
            {
                using (JsonTextWriter jWriter = new JsonTextWriter(new StreamWriter(path)))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    serializer.Serialize(jWriter, parameters);

                    prevParameters = parameters.Clone() as Parameters;

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

        private Parameters GetDefaultParameters()
        {
            Parameters result = new Parameters(true);

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            // Default click - center screen.
            result.Templates[0].Clicks[0].Point = new Point(w / 2, h / 2);
            result.SaveParameters = true;
            result.ShowFinalDialog = true;

            return result;
        }
        #endregion

        public bool AreParametersChanged
        {
            get
            {
                return !parameters.Equals(prevParameters);
            }
        }

        public List<Template> Templates
        {
            get
            {
                return parameters.Templates;
            }
        }

        public bool SaveParameters
        {
            get
            {
                return parameters.SaveParameters;
            }
            set
            {
                parameters.SaveParameters = value;
            }
        }

        public bool ShowFinalDialog
        {
            get
            {
                return parameters.ShowFinalDialog;
            }
            set
            {
                parameters.ShowFinalDialog = value;
            }
        }
    }

    public sealed class Parameters : ICloneable
    {
        public List<Template> Templates { get; set; } = new List<Template>(5);
        public bool SaveParameters { get; set; }
        public bool ShowFinalDialog { get; set; }


        public Parameters(bool init = false)
        {
            if (init)
                Templates.Add(new Template(null, true));
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as Parameters);
        }

        public bool Equals(Parameters paramsObj)
        {
            if (Object.ReferenceEquals(this, paramsObj))
                return true;

            bool result = paramsObj != null;

            if (!result)
                return false;

            result = (Templates == null && paramsObj.Templates == null)
                || (Templates != null && paramsObj.Templates != null && Templates.Count == paramsObj.Templates.Count);

            if (!result)
                return false;

            for (int i = 0; i < Templates.Count; i++)
            {
                if (!Templates[i].Equals(paramsObj.Templates[i]))
                    return false;
            }

            result = SaveParameters == paramsObj.SaveParameters
                && ShowFinalDialog == paramsObj.ShowFinalDialog;

            return result;
        }

        // Just random operations.
        public override int GetHashCode()
        {
            int result = 0;

            foreach (var template in Templates)
            {
                result = (result + template.GetHashCode()) ^ 99;
            }

            return result;
        }

        public object Clone()
        {
            Parameters result = new Parameters
            {
                SaveParameters = SaveParameters,
                ShowFinalDialog = ShowFinalDialog,
            };

            foreach (var template in Templates)
            {
                result.Templates.Add(template.Clone() as Template);
            }

            return result;
        }
    }

    public sealed class Template : ICloneable
    {
        public List<Click> Clicks { get; set; } = new List<Click>();
        public String Name { get; set; }

        public const String DEFAULT_TEMPLATE_NAME = "<No name>";


        public Template(String name, bool init = false)
        {
            Name = name ?? DEFAULT_TEMPLATE_NAME;
            if (init)
                Clicks.Add(new Click());
        }


        public bool Equals(Template template)
        {
            if (template == null)
                return false;

            if (ReferenceEquals(this, template))
                return true;

            bool temp = true;

            temp = (Clicks == null && template.Clicks == null)
                || (Clicks != null && template.Clicks != null && Clicks.Count == template.Clicks.Count);

            if (!temp)
                return false;

            for (int i = 0; i < Clicks.Count; i++)
            {
                if (!Clicks[i].Equals(template.Clicks[i]))
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Template);
        }

        // Just random operations.
        public override int GetHashCode()
        {
            int result = 0;

            foreach (var click in Clicks)
            {
                result = (result + click.GetHashCode()) ^ 19;
            }

            return result;
        }

        public object Clone()
        {
            Template copy = new Template($"{Name}+");

            foreach (var click in Clicks)
            {
                copy.Clicks.Add(click.Clone() as Click);
            }

            return copy;
        }
    }

    public sealed class Click : ICloneable
    {
        public Point Point { get; set; }
        public int Count { get; set; } = 1;
        public int DelayBefore { get; set; } = 100;
        public bool Enabled { get; set; } = true;


        public bool Equals(Click click)
        {
            if (click == null)
                return false;

            if (ReferenceEquals(this, click))
                return true;

            return Point == click.Point
                && Count == click.Count
                && DelayBefore == click.DelayBefore
                && Enabled == click.Enabled;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Click);
        }

        // Just random operations.
        public override int GetHashCode()
        {
            return (Point.X ^ Point.Y) * DelayBefore;
        }

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
