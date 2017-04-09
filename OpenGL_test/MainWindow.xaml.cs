using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;

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
            OpenGL gl = GLcontrol.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(45, (float)GLcontrol.Width / (float)GLcontrol.Height, 0.1, 200);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);


        }
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
                
                var Gl = args.OpenGL;
                IntPtr a_prt = Gl.NewQuadric();
                Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                Gl.ClearColor(R, G, B, 0);
                Gl.QuadricDrawStyle(a_prt, OpenGL.GLU_FILL);
                Gl.MatrixMode(OpenGL.GL_MODELVIEW);
                Gl.LoadIdentity();
                Gl.PushMatrix();
                Gl.Translate(0, 0, -6);
                Gl.Rotate(45, 1, 1, 0);
                Gl.Color(0, 1, 0);
                Gl.Sphere(a_prt, 2,32,32);
                Gl.PopMatrix();
                Gl.End();
                Gl.Flush();
            


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

