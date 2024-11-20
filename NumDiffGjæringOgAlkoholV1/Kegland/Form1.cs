using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace KegLandForms
{
    public partial class Form1 : Form
    {
        private KeglandApiService _keg = new KeglandApiService("Tormtonnessen@gmail.com", "PwMSFypQRyyR");
        private string _token;
        public Form1()
        {
            InitializeComponent();

            //_token =  _keg.GetAccessTokenAsync().Result;
            //var hydrometers =  _keg.GetHydrometersAsync(_token).Result;

            //hydroMeters.DataSource = hydroMeters;
            //hydroMeters.DisplayMember = "name"; // What you want to show in the ComboBox
            //hydroMeters.ValueMember = "id";
        }

        

            private async void FetchData_Click(object sender, EventArgs e)
        {
            try
            {

                //var keg = new KeglandApiService("Tormtonnessen@gmail.com", "PwMSFypQRyyR");
                if (!string.IsNullOrEmpty(txtDaysBackInTime.Text) && int.TryParse(txtDaysBackInTime.Text, out int daysBack))
                {

                    //foreach (var hydrometer in hydrometers)
                    //                  {
                    //Du må kanskje hente data ut litt i chunks..
                    //Hvis du har flere hydromtere så må du hente endre litt i Gui.. nå vil den bare vise det siste.. 
                    DateTime fromDate = DateTime.UtcNow.AddDays(Convert.ToInt16(txtDaysBackInTime.Text) * -1);
                    DateTime toDate = DateTime.UtcNow;
                    HydrometerIdOgNavn.Text = "Hydrometer navn: " + hydroMeters.SelectedText.ToString();
                    var telemetry = await _keg.GetTelemetryAsync(_token, hydroMeters.SelectedValue?.ToString(), fromDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), toDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
                    dataGridView1.DataSource = telemetry;
                    InitializeChart(telemetry);
                    if (checkBox1.Checked == true)
                    {
                        SaveTelemetryToCsv(telemetry, hydroMeters.SelectedValue.ToString() + hydroMeters.SelectedText.ToString().ToString().Replace(" ", ""));
                    }
                    //ChartTelemetry

                    //                }
                }
                else
                {
                    MessageBox.Show("Idiot! Please add days back in time properly!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Shit happen, did you try to go more days back than legal? " + ex.Message);
            }
        }

        public static void SaveTelemetryToCsv(List<Telemetry> telemetryData, string name)
        {
            // Ensure the directory exists
            string directoryPath = @"C:\temp";
            Directory.CreateDirectory(directoryPath);

            // Create the filename with the date and time
            string filename = $"Telemetry_{DateTime.Now:yyyyMMdd_HHmmss}{name}x.csv";
            string filePath = Path.Combine(directoryPath, filename);

            // Initialize StringBuilder to construct CSV content
            StringBuilder csvContent = new StringBuilder();

            // Add CSV header
            csvContent.AppendLine("Temperature,Gravity,GravityVelocity,Battery,Version,RowKey,CreatedOn,MacAddress,Rssi");

            // Add rows for each Telemetry object
            foreach (var telemetry in telemetryData)
            {
                csvContent.AppendLine($"{telemetry.temperature}," +
                                      $"{telemetry.gravity}," +
                                      $"{telemetry.gravityVelocity}," +
                                      $"{telemetry.battery}," +
                                      $"{telemetry.version}," +
                                      $"{telemetry.rowKey}," +
                                      $"{telemetry.createdOn:yyyy-MM-dd HH:mm:ss}," +
                                      $"{telemetry.macAddress}," +
                                      $"{telemetry.rssi}");
            }

            // Write CSV content to file
            File.WriteAllText(filePath, csvContent.ToString());


        }

        private void InitializeChart(List<Telemetry> telemetry)
        {
            // Configure Chart Area
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("MainArea"));

            // Set up X-axis as DateTime and Y-axis as a numerical value
            chart1.ChartAreas["MainArea"].AxisX.LabelStyle.Format = "HH:mm"; // Show hours and minutes
            chart1.ChartAreas["MainArea"].AxisX.Title = "Created On";
            chart1.ChartAreas["MainArea"].AxisY.Title = "Values";

            // Create the Temperature series
            var temperatureSeries = new Series("Temperature")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double
            };

            // Create the Gravity series
            var gravitySeries = new Series("Gravity")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double
            };

            // Add series to chart
            chart1.Series.Clear();
            chart1.Series.Add(temperatureSeries);
            chart1.Series.Add(gravitySeries);

            // Add data points to the series
            List<Telemetry> telemetryData = telemetry; // Retrieve your data here
            foreach (var data in telemetryData)
            {
                temperatureSeries.Points.AddXY(data.createdOn, data.temperature);
                gravitySeries.Points.AddXY(data.createdOn, data.gravity);
            }

            // Optional: Set chart display properties


            //chart1.Dock = DockStyle.Fill;
        }

        private async void DoInit_Click(object sender, EventArgs e)
        {

            _token =  await _keg.GetAccessTokenAsync();
            var hydrometers = await  _keg.GetHydrometersAsync(_token);

            hydroMeters.DataSource = hydrometers;
            hydroMeters.DisplayMember = "name"; // What you want to show in the ComboBox
            hydroMeters.ValueMember = "id";
        }
    }
}
