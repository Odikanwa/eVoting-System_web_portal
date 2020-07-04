using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using DPFP;
using DPFP.Capture;


namespace eVoting
{
    /// <summary>
    /// Interaction logic for FingerReg.xaml
    /// </summary>
    public partial class FingerReg : Window, DPFP.Capture.EventHandler
    {
        //Global Variables
        Bitmap img = null;
        int CaptureTimes = 4;
        byte[] ByteFingerPrintData = null;
        Capture Capture = new Capture();    // Create a capture operation.
        SampleConversion SampleConversion = new SampleConversion();// Create a sample onversion
        Sample Sample = new Sample(); //Creates a new sample
        DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        

        public FingerReg()
        {
            InitializeComponent();

            //disable the enroll button
            enroll.IsEnabled = false;
        }

        public void SetStatus(string Status)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                textBlock.Text += Status;
            }));
 
        }

        protected virtual void Init()
        {
            try
            {
               
                if (null != Capture)
                {
                    Capture.StartCapture();
                    Capture.EventHandler = this;

                    //for checking the quality fthe image captured
                    Enroller = new DPFP.Processing.Enrollment();

                    //Clear this block
                    textBlock.Text = " ";
                    SetStatus("Capture operation, Initiated....");
                }
                // Subscribe for capturing events.
                else
                {
                    SetStatus("Can't initiate capture operation!");
                }

              
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!");
            }
        }
        
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            SampleConversion.ConvertToPicture(Sample, ref img);

            Dispatcher.BeginInvoke(new Action(() =>
            {
                PictureBox.Source = BitmapToImageSource(img);
                // fit the image into the picture box
                --CaptureTimes;
                textBlock_status.Text = "Finger Print Sample Captured! Repeat for " + CaptureTimes.ToString() + " more time(s)" ;
            }));

            //Enroll Created finger Print
            EnrollFingerFeatureSet(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            SetStatus("Finger Removed from the FingerPrin Scanner");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            SetStatus("Finger Placed on the FingerPrint Scanner");
           
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetStatus("FingerPrint Scanner Connected and Recognized, ready to Scan");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetStatus("FingerPrint Scanner Disconnected");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == CaptureFeedback.Good)
            {
                SetStatus("The Quality of the Fingerprint Sample is Good.");
            }
            else
            {
                SetStatus("The Quality of the Fingerprint Sample is Poor.");
            }
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        protected FeatureSet ExtractFeatures(Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            CaptureFeedback feedback = CaptureFeedback.None;
            FeatureSet features = new FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        private void EnrollFingerFeatureSet(Sample Sample)
        {
            //create enrollment instance
            FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            if(features != null)
            {
                try
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        textBlock.Text = "The Fingerprint Features Was Successfully Extracted.";
                    }));

                    Enroller.AddFeatures(features);		// Add feature set to template.
                }
                finally
                {
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing

                            CreateFinalTemplate(Enroller.Template);
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                textBlock_status.Text = Enroller.TemplateStatus.ToString() + ": Click the Enroll Button to Save";
                            }));

                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing

                            CreateFinalTemplate(null);
                            Enroller.Clear();
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                textBlock_status.Text = Enroller.TemplateStatus.ToString();
                            }));
                            break;
                    }
                }
            }
               
        }

        private void CreateFinalTemplate(Template template)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (template != null)
                {

                    MemoryStream ms = new MemoryStream();
                    template.Serialize(ms);
                    ms.Position = 0;
                    BinaryReader br = new BinaryReader(ms);
                    ByteFingerPrintData = null;
                    ByteFingerPrintData = br.ReadBytes((Int32)ms.Length);

                    //enable the enroll button
                    enroll.IsEnabled = true;


                }
                else
                {
                    MessageBox.Show("The Fingerprint template is not valid. Repeat Fingerprint Enrollment.");
                }
            }));
        }

        private void Button_Capture_Click(object sender, RoutedEventArgs e)
        {
            //call the init function to start operations
            Init();
        }

        private void Stop_capture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Capture.StopCapture();
                img = null;
                CaptureTimes = 0;


                Dispatcher.BeginInvoke(new Action(() =>
                {
                    textBlock.Text = ("Capture Stoped!");
                }));
            }
            catch
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    textBlock.Text = ("Capture Cannot be stopped!");
                }));
            }
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            VoterReg.fingerPrintTemplate = ByteFingerPrintData;
            MessageBox.Show("Finger Print Captured and Saved!");
        }

       

    }
}
