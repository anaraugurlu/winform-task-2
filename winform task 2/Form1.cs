using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void Savebtn_Click(object sender, EventArgs e)
        {
            Human human = new Human();
            human.Name = textBox1.Text;
            human.Surname = textBox2.Text;
            human.Email = textBox4.Text;
            human.BirthDate = dateTimePicker1.Text;

            List<Human> humans = new List<Human>
            {
                new Human
                {
                    Email ="ZeynebHesenova@gmail.com",
                    Name="zeyneb",
                    Surname ="hesenova",
                    PhoneNumber ="12312323535",

                },

                new Human
                {
Name ="fuad",
Surname ="ugurlu",
Email ="fuad123@gmail.com",
PhoneNumber ="+12235256"
                },
                new Human
                {
                    Name ="nezrin",
                    Surname ="rehimli",
                    Email="nezrin123@gmail.com",
                    PhoneNumber ="+9941312334"
                }



        };
            humans.Add(human);
            
            
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("humans.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, humans);
                }
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            Human[] humans = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("humans.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    humans = serializer.Deserialize<Human[]>(jr);
                }
                foreach (var item in humans)
                {
                    anket.Items.Add(item); 
                }
                Human human = new Human();
                human.Name = textBox1.Text;
                human.Surname = textBox2.Text;
                human.Email = textBox4.Text;
                human.BirthDate = dateTimePicker1.Text;
                anket.Items.Add(human);
            }
        }
    }
}
