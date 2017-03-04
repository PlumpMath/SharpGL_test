using System.Windows;
using SharpGL;
using System;

namespace OpenGL_test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
           
        }
        public float R;
        public float G;
        public float B;
        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(0,0,0,0);

        }
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(R,G,B,0);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            int i = 0;
            int N = 10000;
            float t = 0.0f;
            float t_step = 0.05f;
            double A = 1.0;
            double b = 0.5;
            double x, y;

            gl.Color(0.0, 0.0, 1.0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (i = 0; i < N; i++)
            {
                x = A * Math.Sin(t);
                y = A * Math.Sin(t) * Math.Sin(0.44 * t) + b * Math.Cos(t) * Math.Cos(t);
                gl.Vertex(x, y);
                t += t_step;
            }
            gl.End();
            gl.Flush();



        }
        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            R = Convert.ToSingle(slider.Value / 255);
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            G = Convert.ToSingle(slider1.Value / 255);
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            B = Convert.ToSingle(slider2.Value / 255);
        }
    }


    }

