﻿using System;
using Grafine.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafine
{
    public partial class Katalogo_koregavimas : Form
    {
        public Katalogo_koregavimas()
        {
            InitializeComponent();
        }

        private void Modify_Button_Click(object sender, EventArgs e)
        {
            string mark = textBoxMark.Text;
            string type = textBoxType.Text;
            int year = Int32.Parse(textBoxYear.Text);
            string maker = textBoxMaker.Text;
            int price = Int32.Parse(textBoxPrice.Text);
            int amount = Int32.Parse(textBoxAmount.Text);
            string code = textBoxCode.Text;
            int counter = 0;

            MySqlDataReader outputStreamParts = Database.Select($"SELECT * FROM dalysadmin.dalys WHERE vidKo ='{code}';");
            while (outputStreamParts.Read())
            {
                counter++;
                Console.WriteLine(outputStreamParts["id"] + " " + outputStreamParts["marke"] + " " + outputStreamParts["vidKo"]);
            }
            if(counter != 1)
            {
                popup newForm = new popup("Dalis nerasta.");
                newForm.ShowDialog();
            }
            else
            {
                Database.Update($"UPDATE dalysadmin.dalys SET marke ='{mark}', tipas ='{type}', gamybos_metai ='{year}', gamintojas ='{maker}', kaina ='{price}' WHERE vidKo ='{code}';");
                Database.Close();
                popup newForm = new popup("Dalis rasta ir koreguota.");
                newForm.ShowDialog();
            }
            Database.Close();
        }
    }
}
