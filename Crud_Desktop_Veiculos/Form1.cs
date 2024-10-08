﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Desktop_Veiculos
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
                 InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GUSPC;Initial Catalog=Crud_Desktop_Veiculos;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ut values(@id,@marca,@modelo,@ano,@placa,@cor)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@marca", textBox2.Text);
            cmd.Parameters.AddWithValue("@modelo", textBox3.Text);
            cmd.Parameters.AddWithValue("@placa", textBox4.Text);
            cmd.Parameters.AddWithValue("@ano", int.Parse (textBox5.Text));
            cmd.Parameters.AddWithValue("@cor", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Veículo salvo com sucesso!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GUSPC;Initial Catalog=Crud_Desktop_Veiculos;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update ut set marca=@marca, modelo=@modelo, placa=@placa, ano=@ano, cor=@cor where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@marca", textBox2.Text);
            cmd.Parameters.AddWithValue("@modelo", textBox3.Text);
            cmd.Parameters.AddWithValue("@placa", textBox4.Text);
            cmd.Parameters.AddWithValue("@ano", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@cor", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Veículo atualizado com sucesso!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GUSPC;Initial Catalog=Crud_Desktop_Veiculos;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Veículo deletado com sucesso!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GUSPC;Initial Catalog=Crud_Desktop_Veiculos;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
