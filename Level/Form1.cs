using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;


namespace Level
{
    public partial class Form1 : Form
    {

    public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public System.Drawing.Bitmap b;
        public DateTime d;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = (string.Format("{0} : {1}", "Lv", "?"));
            this.label2.Text = (string.Format("{0} : {1}", "녹색", "?"));
            this.label3.Text = (string.Format("{0} : {1}", "황색", "?"));
            this.label4.Text = (string.Format("{0} : {1}", "적색", "?"));
            this.label5.Text = (string.Format("{0}", "다시 불러오는중"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string requestURL = "https://kwatch-24h.net/EQLevel.json";
            WebRequest request = WebRequest.Create(requestURL);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            try
            {
                string data = reader.ReadToEnd();
                var o = JObject.Parse(data);

                this.label1.Text = (string.Format("{0} : {1}", "Lv", (string)o["l"]));
                this.label2.Text = (string.Format("{0} : {1}", "녹색", (string)o["g"]));
                this.label3.Text = (string.Format("{0} : {1}", "황색", (string)o["y"]));
                this.label4.Text = (string.Format("{0} : {1}", "적색", (string)o["r"]));
                this.label5.Text = (string.Format("{0} : {1}    {2}", "기준시각", (string)o["t"], (string)o["e"]));
            }
            catch
                {
                    this.label1.Text = (string.Format("{0} : {1}", "Lv", "?"));
                    this.label2.Text = (string.Format("{0} : {1}", "녹색", "?"));
                    this.label3.Text = (string.Format("{0} : {1}", "황색", "?"));
                    this.label4.Text = (string.Format("{0} : {1}", "적색", "?"));
                    this.label5.Text = (string.Format("{0}", "다시 불러오는중"));
                }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void 콘텐츠_Opening(object sender, CancelEventArgs e)
        {
           
        }
    }
}
