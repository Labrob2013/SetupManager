using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Setup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // https://habrahabr.ru/sandbox/44238/
            string path_file_load = AppDomain.CurrentDomain.BaseDirectory + "/setup.xml";

            if (!File.Exists(path_file_load))
            {
                XmlTextWriter textWritter = new XmlTextWriter(path_file_load, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("head");
                textWritter.WriteEndElement();
                textWritter.Close();
            }

            XmlDocument document = new XmlDocument();

            document.Load(path_file_load);
            XmlNode element = document.CreateElement("element");
            document.DocumentElement.AppendChild(element);
            XmlAttribute attribute = document.CreateAttribute("number");
            attribute.Value = "1";
            element.Attributes.Append(attribute);

            XmlNode subElement1 = document.CreateElement("subElement1");
            subElement1.InnerText = "Hello";
            element.AppendChild(subElement1);

            XmlNode subElement2 = document.CreateElement("subElement2");
            subElement2.InnerText = "Dear";
            element.AppendChild(subElement2);

            XmlNode subElement3 = document.CreateElement("subElement3");
            subElement3.InnerText = "Habr";
            element.AppendChild(subElement3);

            document.Save(path_file_load);
        }
    }
}
