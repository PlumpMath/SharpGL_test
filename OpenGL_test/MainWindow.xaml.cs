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
            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.Color(1f, 0f, 0f);
            gl.Vertex(0.0f, 0.5f);
            gl.Vertex(-0.5f, -0.5f);
            gl.Vertex(0.5f, -0.5f);
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

