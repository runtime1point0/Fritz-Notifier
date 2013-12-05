using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;

using SpeechLib;

namespace FritzNotifier
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
            notificationTableLayoutPanel.Padding = new Padding(0, 0, System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 0);
            conductor.ConnectionChanged += new EventHandler(conductor_ConnectionChangedCallback);
        }

        /// <summary>
        /// Polling interval in milliseconds
        /// </summary>
        private int PollingInterval { get; set; }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            this.PollingInterval = 1000 * 60; // default to 60 seconds

            LoadPlugins();
            ReadSavedOptions();

            notificationToConfigureComboBox.DisplayMember = "NotificationApplication";
            notificationToConfigureComboBox.ValueMember = "NotificationApplication";
            notificationToConfigureComboBox.DataSource = plugins;

            splitContainer1.BackColor = Color.DarkGray;
            splitContainer1.Panel1.BackColor = this.BackColor;
            splitContainer1.Panel2.BackColor = this.BackColor;

            BindFilterCombo();
            filterComboBox.SelectedIndex = 0;

            simpleViewControl.DismissNotifications += simpleViewControl_DismissNotifications;

            PrepareTextToSpeechAndGestures();

            ActivateTimer();

            // temporary
            //TestFirst();
        }

        private void BindFilterCombo()
        {
            filterComboBox.Items.Clear();

            filterComboBox.Items.Add("All (" + notifications.Count + ")");

            foreach (var plugin in plugins)
            {
                filterComboBox.Items.Add(plugin.NotificationApplication + " (" + notifications.Count(x => x.ApplicationName == plugin.NotificationApplication).ToString() + ")");
            }
        }

        private void ActivateTimer()
        {
            if (plugins != null)
            {
                // if any plugin options are active across any of the pluginoptions associated with any application
                if (pluginOptions.Any(pluginNamePluginOptionsPair => pluginNamePluginOptionsPair.Value.Any(option => option.Active)))
                {
                    if (checkNotifications == null)
                    {
                        checkNotifications = new Timer();
                        checkNotifications.Interval = this.PollingInterval;
                        checkNotifications.Tick += checkNotifications_Tick;
                        checkNotifications_Tick(checkNotifications, EventArgs.Empty); // testing for first time
                        checkNotifications.Start();
                    }

                    noOptionsLabel.Visible = false;
                }
                else
                {
                    if (checkNotifications != null)
                    {
                        checkNotifications.Stop();
                        checkNotifications.Tick -= checkNotifications_Tick;
                        checkNotifications.Dispose();
                        checkNotifications = null;
                    }

                    noOptionsLabel.Visible = true;
                }
            }
            else
            {
                if (checkNotifications != null)
                {
                    checkNotifications.Stop();
                    checkNotifications.Tick -= checkNotifications_Tick;
                    checkNotifications.Dispose();
                    checkNotifications = null;
                }
            }

        }

        void checkNotifications_Tick(object sender, EventArgs e)
        {
            foreach (Plugins.INotifier plugin in plugins)
            {
                var newNotifications = plugin.TestForNotifications(pluginOptions[plugin.NotificationApplication]);
                notifications.AddRange(newNotifications);
                PushNotifications(newNotifications, false);
                if (childForm != null)
                {
                    childForm.update();
                }

                foreach (var newNotification in newNotifications)
                {
                    HandleNotification(newNotification);
                }
            }
        }

        bool pushingNotifications = false;

        internal void PushNotifications(List<Objects.Notification> newNotifications, bool clearPrevious)
        {
            if (pushingNotifications) return;

            pushingNotifications = true;
            
            notificationsTabPage.Text = string.Format("Notifications ({0})", this.notifications.Count);

            int previouslySelectedIndex = filterComboBox.SelectedIndex;
            BindFilterCombo();
            filterComboBox.SelectedIndex = previouslySelectedIndex;

            simpleViewControl.InitializeNotificationsCount(this.plugins, this.notifications);

            bool performLayout = clearPrevious;
            notificationTableLayoutPanel.SuspendLayout();
            if (clearPrevious)
            {
                notificationTableLayoutPanel.Controls.Clear();
                notificationTableLayoutPanel.RowStyles.Clear();
            }
            var shownNotifications = (filterComboBox.Text.StartsWith("All (")) ? newNotifications : newNotifications.Where(x => filterComboBox.Text.StartsWith(x.ApplicationName + " ("));
            foreach (var newNotification in shownNotifications)
            {
                notificationTableLayoutPanel.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
                var notificationControl = new NotificationControl();
                notificationControl.SetupScreen(newNotification);
                notificationControl.DismissNotification += notificationControl_DismissNotification;
                notificationControl.ReplyNotification += notificationControl_ReplayNotification;
                notificationTableLayoutPanel.Controls.Add(notificationControl);
                notificationTableLayoutPanel.SetCellPosition(notificationControl, new TableLayoutPanelCellPosition(0, 0));
                performLayout = true;
            }

            notificationTableLayoutPanel.RowCount = this.notifications.Count;

            notificationTableLayoutPanel.ResumeLayout();

            pushingNotifications = false;
        }

        void notificationControl_ReplayNotification(object sender, NotificationControl.ReplayNotificationEventArgs e)
        {
            HandleGesture((Plugins.Gesture)e.Gesture);
            HandleSpeech(e.Speech);
        }

        void notificationControl_DismissNotification(object sender, NotificationControl.DismissNotificationEventArgs e)
        {
            notifications.Remove(e.notification);
            PushNotifications(notifications, true);
            if (childForm != null)
            {
                childForm.update();
            }
        }

        void simpleViewControl_DismissNotifications(object sender, EventArgs e)
        {
            PushNotifications(notifications, true);
            if (childForm != null)
            {
                childForm.update();
            }
        }

        private void TestFirst()
        {
            notifications.AddRange(plugins[0].TestForNotifications(pluginOptions[plugins[0].NotificationApplication]));
        }

        private void LoadPlugins()
        {
            //var catalog = new System.ComponentModel.Composition.Hosting.DirectoryCatalog(@".\");

            //var container = new System.ComponentModel.Composition.Hosting.CompositionContainer(catalog);

            //container.ComposeParts(this);


            // add any predefined ones here
            plugins.Add(new Twitter.TwitterNotifier());
            plugins.Add(new Facebook.FacebookNotifier());

            if (System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + @"plugins\"))
            {
                foreach (string fileName in System.IO.Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"plugins\", "*.dll", System.IO.SearchOption.TopDirectoryOnly))
                {
                    System.Reflection.Assembly pluginAssembly = System.Reflection.Assembly.LoadFrom(fileName);

                    var plugInTypes = pluginAssembly.GetTypes().Where(x => typeof(Plugins.INotifier).IsAssignableFrom(x));

                    foreach (Type pluginType in plugInTypes)
                    {
                        var plugin = Activator.CreateInstance(pluginType) as Plugins.INotifier;
                        plugins.Add(plugin);
                    }
                }
            }
        }

        private void ReadSavedOptions()
        {
            System.Xml.Linq.XDocument doc = null;

            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\settings.xml"))
            {
                doc = System.Xml.Linq.XDocument.Load(System.Windows.Forms.Application.StartupPath + @"\settings.xml");
            }

            foreach (Plugins.INotifier plugin in plugins)
            {
                /* example of settings file that would store the selected options so they can be reloaded the next time the application loads
                 * <Settings>
                 *  <Setting Application="Twitter">
                 *      <Option Id="1" Active="true"><Numerics><Numeric>20</Numeric></Numerics></Option>
                 *      <Option Id="3" Active="false"><Gestures><Gesture>1</Gesture></Gestures></Option>
                 *  </Setting>
                 * </Settings>
                 */
                // find options from plugin.NotificationApplication in configuration file and set up correct notificationsettings

                System.Xml.Linq.XElement settingElement = null;
                if (doc != null)
                {
                    settingElement = (from item in doc.Descendants("Setting") where item.Attributes("Application").FirstOrDefault().Value == plugin.NotificationApplication select item).FirstOrDefault();
                }
                SetupPluginOptions(plugin, settingElement);
            }
        }

        private void SetupPluginOptions(Plugins.INotifier plugin, System.Xml.Linq.XElement settingElement)
        {
            var options = plugin.GetAllAvailableOptions();

            if (settingElement != null)
            {
                foreach (var optionElement in (from configuredOption in settingElement.Descendants("Option") select configuredOption))
                {
                    var numericsElement = optionElement.Element("Numerics");
                    var numerics = new List<int>();

                    if (numericsElement != null)
                    {
                        foreach (var numericElement in (from numeric in numericsElement.Descendants("Numeric") select numeric))
                        {
                            numerics.Add(Convert.ToInt32(numericElement.Value));
                        }
                    }

                    var gesturesElement = optionElement.Element("Gestures");
                    var gestures = new List<int>();

                    if (gesturesElement != null)
                    {
                        foreach (var gestureElement in (from gesture in gesturesElement.Descendants("Gesture") select gesture))
                        {
                            gestures.Add(Convert.ToInt32(gestureElement.Value));
                        }
                    }

                    var active = Convert.ToBoolean(optionElement.Attribute("Active").Value);

                    int index = options.FindIndex(x => x.OptionId == Convert.ToInt32(optionElement.Attribute("Id").Value));

                    var newOption = new Objects.Option(Convert.ToInt32(optionElement.Attribute("Id").Value), gestures, numerics, active);

                    if (index == -1)
                    {
                        options.Add(newOption);
                    }
                    else
                    {
                        options[index] = newOption;
                    }
                }
            }

            plugin.ResetLastAccessed(options, PollingInterval);
            pluginOptions[plugin.NotificationApplication] = options;
        }

        private void WritePluginOptions()
        {
            System.Xml.Linq.XElement settingsElement = new System.Xml.Linq.XElement("Settings");

            foreach (Plugins.INotifier plugin in plugins)
            {
                /* example of settings file that would store the selected options so they can be reloaded the next time the application loads
                 * <Settings>
                 *  <Setting Application="Twitter">
                 *      <Option Id="1" Active="true"><Numerics><Numeric>20</Numeric></Numerics></Option>
                 *      <Option Id="3" Active="false"><Gestures><Gesture>1</Gesture></Gestures></Option>
                 *  </Setting>
                 * </Settings>
                 */

                SavePluginOptions(plugin.NotificationApplication, pluginOptions[plugin.NotificationApplication], settingsElement);
            }

            settingsElement.Save(System.Windows.Forms.Application.StartupPath + @"\settings.xml");
        }

        private void SavePluginOptions(string application, List<Objects.Option> options, System.Xml.Linq.XElement settingsElement)
        {
            var settingElement = new System.Xml.Linq.XElement("Setting");
            var applicationAttribute = new System.Xml.Linq.XAttribute("Application", application);

            settingElement.Add(applicationAttribute);

            foreach (var option in options)
            {
                var optionElement = new System.Xml.Linq.XElement("Option");
                var optionIdAttr = new System.Xml.Linq.XAttribute("Id", option.OptionId);
                var activeAttr = new System.Xml.Linq.XAttribute("Active", option.Active);

                optionElement.Add(optionIdAttr, activeAttr);

                if (option.Numerics != null && option.Numerics.Count > 0)
                {
                    var numericsElement = new System.Xml.Linq.XElement("Numerics");
                    foreach (int numeric in option.Numerics)
                    {
                        var numericElement = new System.Xml.Linq.XElement("Numeric");
                        numericElement.Add(new System.Xml.Linq.XText(numeric.ToString()));
                        numericsElement.Add(numericElement);
                    }

                    optionElement.Add(numericsElement);
                }

                if (option.Gestures != null && option.Gestures.Count > 0)
                {
                    var gesturesElement = new System.Xml.Linq.XElement("Gestures");
                    foreach (int gesture in option.Gestures)
                    {
                        var gestureElement = new System.Xml.Linq.XElement("Gesture");
                        gestureElement.Add(new System.Xml.Linq.XText(gesture.ToString()));
                        gesturesElement.Add(gestureElement);
                    }

                    optionElement.Add(gesturesElement);
                }

                settingElement.Add(optionElement);
            }

            settingsElement.Add(settingElement);
        }

        private List<Plugins.INotifier> plugins = new List<Plugins.INotifier>();
        private Dictionary<string, List<Objects.Option>> pluginOptions = new Dictionary<string, List<Objects.Option>>();
        private List<Objects.Notification> notifications = new List<Objects.Notification>();
        private SimpleViewForm childForm;
        private Timer checkNotifications;

        #region Direct Robot Interaction

        private Fritz.Conductor conductor = new Fritz.Conductor();
        private SpeechLib.SpVoiceClass spVoice = new SpeechLib.SpVoiceClass();
        private ISpeechObjectTokens tokens;

        private List<Fritz.RobotState> robotStates = new List<Fritz.RobotState>();

        private Fritz.Recorder placeholderRecorder = new Fritz.Recorder();
        private Fritz.Simulator placeholderSimulator = new Fritz.Simulator();

        private void conductor_ConnectionChangedCallback(object sender, EventArgs e)
        {
            if (((Fritz.EventArgs<string>)e).Value.Equals("connected"))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    connectionStatusLabel.Text = "Robot Connected";
                    connectionStatusLabel.ForeColor = Color.Green;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    connectionStatusLabel.Text = "Robot Disconnected";
                    connectionStatusLabel.ForeColor = Color.Red;
                });
            }

            //if (((EventArgs<string>)e).Value.Equals("connected"))
            //{
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        ConnectionState.Text = "Connected";
            //        ConnectionState.BackColor = Color.FromArgb(192, 255, 192);
            //        calibrationToolStripMenuItem.Enabled = true;
            //        demoModeToolStripMenuItem.Enabled = true;
            //        idleModeToolStripMenuItem.Enabled = true;
            //        exerciseModeToolStripMenuItem.Enabled = true;
            //    });
            //}
            //else
            //{
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        ConnectionState.Text = "Disconnected";
            //        ConnectionState.BackColor = Color.FromArgb(255, 192, 192);
            //        calibrationToolStripMenuItem.Enabled = false;
            //        demoModeToolStripMenuItem.Enabled = false;
            //        idleModeToolStripMenuItem.Enabled = false;
            //        exerciseModeToolStripMenuItem.Enabled = false;
            //    });
            //}
        }

        private void PrepareTextToSpeechAndGestures()
        {
            tokens = spVoice.GetVoices("", "");

            for (int i = 0; i < tokens.Count; i++)
            {
                robotVoiceComboBox.Items.Add(tokens.Item(i).GetAttribute("Name"));
            }

            if (tokens.Count > 0)
            {
                robotVoiceComboBox.SelectedIndex = 0;
            }


            conductor.SetControls(ref robotStates, ref placeholderRecorder, ref placeholderSimulator);
            conductor.SetStates(ref robotStates);
            conductor.SetDistanceTrigger(false, false, false, 60);
        }

        void HandleNotification(Objects.Notification notification)
        {
            if (!string.IsNullOrEmpty(notification.Speech) || notification.AssociatedGesture != 0)
            {
                if (notification.AssociatedGesture != 0)
                {
                    HandleGesture((Plugins.Gesture)notification.AssociatedGesture);
                }

                if (!string.IsNullOrEmpty(notification.Speech))
                {
                    HandleSpeech(notification.Speech);
                }
            }
        }

        void HandleGesture(Plugins.Gesture gesture)
        {
            if (gesture != 0)
            {
                switch (gesture)
                {
                    case Plugins.Gesture.Happy:
                        conductor.SetExpression("Happy");
                        System.Threading.Thread.Sleep(500);
                        conductor.SetExpression("Neutral");
                        break;
                    case Plugins.Gesture.Awkward:
                        conductor.SetExpression("Awkward");
                        System.Threading.Thread.Sleep(500);
                        conductor.SetExpression("Neutral");
                        break;
                    case Plugins.Gesture.Surprised:
                        conductor.SetExpression("Surprised");
                        System.Threading.Thread.Sleep(500);
                        conductor.SetExpression("Neutral");
                        break;
                }
            }
        }

        private void HandleSpeech(string speech)
        {
            if (!string.IsNullOrEmpty(speech))
            {
                spVoice.SetVoice((ISpObjectToken)tokens.Item(robotVoiceComboBox.SelectedIndex));

                // TODO: make sure asynchronous call does not cause multiple messages to attempt to be said at once
                spVoice.Speak(speech, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                //spVoice.Speak(speech);
            }

            // TODO: determine if some part of the following needs to be implemented to have robot head move in time with speech
            //            private void insertTextToSpeechToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    InsertTextToSpeech iword = new InsertTextToSpeech();
            //    WaveFormat currentWaveFormat = recorder.GetWaveFormat();
            //    iword.SetWaveFormat(currentWaveFormat);
            //    iword.ShowDialog();
            //    if (iword.DialogResult == DialogResult.OK)
            //    {
            //        MemoryStream partialWave = iword.GetWaveStream();
            //        if (partialWave != null)
            //        {
            //            // insert actual audio bytes
            //            recorder.InsertAudio(partialWave);

            //            long position = recorder.getSelectionStart();
            //            if (position < 0) position = 0;
            //            long adjust = (int)(partialWave.Length / (currentWaveFormat.BitsPerSample / 8));

            //            // shift all simulator views past that insert over by that amount
            //            int i;
            //            //find the start of the insert
            //            for (i = 0; (i < robotStates.Count) && (robotStates[i].position < position); i++) ;
            //            // add new states for each viseme
            //            int j;
            //            List<Viseme> visemes = iword.GetVisemes();
            //            for (j = 0; j < visemes.Count(); j++)
            //            {
            //                RobotState ss = conductor.CreateStateFromViseme(visemes[j].viseme);
            //                ss.position = position + visemes[j].position;
            //                robotStates.Insert(i++, ss);
            //            }
            //            while (i < robotStates.Count)
            //                robotStates[i++].position += adjust;

            //            conductor.SetStates(ref robotStates);
            //        }
            //    }
            //}

            // TODO: also research everything available through conductor.Set(string, bool) with 1st parameter of "Say {speech here}" and 2nd parameter true

        }
        #endregion


        private void simpleViewButton_Click(object sender, EventArgs e)
        {
            if (this.childForm == null)
            {
                childForm = new SimpleViewForm(this, this.plugins, this.notifications);
            }

            this.Visible = false;
            this.Enabled = false;
            childForm.update();
            childForm.Enabled = true;
            childForm.Visible = true;
            //childForm.ShowDialog(this);
        }

        private void notificationToConfigureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pluginOptions.ContainsKey(notificationToConfigureComboBox.SelectedValue.ToString()))
            {
                for (int i = editingOptionsControlHolderPanel.Controls.Count - 1; i >= 0; i--)
                {
                    editingOptionsControlHolderPanel.Controls[i].Dispose();
                }
                var optionsControl = plugins.Single(x => x.NotificationApplication == notificationToConfigureComboBox.SelectedValue.ToString()).CreateOptionsControl(pluginOptions[notificationToConfigureComboBox.SelectedValue.ToString()]);
                optionsControl.OptionsChanged += optionsControl_OptionsChanged;
                editingOptionsControlHolderPanel.Controls.Add(optionsControl);
            }
            else
            {
                for (int i = editingOptionsControlHolderPanel.Controls.Count - 1; i >= 0; i--)
                {
                    editingOptionsControlHolderPanel.Controls[i].Dispose();
                }
                editingOptionsControlHolderPanel.Controls.Add(new Plugins.OptionsControl());
            }
        }

        void optionsControl_OptionsChanged(object sender, EventArgs e)
        {
            var optionsControl = sender as Plugins.OptionsControl;

            pluginOptions[notificationToConfigureComboBox.SelectedValue.ToString()] = optionsControl.Options;

            ActivateTimer();
        }

        private void NotificationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save selected options for reload
            WritePluginOptions();
            if (checkNotifications != null)
            {
                checkNotifications.Stop();
                checkNotifications.Tick -= checkNotifications_Tick;
                checkNotifications.Dispose();
                checkNotifications = null;
            }

            if (this.childForm != null)
            {
                childForm.Close();
            }

            conductor.Close();
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PushNotifications(this.notifications, true);
        }
    }
}
