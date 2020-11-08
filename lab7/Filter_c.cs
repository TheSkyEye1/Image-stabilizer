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


namespace lab7
{
    class Filter_c
    {
        public Image<Bgr, byte> loadfunction(Image<Bgr, byte> image)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;*.png";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                image = new Image<Bgr, byte>(fileName).Resize(640, 480, Inter.Linear);
            }
            return image;
        }

        public MKeyPoint[] Maspointer(Image<Bgr, byte> image, int mode)
        {
            switch (mode)
            {
                case 0:
                    {
                        GFTTDetector detector = new GFTTDetector(40, 0.01, 5, 3, true);
                        MKeyPoint[] GFP1 = detector.Detect(image.Convert<Gray, byte>().Mat);
                        return GFP1;
                    }
                case 1:
                    {
                        Brisk detector = new Brisk();
                        MKeyPoint[] GFP1 = detector.Detect(image.Convert<Gray, byte>().Mat);
                        return GFP1;
                    }
                case 2:
                    {
                        FastFeatureDetector detector = new FastFeatureDetector();
                        MKeyPoint[] GFP1 = detector.Detect(image.Convert<Gray, byte>().Mat);
                        return GFP1;
                    }
            }
            return null;
        }
        public Image<Bgr, byte> Drawer(Image<Bgr, byte> image, MKeyPoint[] points)
        {
            Image<Bgr, byte> output = image.Copy();
            foreach (MKeyPoint p in points)
            {
                CvInvoke.Circle(output, Point.Round(p.Point), 3, new Bgr(Color.Blue).MCvScalar, 2);
            }
            return output;
        }

        public PointF[] FPoints(MKeyPoint[] GFP1, Image<Bgr, byte> image1, Image<Bgr, byte> image2)
        {
            PointF[] srcPoints = new PointF[GFP1.Length];
            for (int i = 0; i < GFP1.Length; i++)
                srcPoints[i] = GFP1[i].Point;

            PointF[] destPoints;
            byte[] status;
            float[] trackErrors;

            CvInvoke.CalcOpticalFlowPyrLK(image1.Convert<Gray, byte>().Mat,
                image2.Convert<Gray, byte>().Mat,
                srcPoints,
                new Size(20, 20),
                5,
                new MCvTermCriteria(20, 1),
                out destPoints,
                out status,
                out trackErrors
                );

            return destPoints;
        }

        public Image<Bgr, byte> PDrawer(PointF[] points, Image<Bgr, byte> image)
        {
            Image<Bgr, byte> output = image.Copy();

            foreach (PointF p in points)
            {
                CvInvoke.Circle(output, Point.Round(p), 3, new Bgr(Color.Blue).MCvScalar, 2);
            }

            return output;
        }

        public Image<Bgr, byte> Homographica(Image<Bgr, byte> image, Image<Bgr, byte> image2, int mode)
        {
            var mkpoints = Maspointer(image, mode);
            PointF[] srcPoints = new PointF[mkpoints.Length];
            for (int i = 0; i < mkpoints.Length; i++)
                srcPoints[i] = mkpoints[i].Point;
            Mat homographyMatrix = CvInvoke.FindHomography(FPoints(mkpoints, image, image2), srcPoints, RobustEstimationAlgorithm.LMEDS);
            var destImage = new Image<Bgr, byte>(image2.Size);
            CvInvoke.WarpPerspective(image2, destImage, homographyMatrix, destImage.Size);
            return destImage;
        }

        public Image<Bgr, byte> PointComp(Image<Bgr, byte> image, Image<Bgr, byte> image2)
        {
            Image<Gray, byte> baseImgGray = image.Convert<Gray, byte>();
            Image<Gray, byte> twistedImgGray = image2.Convert<Gray, byte>();
            Brisk descriptor = new Brisk();
            GFTTDetector detector = new GFTTDetector(40, 0.01, 5, 3, true);
            VectorOfKeyPoint GFP1 = new VectorOfKeyPoint();
            UMat baseDesc = new UMat();
            UMat bimg = twistedImgGray.Mat.GetUMat(AccessType.Read);
            VectorOfKeyPoint GFP2 = new VectorOfKeyPoint();
            UMat twistedDesc = new UMat();
            UMat timg = baseImgGray.Mat.GetUMat(AccessType.Read);
            detector.DetectRaw(bimg, GFP1);
            descriptor.Compute(bimg, GFP1, baseDesc);
            detector.DetectRaw(timg, GFP2);
            descriptor.Compute(timg, GFP2, twistedDesc);
            BFMatcher matcher = new BFMatcher(DistanceType.L2);
            VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();
            matcher.Add(baseDesc);
            matcher.KnnMatch(twistedDesc, matches, 2, null);
            Mat mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(255));
            Features2DToolbox.VoteForUniqueness(matches, 0.8, mask);
            int nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(GFP1, GFP1, matches, mask, 1.5, 20);
            Image<Bgr, byte> res = image.CopyBlank();
            Features2DToolbox.DrawMatches(image2, GFP1, image, GFP2, matches, res, new MCvScalar(255, 0, 0), new MCvScalar(255, 0, 0), mask);
            return res;
        }

        public Image<Bgr, byte> PointHomo(Image<Bgr, byte> image, Image<Bgr, byte> image2)
        {
            Image<Gray, byte> baseImgGray = image.Convert<Gray, byte>();
            Image<Gray, byte> twistedImgGray = image2.Convert<Gray, byte>();
            Brisk descriptor = new Brisk();
            GFTTDetector detector = new GFTTDetector(40, 0.01, 5, 3, true);
            VectorOfKeyPoint GFP1 = new VectorOfKeyPoint();
            UMat baseDesc = new UMat();
            UMat bimg = twistedImgGray.Mat.GetUMat(AccessType.Read);
            VectorOfKeyPoint GFP2 = new VectorOfKeyPoint();
            UMat twistedDesc = new UMat();
            UMat timg = baseImgGray.Mat.GetUMat(AccessType.Read);
            detector.DetectRaw(bimg, GFP1);
            descriptor.Compute(bimg, GFP1, baseDesc);
            detector.DetectRaw(timg, GFP2);
            descriptor.Compute(timg, GFP2, twistedDesc);
            BFMatcher matcher = new BFMatcher(DistanceType.L2);
            VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();
            matcher.Add(baseDesc);
            matcher.KnnMatch(twistedDesc, matches, 2, null);
            Mat mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(255));
            Features2DToolbox.VoteForUniqueness(matches, 0.8, mask);
            int nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(GFP1, GFP1, matches, mask, 1.5, 20);
            Image<Bgr, byte> res = image.CopyBlank();
            Features2DToolbox.DrawMatches(image2, GFP1, image, GFP2, matches, res, new MCvScalar(255, 0, 0), new MCvScalar(255, 0, 0), mask);

            Mat homography;
            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(GFP1, GFP2, matches, mask, 2);
            var destImage = new Image<Bgr, byte>(image2.Size);
            CvInvoke.WarpPerspective(image2, destImage, homography, destImage.Size);

            return destImage;
        }
    }
}
    