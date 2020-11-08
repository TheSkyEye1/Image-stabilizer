using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.ImgHash;
using Emgu.CV.Features2D;
using Emgu.CV.Stitching;

namespace lab7
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> sourceImage;
        Image<Bgr, byte> twistedImage;
        Filter_c fil = new Filter_c();
        int detmode = 0;
        MKeyPoint[] mkpoints;

        public Form1()
        {
            InitializeComponent();
            IMG3.Visible = false;
        }

        private void load_Click(object sender, EventArgs e)
        {
            IMG3.Visible = false;
            sourceImage = fil.loadfunction(sourceImage);
            if (sourceImage != null)
            {
                IMG1.Image = sourceImage;
            }
        }

        private void dotsb_Click(object sender, EventArgs e)
        {
            IMG3.Visible = false;
            mkpoints = fil.Maspointer(sourceImage, detmode);
            IMG1.Image = fil.Drawer(sourceImage, mkpoints);
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            detmode = 0;
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            detmode = 1;
        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            detmode = 2;
        }

        private void load2_Click(object sender, EventArgs e)
        {
            IMG3.Visible = false;
            twistedImage = fil.loadfunction(sourceImage);
            if (twistedImage != null)
            {
                IMG2.Image = twistedImage;
            }
        }

        private void function1_Click(object sender, EventArgs e)
        {
            IMG3.Visible = false;
            mkpoints = fil.Maspointer(sourceImage, detmode);
            IMG1.Image = fil.Drawer(sourceImage, mkpoints);
            IMG2.Image = fil.PDrawer(fil.FPoints(mkpoints, sourceImage, twistedImage), twistedImage);
        }

        private void homob_Click(object sender, EventArgs e)
        {
            IMG3.Visible = false;
            IMG2.Image = fil.Homographica(sourceImage, twistedImage, detmode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IMG3.Visible = true;
            IMG3.Image = fil.PointComp(sourceImage,twistedImage);
        }

        private void comph_Click(object sender, EventArgs e)
        {
            IMG3.Visible = false;
            IMG2.Image = fil.PointHomo(sourceImage, twistedImage);
        }
    }
}
