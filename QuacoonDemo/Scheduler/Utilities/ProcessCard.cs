using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Imaging.Textures;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Data;
using Accord.Math.Wavelets;
using Accord.Statistics.Kernels;

namespace Quacoon.Utilities
{
    public static class ProcessCard
    {
        private static System.Drawing.Bitmap filteredImage;
        private static System.Drawing.Bitmap sourceImage;

        public static System.Drawing.Bitmap GenerateBitmap(string fileName)
        {
            sourceImage = (Bitmap)Bitmap.FromFile(fileName);

            if ((sourceImage.PixelFormat == PixelFormat.Format16bppGrayScale) ||
                        (Bitmap.GetPixelFormatSize(sourceImage.PixelFormat) > 32))
            {
                SweetAlert.Controllers.SweetController sc = new SweetAlert.Controllers.SweetController();

                sourceImage.Dispose();
                sourceImage = null;

            }
            else
            {
                // make sure the image has 24 bpp format
                if (sourceImage.PixelFormat != PixelFormat.Format24bppRgb)
                {
                    Bitmap temp = Accord.Imaging.Image.Clone(sourceImage, PixelFormat.Format24bppRgb);
                    sourceImage.Dispose();
                    sourceImage = temp;
                }
            }
            return sourceImage;
        }

        public static System.Drawing.Bitmap ApplyEdgeDetection(string fileName)
        {
            Bitmap interImage = GenerateBitmap(fileName);

            Bitmap origImage = Grayscale.CommonAlgorithms.RMY.Apply(interImage);
            DifferenceEdgeDetector edgeDetector = new DifferenceEdgeDetector();
            Bitmap finalImage = edgeDetector.Apply(origImage);
            return finalImage;
        }

        public static System.Drawing.Bitmap ApplyInvert(string fileName)
         {
            Bitmap interImage = GenerateBitmap(fileName);

            Invert invert = new Invert();
            Bitmap finalImage = invert.Apply(interImage);
            return finalImage;
        }

        public static System.Drawing.Bitmap ApplyStainDetection(string fileName)
        {
            Bitmap interImage = GenerateBitmap(fileName);

            Sharpen oofdetector = new Sharpen();
            Bitmap finalImage = oofdetector.Apply(interImage);
            return finalImage;
        }

        public static System.Drawing.Bitmap OutOfFocusDetector(string fileName)
        {
            Bitmap interImage = GenerateBitmap(fileName);

            ColorFiltering staindetector = new ColorFiltering(new IntRange(25, 230), new IntRange(25, 230), new IntRange(25, 230));
            Bitmap finalImage = staindetector.Apply(interImage);
            return finalImage;
        }

        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        public static System.Drawing.Bitmap CornerDetector(string fileName)
        {
            Bitmap interImage = GenerateBitmap(fileName);
            Bitmap origImage = Grayscale.CommonAlgorithms.Y.Apply(interImage);

            float threshold = (float)0.000200;
            int octaves = (int)5;
            int initial = (int)2;

            // Create a new SURF Features Detector using the given parameters
            SpeededUpRobustFeaturesDetector surf =
                new SpeededUpRobustFeaturesDetector(threshold, octaves, initial);

            IEnumerable<SpeededUpRobustFeaturePoint> points = surf.Transform(origImage);

            // Create a new AForge's Corner Marker Filter
            FeaturesMarker features = new FeaturesMarker(points);

            // Apply the filter and display it on a picturebox
            return features.Apply(origImage);
        }

        public static System.Drawing.Bitmap ApplyWaveletTransform(string fileName)
        {
            Bitmap interImage = GenerateBitmap(fileName);           
            Bitmap origImage = Grayscale.CommonAlgorithms.RMY.Apply(interImage);
            Bitmap biggerImage = Accord.Imaging.Image.Convert8bppTo16bpp(origImage);
            biggerImage = ResizeBitmap(biggerImage, (1024), (1024));

            Accord.Math.Wavelets.Haar wavelet = new Haar(1);
            // IWavelet wavelet = new CDF97(5);

            // Create forward transform
            WaveletTransform wt = new WaveletTransform(wavelet);

            // Apply forward transform
            Bitmap transformed = wt.Apply(biggerImage);
            return transformed;
        }


    }
}