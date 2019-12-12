using System;
using System.Windows.Forms;
using DBHealthCheck.Utils;
using System.Globalization;

namespace UserConfig
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ScheduleDialog : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public ScheduleDialog()
        {
            InitializeComponent();

            foreach (object value in Enum.GetValues(typeof(RunInterval)))
            {
                if (RunInterval.None.Equals(value))
                    continue;
                intervalComboBox.Items.Add(value);
            }

            addInfoDateTimePicker1.MinDate = DateTime.Now;
            addInfoDateTimePicker1.MaxDate = DateTime.Now.AddYears(1);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void intervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (intervalComboBox.SelectedIndex >= 0)
            {
                object value = intervalComboBox.Items[intervalComboBox.SelectedIndex];
                RunInterval interval = (RunInterval)Enum.Parse(typeof(RunInterval), value.ToString());
                switch (interval)
                {
                    case RunInterval.Hourly:
                        addInfoComboBox.Visible = false;
                        addInfoDateTimePicker1.Visible = true;
                        addInfoDateTimePicker1.CustomFormat = "mm:ss";
                        addInfoDateTimePicker1.Format = DateTimePickerFormat.Custom;
                        addInfoDateTimePicker1.ShowUpDown = true;
                        addInfoDateTimePicker1.MinDate = DateTime.Now.AddDays(-1);
                        addInfoLabel.Text = "Execution Time (mm:ss) : ";
                        addInfoLabel.Visible = true;
                        return;
                    case RunInterval.Daily:
                        addInfoLabel.Text = "Execution Time (hh:mm): ";
                        addInfoComboBox.Visible = false;
                        addInfoDateTimePicker1.Visible = true;
                        addInfoDateTimePicker1.CustomFormat = "HH:mm";
                        addInfoDateTimePicker1.Format = DateTimePickerFormat.Custom;
                        addInfoDateTimePicker1.ShowUpDown = true;
                        addInfoDateTimePicker1.MinDate = DateTime.Now.AddDays(-1);
                        addInfoLabel.Visible = true;
                        break;
                    case RunInterval.Weekly:
                        // show day of the week drop down list
                        addInfoLabel.Text = "Execution Time";
                        addInfoLabel.Visible = true;
                        addInfoComboBox.Items.Clear();
                        foreach (object obj in Enum.GetValues(typeof(DayOfWeek)))
                            addInfoComboBox.Items.Add("Every " + obj);
                        addInfoComboBox.Visible = true;
                        addInfoDateTimePicker1.Visible = true;
                        addInfoDateTimePicker1.Format = DateTimePickerFormat.Custom;
                        addInfoDateTimePicker1.CustomFormat = "HH:mm";
                        addInfoDateTimePicker1.ShowUpDown = true;
                        addInfoDateTimePicker1.MinDate = DateTime.Now.AddDays(-1);
                        break;
                    case RunInterval.Fortnightly:
                        // show day of the week drop down list
                        addInfoLabel.Text = "Select Day of the Week ";
                        addInfoLabel.Visible = true;
                        addInfoComboBox.Items.Clear();
                        foreach (object obj in Enum.GetValues(typeof(DayOfWeek)))
                            addInfoComboBox.Items.Add("Alternate " + obj);
                        addInfoComboBox.Visible = true;
                        addInfoDateTimePicker1.Visible = true;
                        addInfoDateTimePicker1.Format = DateTimePickerFormat.Custom;
                        addInfoDateTimePicker1.CustomFormat = "HH:mm";
                        addInfoDateTimePicker1.ShowUpDown = true;
                        addInfoDateTimePicker1.MinDate = DateTime.Now.AddDays(-1);
                        break;
                    case RunInterval.Monthly:
                        // show day of the  month drop down list
                        addInfoLabel.Text = "Day of Month ";
                        addInfoLabel.Visible = true;
                        addInfoComboBox.Items.Clear();
                        addInfoComboBox.Visible = false;
                        // for (int i = 0; i < 28; i++)
                        addInfoDateTimePicker1.Format = DateTimePickerFormat.Custom;
                        addInfoDateTimePicker1.CustomFormat = @"On dd @ hh:mm";
                        addInfoDateTimePicker1.Visible = true;
                        addInfoDateTimePicker1.ShowUpDown = true;
                        break;
                    case RunInterval.Yearly:
                        addInfoComboBox.Visible = false;
                        addInfoLabel.Visible = true;
                        addInfoLabel.Text = "Date of the year";
                        addInfoDateTimePicker1.Visible = true;
                        addInfoDateTimePicker1.Format = DateTimePickerFormat.Custom;
                        addInfoDateTimePicker1.CustomFormat = @"dd-MMM @ hh:mm";
                        break;
                }
            }
        }

        ///
        public static DialogResult ShowDialog(string caption, ref RunInterval interval, ref string additionalInfo)
        {
            ScheduleDialog dialog = new ScheduleDialog();
            // interval = RunInterval.None;
            // additionalInfo = "";
            if (interval != RunInterval.None && !String.IsNullOrEmpty(additionalInfo))
            {
                int index = dialog.intervalComboBox.FindString(interval.ToString());
                if (index != -1)
                    dialog.intervalComboBox.SelectedIndex = index;

                switch (interval)
                {
                    case RunInterval.Hourly:
                        dialog.addInfoDateTimePicker1.Value = DateTime.ParseExact(additionalInfo,
                            "mm:ss", CultureInfo.InvariantCulture);
                        break;
                    case RunInterval.Daily:
                        dialog.addInfoDateTimePicker1.Value = DateTime.ParseExact(additionalInfo,
                            "HH:mm", CultureInfo.InvariantCulture);

                        // dialog.addInfoComboBox.SelectedIndex = dialog.addInfoComboBox.FindString(additionalInfo);
                        break;
                    case RunInterval.Weekly:
                        string day = additionalInfo.Substring(0, additionalInfo.IndexOf(" at "));
                        dialog.addInfoComboBox.SelectedIndex = dialog.addInfoComboBox.FindString("Every " + day.Trim());
                        string time = additionalInfo.Substring(additionalInfo.IndexOf(" at ") + " at ".Length - 1);
                        dialog.addInfoDateTimePicker1.Value = DateTime.ParseExact(time.Trim(),
                            "HH:mm", CultureInfo.InvariantCulture);
                        break;
                    case RunInterval.Fortnightly:
                        day = additionalInfo.Substring(0, additionalInfo.IndexOf(" at "));
                        dialog.addInfoComboBox.SelectedIndex = dialog.addInfoComboBox.FindString("Alternate " + day.Trim());
                        time = additionalInfo.Substring(additionalInfo.IndexOf(" at ") + " at ".Length - 1);
                        dialog.addInfoDateTimePicker1.Value = DateTime.ParseExact(time.Trim(),
                            "HH:mm", CultureInfo.InvariantCulture);
                        break;
                    case RunInterval.Monthly:
                        // dialog.addInfoComboBox.SelectedIndex = dialog.addInfoComboBox.FindString(additionalInfo);
                        day = additionalInfo.Substring(additionalInfo.IndexOf("On ") + "On ".Length, 
                            additionalInfo.IndexOf(" @ ") - " @ ".Length);
                        time = additionalInfo.Substring(additionalInfo.IndexOf(" @ ") + " @ ".Length);
                        DateTime t = Convert.ToDateTime(
                            new DateTime(DateTime.Today.Year, DateTime.Today.Month, Convert.ToInt32(day)).ToShortDateString()
                             + " " + time);
                        dialog.addInfoDateTimePicker1.MinDate = DateTime.Now.AddDays(-1);
                        dialog.addInfoDateTimePicker1.Value = t;
                        dialog.addInfoDateTimePicker1.MaxDate = DateTime.Now.AddDays(1);
                        break;
                    case RunInterval.Yearly:
                        dialog.addInfoDateTimePicker1.MinDate = DateTime.Now.AddYears(-1);
                        dialog.addInfoDateTimePicker1.Value = DateTime.ParseExact(additionalInfo,
                            "dd-MMM @ hh:mm", CultureInfo.InvariantCulture);
                        dialog.addInfoDateTimePicker1.MaxDate = DateTime.Now.AddYears(1);
                        break;
                    default:
                        // do nothing
                        break;
                }
            }
            // Set the members of the new instance
            // according to the value of the parameters
            if (string.IsNullOrEmpty(caption))
            {
                dialog.Text = Application.ProductName;
            }
            else
            {
                dialog.Text = caption;
            }

            // Declare a variable to hold the result to be
            // returned on exitting the method
            DialogResult result = DialogResult.None;

            // Loop round until the user enters
            // some valid data, or cancels.
            while (result == DialogResult.None)
            {
                result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool success = dialog.Validate(out interval, out additionalInfo);
                    if (success)
                        result = DialogResult.OK;
                    else
                        result = DialogResult.None;
                }
                else
                {
                    result = DialogResult.Cancel;
                }
            }

            // Trash the dialog if it is hanging around.
            dialog.Dispose();

            // Send back the result.
            return result;
        }

        private bool Validate(out RunInterval interval, out string additionalInfo)
        {
            bool success = false;
            if (intervalComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("ERR: Run interval is mandatory.", "Validation Errors", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                interval = RunInterval.None;
                additionalInfo = "";
                return success;
            }
            object obj = intervalComboBox.Items[intervalComboBox.SelectedIndex];
            interval = (RunInterval)Enum.Parse(typeof(RunInterval), obj.ToString());
            obj = null;
            switch (interval)
            {
                case RunInterval.Hourly:
                    obj = addInfoDateTimePicker1.Value.ToString("mm:ss"); // default value
                    break;
                case RunInterval.Daily:
                    obj = addInfoDateTimePicker1.Value.ToString("HH:mm");
                    /*if (addInfoComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("ERR: Please select an appropriate hour", "Validation Errors",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        obj = addInfoComboBox.Items[addInfoComboBox.SelectedIndex].ToString();
                    }*/
                    break;
                case RunInterval.Weekly:
                    if (addInfoComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("ERR: Please select a Day of the week", "Validation Errors", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        obj = addInfoComboBox.Items[addInfoComboBox.SelectedIndex].ToString();
                        obj = obj.ToString().Substring("Every ".Length - 1);
                    }
                    obj += " at " + addInfoDateTimePicker1.Value.ToString("HH:mm");
                    break;
                case RunInterval.Fortnightly:
                    if (addInfoComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("ERR: Please select an appropriate hour", "Validation Errors",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        obj = addInfoComboBox.Items[addInfoComboBox.SelectedIndex].ToString();
                        obj = obj.ToString().Substring("Alternate ".Length - 1);
                    }
                    obj += " at " + addInfoDateTimePicker1.Value.ToString("HH:mm");
                    break;
                case RunInterval.Monthly:
                    /*if (addInfoComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("ERR: Please select a Date of the month", "Validation Errors", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        obj = addInfoComboBox.Items[addInfoComboBox.SelectedIndex].ToString();
                        obj = obj.ToString();
                    }*/
                    obj = addInfoDateTimePicker1.Value.ToString(@"On dd @ hh:mm");
                    break;
                case RunInterval.Yearly:
                    obj = addInfoDateTimePicker1.Value.ToString(@"dd-MMM @ hh:mm");
                    break;
                default:
                    obj = null;
                    break;
            }

            if (obj != null)
            {
                success = true;
                additionalInfo = obj.ToString();
            }
            else
                additionalInfo = "";
            return success;
        }
    }
}
