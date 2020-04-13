using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Speech.Recognition;

namespace SpeechRecognitionBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string LeftDirection = "left";
        public const string RightDirection = "right";
        public const string UpDirection = "up";
        public const string DownDirection = "down";
        private static string direction = DownDirection;
        private static int speed = 1;

        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += Loop;
            StartSpeechRecognition();
        }

        private void StartSpeechRecognition()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Choices choices = new Choices(new string[] { LeftDirection, RightDirection, UpDirection, DownDirection });
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += RecognizedSpeech;
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void RecognizedSpeech(object sender, SpeechRecognizedEventArgs e)
        {
            direction = e.Result.Text;
        }

        private void Loop(object sender, EventArgs e)
        {
            MoveBall(direction);
        }

        private void MoveBall(string direction)
        {
            var ballTop = Canvas.GetTop(Ball);
            var ballLeft = Canvas.GetLeft(Ball);
            
            if (direction == LeftDirection)
            {
                Canvas.SetLeft(Ball, ballLeft - speed);
            }
            else if (direction == RightDirection)
            {
                Canvas.SetLeft(Ball, ballLeft + speed);
            }
            else if (direction == UpDirection)
            {
                Canvas.SetTop(Ball, ballTop - speed);
            }
            else if (direction == DownDirection)
            {
                Canvas.SetTop(Ball, ballTop + speed);
            }
        }
    }
}
