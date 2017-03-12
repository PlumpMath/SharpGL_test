using System.Windows;
using SharpGL;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



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
        
        public float f;
        public int vertex;
        public float a = 0;
        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(0,0,0,0);

        }
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            int i = 0;
            int N = 1600;
            float t = -2.512f;
            float t_step = 0.00314f;
            double A = 0.5;
            double x, y;

           
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (i = 0; i < N; i++)
            {
                x = Math.Sin(Math.Pow(t, 3))*Math.Sin(Math.Pow(t,3));
                y = A*(Math.Cos(Math.Pow(t,4))*Math.Cos(Math.Pow(t,4)));
                gl.Color(0.6f, 0.9f, 0.1f);
                gl.Vertex(x, y);
                t += t_step;
            }
            gl.End();
            gl.Flush();



        }
        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            vertex = Convert.ToInt32(textBox.Text);

        }
    }


    }

