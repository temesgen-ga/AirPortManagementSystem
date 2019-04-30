﻿using ClassLibrary1;
using DAL4;
using System;
using System.Windows.Forms;

namespace AirportMSystem
{
    public partial class IndexGeneral : Form
    {
        public IndexGeneral(Employee s)
        {
            InitializeComponent();

            if (s is Admin && s.Privilige>0) {
                dataView.DataSource = Kontrol_Et.görüntüle(s);
                securityGroup.Visible=false;
                cargoGroup.Visible = false;
                traficGroup.Visible = false;
                cargoGroup.Update();
            }
            if((s is Security || s is Staff) && s.Privilige>0)
            {
                if (s is Staff) securityGroup.Text = "Staff Menu";
                traficGroup.Visible = false;
                adminGroup.Visible = false;
                cargoGroup.Visible = false;
                cargoGroup.Update();
            }
            if (s is CargoMan && s.Privilige > 0)
            {
                if (s.Privilige > 1)
                {
                    traficGroup.Visible = false;
                    adminGroup.Visible = false;
                    securityGroup.Visible = false;
                    securityGroup.Update();
                }
                else {
                    removecargoBtn.Visible = false;
                    traficGroup.Visible = false;
                    adminGroup.Visible = false;
                    securityGroup.Visible = false;
                    securityGroup.Update();
                }
            }
            if (s is HavaKontrol && s.Privilige > 0)
            {
                if (s.Privilige > 1) { 
                securityGroup.Visible = false;
                adminGroup.Visible = false;
                cargoGroup.Visible = false;
                traficGroup.Update();}
                else
                {
                    removefligthBtn.Visible = false;
                    securityGroup.Visible = false;
                    adminGroup.Visible = false;
                    cargoGroup.Visible = false;
                    traficGroup.Update();
                }
            }
        }

        private void hostHostessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login yeni = new Login();
            yeni.Show();
            this.Hide();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            dataView.DataSource = Kontrol_Et.sorguAdmin(2,int.Parse(idTxt.Text),nameTxt.Text,emailTxt.Text,typeCBox.SelectedIndex,priviligeCBox.SelectedIndex);
            dataView.Update();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            dataView.DataSource = Kontrol_Et.sorguAdmin(1, int.Parse(idTxt.Text), nameTxt.Text, emailTxt.Text, typeCBox.SelectedIndex, priviligeCBox.SelectedIndex);
            dataView.Update();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            int x = -1;
            if (idTxt.Text!="")
                  x= int.Parse(idTxt.Text);
            dataView.DataSource = Kontrol_Et.sorguAdmin(0, x, nameTxt.Text, emailTxt.Text, typeCBox.SelectedIndex, priviligeCBox.SelectedIndex);
            dataView.Update();
        }
    }
}
