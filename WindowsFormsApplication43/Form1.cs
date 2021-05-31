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
using Newtonsoft.Json.Linq;




namespace WindowsFormsApplication43
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string city;
        private void button1_Click(object sender, EventArgs e)
        {

            city = txtcity.Text;
            
            string uri = string.Format("http://api.weatherstack.com/current?access_key=a23a11c24ea68b65b5a91776542b9730&query={0}", city);
            WebClient c = new WebClient();
            
            var json = c.DownloadString(uri);
            dynamic data = JObject.Parse(json);

            string areaType = data.request.type;
            string query = data.request.query;
            string unit = data.request.unit;
            

            var desArray = data.current.weather_descriptions;
            string description = string.Join(" ", desArray);

            //WebClient client = new WebClient();
            var imageUrlArr = data.current.weather_icons;
            string imageUrl = imageUrlArr[0];


            //WebClient client = new WebClient();
            //byte[] image = client.DownloadData(imageUrl);
            //MemoryStream stream = new MemoryStream(image);


            //Stream stream = client.OpenRead(imageUrl);
            //Bitmap newBitMap = new Bitmap(stream);
            //Bitmap icon = newBitMap;
            //pictureBox1.Image = icon;




            //WebRequest request = WebRequest.Create(imageUrl); //Initializes an instance with the given URL
            //using (var response = request.GetResponse()) //Tries to access the object
            //{
            //    using (var str = response.GetResponseStream()) //Returns the metadata of the image
            //    {
            //        pictureBox1.Image = Bitmap.FromStream(str); //Creates a bitmap based on the loaded metadata, in the sequence inserts into the image property.
            //    }
            //}

            //pictureBox1.Load(imageUrl);

            //stream.Flush();
            //stream.Close();
            //client.Dispose();


            string temperature = data.current.temperature;
            string feelsLike = data.current.feelslike;
            string wind_speed = data.current.wind_speed;
            string humidity = data.current.humidity;

            string country = data.location.country;
            string localTime = data.location.localtime;
            string utcOffset = data.location.utc_offset;


            label8.Text = areaType;
            label9.Text = query;
            label12.Text = unit;
            label17.Text = description;

            textBox1.Text = temperature;
            textBox2.Text = feelsLike;
            textBox3.Text = wind_speed;
            textBox4.Text = humidity;

            textBox5.Text = country;
            textBox6.Text = localTime;
            textBox7.Text = utcOffset;

          

          
            //WebClient client = new WebClient();

            //byte[] image = client.DownloadData("http:" + iconUri);
            //MemoryStream stream = new MemoryStream(image);

            //Bitmap newBitMap = new Bitmap(stream);
            //Bitmap icon = newBitMap;
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
