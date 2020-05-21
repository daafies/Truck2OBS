using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace truck2obs
{

    public partial class Form1 : Form
    {
        private string telemURI = "http://127.0.0.1:25555/api/ets2/telemetry";
        //private string telemURI = "http://192.168.1.207";

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            //myTimer.Stop();
            //myTimer.Enabled = true;
            UpdateTelem();
        }


        public Form1()
        {
            InitializeComponent();
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 3 seconds.
            myTimer.Interval = 3000;
            myTimer.Start();

            languageBox1.Items.AddRange(new object[] { "English", "Deutsch" });

            languageBox1.SelectedItem = Properties.Settings.Default["lingo"];

            if (Properties.Settings.Default["backcolor"]!=null)
            {
                label3.BackColor = this.BackColor = (Color)Properties.Settings.Default["backcolor"];
            }
            if (Properties.Settings.Default["forecolor"] != null)
            {
                label3.ForeColor = (System.Drawing.Color)Properties.Settings.Default["forecolor"];
            }
            ChangeLingo();

            customJobCheckBox.Checked = (bool)Properties.Settings.Default["use_customjobtext"];
            textBox2.Text = (string)Properties.Settings.Default["customjobtext"];
            customNoJobCheckBox.Checked = (bool)Properties.Settings.Default["use_customnojobtext"];
            textBox3.Text = (string)Properties.Settings.Default["customnojobtext"];

        }

        private void ChangeLingo()
        {
            if (Properties.Settings.Default["lingo"].ToString().Equals("English"))
            {
                label1.Text = "Language";
                colorButton.Text = "Background Color";
                button1.Text = "Foreground color";
                label2.Text = "Window capture this area in OBS, or read c:\\tmp\\etsatsroute.txt";

            }
            else if (Properties.Settings.Default["lingo"].ToString().Equals("Deutsch"))
            {
                label1.Text = "Sprache";
                colorButton.Text = "Hintergrundfarbe";
                button1.Text = "Vordergrundfarbe";
                label2.Text = "Fenstercapture dieses bereich in OBS, oder lesen sie c:\\tmp\\etsatsroute.txt";
            }
            else
            {
                label1.Text = "Language";
                colorButton.Text = "Background Color";
                button1.Text = "Foreground color";
                label2.Text = "Window capture this area in OBS, or read c:\\tmp\\etsatsroute.txt";
            }


        }

        
        public void UpdateTelem()
        {
            string tmplabel = "";

            try
            {

                
                WebRequest request = WebRequest.Create(telemURI);

                WebResponse response = request.GetResponse();

                string bla = ((HttpWebResponse)response).StatusDescription;

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);

                    dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);

                    string gamename = stuff.game.gameName;
                    string connected = stuff.game.connected;
                    string cargo = stuff.trailer.name;
                    string startCity = stuff.job.sourceCity;
                    string destCity = stuff.job.destinationCity;
                    int distRemaining = stuff.navigation.estimatedDistance;

                    if (startCity.Equals(""))
                    {
                        if (customNoJobCheckBox.Checked)
                        {
                            tmplabel = textBox1.Text = (string)Properties.Settings.Default["customnojobtext"];
                        }
                        else if (languageBox1.SelectedItem.Equals("English"))
                        {
                            tmplabel = textBox1.Text = "Between jobs";
                        }
                        else
                        {
                            tmplabel = textBox1.Text = "Kein Aktueller Job";
                        }
                    }
                    else
                    {
                        if (gamename.Equals("ATS"))
                        {
                            if (customJobCheckBox.Checked)
                            {
                                string temp = (string)Properties.Settings.Default["customjobtext"];
                                // now replace the @src @dest @cargo @dist
                                temp = temp.Replace("@src", startCity);
                                temp = temp.Replace("@dest", destCity);
                                temp = temp.Replace("@cargo", cargo);
                                temp = temp.Replace("@dist", Math.Round((distRemaining * 0.00062137), 1) + " miles");
                                tmplabel = temp;
                            }
                            else if (languageBox1.SelectedItem.Equals("English"))
                            {
                                tmplabel = startCity + " -> " + destCity + ". " + Math.Round((distRemaining * 0.00062137), 1) + " miles remaining";
                                textBox1.Text = "game: " + gamename + "\r\ncargo: " + cargo + "\r\nstartCity: " + startCity + "\r\nDestination: " + destCity + "\r\nremaining distance: " + Math.Round((distRemaining * 0.00062137), 1) + " miles";
                            }
                            else
                            {
                                tmplabel = startCity + " -> " + destCity + ". Noch " + Math.Round((distRemaining * 0.00062137), 1) + " miles";
                                textBox1.Text = "game: " + gamename + "\r\ncargo: " + cargo + "\r\nstartCity: " + startCity + "\r\nDestination: " + destCity + "\r\nremaining distance: " + Math.Round((distRemaining * 0.00062137), 1) + " miles";
                            }
                        }
                        else if (gamename.Equals("ETS2"))
                        {
                            if (customJobCheckBox.Checked)
                            {
                                string temp = (string)Properties.Settings.Default["customjobtext"];
                                // now replace the @src @dest @cargo @dist
                                temp.Replace("@src", startCity);
                                temp.Replace("@dest", destCity);
                                temp.Replace("@cargo", cargo);
                                temp.Replace("@dist", Math.Round((distRemaining * 0.001), 1) + " km");
                            }
                            if (languageBox1.SelectedItem.Equals("English"))
                                {
                                    tmplabel = startCity + " -> " + destCity + ". " + Math.Round((distRemaining * 0.001), 1) + " km remaining";
                                    textBox1.Text = "game: " + gamename + "\r\ncargo: " + cargo + "\r\nstartCity: " + startCity + "\r\nDestination: " + destCity + "\r\nremaining distance: " + Math.Round((distRemaining * 0.001), 1) + " km";
                                }
                                else
                                {
                                    tmplabel = startCity + " -> " + destCity + ". Noch " + Math.Round((distRemaining * 0.001), 1) + " km";
                                    textBox1.Text = "game: " + gamename + "\r\ncargo: " + cargo + "\r\nstartCity: " + startCity + "\r\nDestination: " + destCity + "\r\nremaining distance: " + Math.Round((distRemaining * 0.001), 1) + " km";
                                }
                        }



                    }
                    /*
        string gamename = stuff.game.gameName;
        string connected = stuff.game.connected;
        string cargo = stuff.trailer.name;
        string startCity = stuff.job.sourceCity;
        string destCity = stuff.job.destinationCity;
        int distRemaining = stuff.navigation.estimatedDistance;
 * */
                    using (StreamWriter outputFile = new StreamWriter("c:/tmp/startcity.txt"))
                    {
                        outputFile.WriteLine(stuff.job.sourceCity);
                    }
                    using (StreamWriter outputFile = new StreamWriter("c:/tmp/destcity.txt"))
                    {
                        outputFile.WriteLine(stuff.job.destinationCity);
                    }
                    using (StreamWriter outputFile = new StreamWriter("c:/tmp/cargo.txt"))
                    {
                        outputFile.WriteLine(stuff.trailer.name);
                    }
                    using (StreamWriter outputFile = new StreamWriter("c:/tmp/game.txt"))
                    {
                        outputFile.WriteLine(stuff.game.gameName);
                    }
                    using (StreamWriter outputFile = new StreamWriter("c:/tmp/distance.txt"))
                    {
                        if (gamename != null)
                        {

                            if (gamename.Equals("ATS"))
                            {
                                outputFile.WriteLine(Math.Round((distRemaining * 0.00062137), 1).ToString() + " miles");
                            }
                            else
                            {
                                outputFile.WriteLine(Math.Round((distRemaining * 0.001), 1).ToString() + " km");
                            }
                        }
                    }
                }
            }
            catch
            {
                if (languageBox1.SelectedItem.Equals("English"))
                {
                    tmplabel = "Please make sure to start the ETS2Telemetry server";
                }
                else if (languageBox1.SelectedItem.Equals("Deutsch"))
                {
                    tmplabel = "Bitte starten Sie den ETS2Telemetry Server";
                }
                
            }

            label3.Text = tmplabel;
            // Write the string array to a new file named "WriteLines.txt".
            Directory.CreateDirectory("c:/tmp/");
            using (StreamWriter outputFile = new StreamWriter("c:/tmp/etsatsroute.txt"))
            {
                outputFile.WriteLine(tmplabel);
            }



        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = this.BackColor;


            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["backcolor"] = label3.BackColor = this.BackColor = MyDialog.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = label3.ForeColor;


            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["forecolor"] = label3.ForeColor = MyDialog.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void languageBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["lingo"] = languageBox1.SelectedItem;
            Properties.Settings.Default.Save();
            ChangeLingo();
        }

        private void customJobTextBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["use_customjobtext"] = customJobCheckBox.Checked;
            Properties.Settings.Default.Save();

            if (customJobCheckBox.Checked == false)
            {
                textBox2.ReadOnly = true;
                textBox2.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                textBox2.ReadOnly = false;
                textBox2.BackColor = System.Drawing.SystemColors.Window;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["customjobtext"] = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void customNoJobCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["use_customnojobtext"] = customNoJobCheckBox.Checked;
            Properties.Settings.Default.Save();

            if (customNoJobCheckBox.Checked == false)
            {
                textBox3.ReadOnly = true;
                textBox3.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                textBox3.ReadOnly = false;
                textBox3.BackColor = System.Drawing.SystemColors.Window;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["customnojobtext"] = textBox3.Text;
            Properties.Settings.Default.Save();
        }
    }

    
}


/*
 *{"game":{"connected":false,"gameName":null,"paused":false,"time":"0001-01-01T00:00:00Z","timeScale":0.0,"nextRestStopTime":"0001-01-01T00:00:00Z","version":"0.0","telemetryPluginVersion":"0"},
 * "truck":{"id":"","make":"","model":"","speed":0.0,"cruiseControlSpeed":0.0,"cruiseControlOn":false,"odometer":0.0,"gear":0,"displayedGear":0,"forwardGears":0,"reverseGears":0,"shifterType":"","engineRpm":0.0,"engineRpmMax":0.0,"fuel":0.0,"fuelCapacity":0.0,"fuelAverageConsumption":0.0,"fuelWarningFactor":0.0,"fuelWarningOn":false,"wearEngine":0.0,"wearTransmission":0.0,"wearCabin":0.0,"wearChassis":0.0,"wearWheels":0.0,"userSteer":0.0,"userThrottle":0.0,"userBrake":0.0,"userClutch":0.0,"gameSteer":0.0,"gameThrottle":0.0,"gameBrake":0.0,"gameClutch":0.0,"shifterSlot":0,"engineOn":false,"electricOn":false,"wipersOn":false,"retarderBrake":0,"retarderStepCount":0,"parkBrakeOn":false,"motorBrakeOn":false,"brakeTemperature":0.0,"adblue":0.0,"adblueCapacity":0.0,"adblueAverageConsumption":0.0,"adblueWarningOn":false,"airPressure":0.0,"airPressureWarningOn":false,"airPressureWarningValue":0.0,"airPressureEmergencyOn":false,"airPressureEmergencyValue":0.0,"oilTemperature":0.0,"oilPressure":0.0,"oilPressureWarningOn":false,"oilPressureWarningValue":0.0,"waterTemperature":0.0,"waterTemperatureWarningOn":false,"waterTemperatureWarningValue":0.0,"batteryVoltage":0.0,"batteryVoltageWarningOn":false,"batteryVoltageWarningValue":0.0,"lightsDashboardValue":0.0,"lightsDashboardOn":false,"blinkerLeftActive":false,"blinkerRightActive":false,"blinkerLeftOn":false,"blinkerRightOn":false,"lightsParkingOn":false,"lightsBeamLowOn":false,"lightsBeamHighOn":false,"lightsAuxFrontOn":false,"lightsAuxRoofOn":false,"lightsBeaconOn":false,"lightsBrakeOn":false,"lightsReverseOn":false,
 * "placement":{"x":0.0,"y":0.0,"z":0.0,"heading":0.0,"pitch":0.0,"roll":0.0},"acceleration":{"x":0.0,"y":0.0,"z":0.0},"head":{"x":0.0,"y":0.0,"z":0.0},"cabin":{"x":0.0,"y":0.0,"z":0.0},"hook":{"x":0.0,"y":0.0,"z":0.0}},
 * "trailer":{"attached":false,"id":"","name":"","mass":0.0,"wear":0.0,"placement":{"x":0.0,"y":0.0,"z":0.0,"heading":0.0,"pitch":0.0,"roll":0.0}},
 * "job":{"income":0,"deadlineTime":"0001-01-01T00:00:00Z","remainingTime":"0001-01-01T00:00:00Z","sourceCity":"","sourceCompany":"","destinationCity":"","destinationCompany":""},
 * "navigation":{"estimatedTime":"0001-01-01T00:00:00Z","estimatedDistance":0,"speedLimit":0}}
}

*/
