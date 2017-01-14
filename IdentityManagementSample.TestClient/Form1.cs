using System;
using System.Net.Http;
using System.Windows.Forms;

namespace IdentityManagementSample.TestClient
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();

            var handler = new HttpClientHandler() { UseDefaultCredentials = true };
            _httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:9005") };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _httpClient.GetStringAsync("user/all");

                MessageBox.Show("result: " + result);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error has occurred: " + ex.ToString(), "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
