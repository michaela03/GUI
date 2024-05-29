using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class AdditionalWindow : Form
    {
        string dialogStatus;
        string btn;
        DialogProcessor dialogProcessor;
        public AdditionalWindow(string dialogStatus,DialogProcessor dialogProcessor, string btn=" ")
        {
            this.dialogStatus = dialogStatus;
            this.dialogProcessor = dialogProcessor;
            this.btn = btn;
            InitializeComponent();
            switch (dialogStatus)
            {
                case "rotate":
                    hight_label.Visible = false;
                    hight_textBox.Visible = false;
                    allValue_label.Text = "Degree :";

                    break;
                case "resize":
                    hight_label.Visible = true;
                    hight_textBox.Visible = true;
                    allValue_label.Text = "Width :";
                    break;
                case "opacity":
                    hight_label.Visible = false;
                    hight_textBox.Visible = false;
                    allValue_label.Text = "Opacity :";
                    break;
                case "border width":
                    hight_label.Visible = false;
                    hight_textBox.Visible = false;
                    allValue_label.Text = "Border Width :";
                    break;

            }

           
        }
       

        private void okButton_Click(object sender, EventArgs e)
        {
            switch (dialogStatus)
            {
                case "rotate" :
                    this.Hide();
                    try
                    {
                        dialogProcessor.Rotate(float.Parse(allValue_textBox.Text),btn);
                    }catch(Exception)
                    {
                        MessageBox.Show("Invalid value!!!");
                    }
                    this.Close();
                    break;
                case "resize":
                    this.Hide();
                    float height, width;
                    try
                    {
                        if (!allValue_textBox.Text.Equals(""))
                        {
                            height =float.Parse(hight_textBox.Text);
                        }
                        else
                        {
                            height = -1;
                        }
                        if (!allValue_textBox.Text.Equals(""))
                        {
                            width = float.Parse(allValue_textBox.Text);
                        }
                        else
                        {
                            width = -1;
                        }
                        dialogProcessor.SetSize(width, height,btn);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("please insert valid number");
                    }
                    this.Close();
                    break;
                case "opacity":
                    this.Hide();
                    try
                    {
                        int opacity = int.Parse(allValue_textBox.Text);
                        if (opacity<0||opacity > 255)
                        {
                            MessageBox.Show("Invalid value!!! Opacity has to be between 0 and 255.");
                            break;
                        }
                        
                        dialogProcessor.SetOpacity(opacity, btn);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid value!!!");
                    }
                    this.Close();
                    break;
               case "border width":
                    this.Hide();
                    try
                    {
                        dialogProcessor.SetBorderWidth(float.Parse(allValue_textBox.Text),btn);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid value!!!");
                    }
                    this.Close();
                    break;

            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void allValue_label_Click(object sender, EventArgs e)
        {

        }
    }
}
