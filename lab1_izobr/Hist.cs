using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_izobr
{
    public partial class Hist : Form
    {
        int[] items;
        public Hist(int[] chartItems)
        {
            InitializeComponent();
            this.items = chartItems;
            //this.label1.Text = trackBar1.Value.ToString();
            DefineChart(1);
        }

        private void DefineChart(int step)
        {
            int[] seriesArray = new int[items.Length / step];
            for (int i = 0; i < seriesArray.Length; i++)
                for (int j = 0; j < step; j++)
                    seriesArray[i] = items[i * step + j];


            chart1.Series[0].Points.DataBindY(seriesArray);
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //this.label1.Text = trackBar1.Value.ToString();
            //DefineChart(trackBar1.Value);
        }

        private void Hist_Load_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}

