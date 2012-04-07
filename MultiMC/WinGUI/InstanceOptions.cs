using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MultiMC;
using MultiMC.GUI;

namespace MultiMC.WinGUI
{
    public partial class InstanceOptions : WinFormsDialog
    {
        #region Fields
        Instance instance;
        ConfigFile cfg;
        #endregion

        #region Methods
        public InstanceOptions(Instance instance)
        {
            InitializeComponent();

            spinner_MemMax.Minimum = 512;
            spinner_MemMin.Minimum = 512;
            spinner_MemMax.Maximum = 65536;
            spinner_MemMin.Maximum = 65536;
            spinner_MemMax.Increment = 512;
            spinner_MemMin.Increment = 512;

            // initialize fields
            this.instance = instance;
            this.cfg = instance.getConfig();

            Load();
        }

        private void Load()
        {
            // initialize options
            check_defaultMemMax.Checked = !cfg.ContainsKey("mem_max");
            spinner_MemMax.Enabled = cfg.ContainsKey("mem_max");
            spinner_MemMax.Value = cfg["mem_max", AppSettings.Main.MaxMemoryAlloc];

            check_defaultMemMin.Checked = !cfg.ContainsKey("mem_min");
            spinner_MemMin.Enabled = cfg.ContainsKey("mem_min");
            spinner_MemMin.Value = cfg["mem_min", AppSettings.Main.MinMemoryAlloc];

            check_defaultShowConsole.Checked = !cfg.ContainsKey("console_show");
            check_ShowConsole.Enabled = cfg.ContainsKey("console_show");
            check_ShowConsole.Checked = cfg["console_show", AppSettings.Main.ShowConsole];

            check_defaultAutoClose.Checked = !cfg.ContainsKey("console_autoclose");
            check_AutoClose.Enabled = cfg.ContainsKey("console_autoclose");
            check_AutoClose.Checked = cfg["console_autoclose", AppSettings.Main.AutoCloseConsole];
        }

        private bool ConditionalSetOrRemove(bool condition, string key, string value)
        {
            if (condition)
            {
                cfg[key] = value;
                return true;
            }
            else
            {
                cfg.RemoveIfExists(key);
                return false;
            }
        }
        private bool ConditionalSetOrRemove(bool condition, string key, bool value)
        {
            return ConditionalSetOrRemove(condition, key, Convert.ToString(value));
        }
        private bool ConditionalSetOrRemove(bool condition, string key, int value)
        {
            return ConditionalSetOrRemove(condition,key,Convert.ToString(value));
        }

        private void Save()
        {
            ConditionalSetOrRemove(!check_defaultMemMax.Checked, "mem_max", (int)spinner_MemMax.Value);
            ConditionalSetOrRemove(!check_defaultMemMin.Checked, "mem_min", (int)spinner_MemMin.Value);
            ConditionalSetOrRemove(!check_defaultShowConsole.Checked, "console_show", check_ShowConsole.Checked);
            ConditionalSetOrRemove(!check_defaultAutoClose.Checked, "console_autoclose", check_AutoClose.Checked);
            instance.SaveData();
        }

        protected override void OnResponse(DialogResponse response)
        {
            if (response == DialogResponse.OK)
                Save();

            this.Close();

            base.OnResponse(response);
        }
        #endregion

        #region Events
        private void button_cancel_Click(object sender, EventArgs e)
        {
            OnResponse(GUI.DialogResponse.Cancel);
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            OnResponse(GUI.DialogResponse.OK);
        }
        #endregion

        private void check_defaultMemMin_CheckedChanged(object sender, EventArgs e)
        {
            spinner_MemMin.Enabled = !check_defaultMemMin.Checked;
        }

        private void check_defaultMemMax_CheckedChanged(object sender, EventArgs e)
        {
            spinner_MemMax.Enabled = !check_defaultMemMax.Checked;
        }

        private void check_defaultShowConsole_CheckedChanged(object sender, EventArgs e)
        {
            check_ShowConsole.Enabled = !check_defaultShowConsole.Checked;
        }

        private void check_defaultAutoClose_CheckedChanged(object sender, EventArgs e)
        {
            check_AutoClose.Enabled = !check_defaultAutoClose.Checked;
        }
    }
}
