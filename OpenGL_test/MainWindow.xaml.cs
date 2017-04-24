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
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;
using System.Text.RegularExpressions;



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
        private float rotation = 0.0f;
        public float e_x, e_y, e_z, c_x, c_y, c_z, u_x, u_y, u_z;

        private void rot_c_Unchecked(object sender, RoutedEventArgs e)
        {
            rot_flag = false;
        }

        public bool rot_flag;

        private void rot_c_Checked(object sender, RoutedEventArgs e)
        {
            rot_flag = true;
        }



        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = GLcontrol.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, new float[] { 3.0f, 40f, -30f, 3.3f });
            //gl.Enable(OpenGL.GL_LIGHT1);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_SPOT_CUTOFF, 180.0f);
            



        }
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

            OpenGL gl = GLcontrol.OpenGL;
            
            IntPtr quad = gl.NewQuadric();

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.LookAt(e_x, e_y, e_z, c_x, c_y, c_z, u_x, u_y, u_z);
            if (rot_flag == true)
            {
                gl.Rotate(rotation, 1.0f, 1.0f, 1.0f);
            }
            gl.Translate(0.0f, 0.0f, 0.0f);
            if (kb.IsChecked == true)
            {
                gl.Scale(40.3, 40.3, 40.3);
            }
            gl.Scale(0.3, 0.3, 0.3);
            gl.PushMatrix();
            gl.Color(1.0f, 1.0f, 0.0f);
            if (zil.IsChecked == true)
            {
                gl.Cylinder(quad, 50, 20, 20, 10, 10);
                
            }
            if (sf.IsChecked == true)
            {
                gl.Sphere(quad, 50, 20, 20);
            }
            if (ds.IsChecked == true)
            {
                gl.Disk(quad, 40, 50, 50, 50);
                
            }
            if(ds_m.IsChecked==true)
            {
                gl.PartialDisk(quad, 40, 50, 50, 50, 50, 50);
            }
            if(tp.IsChecked==true)
            {    
                Teapot tp = new Teapot();
                tp.Draw(gl, 50, 51, OpenGL.GL_FILL);
              
            }
            if(kb.IsChecked==true)
            {
                Cube cube = new Cube();
                cube.Render(gl, RenderMode.Render);
            }
            

            gl.PopMatrix();
            rotation += 5.0f;


        }
        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
         
            OpenGL gl = GLcontrol.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, (int)Width, (int)Height);
            gl.Ortho(5, 5, 5, -1,1,1);
            gl.Perspective(90.0f, (double)Width / (double)Height, 1, 200.0);
            gl.LookAt(0, -1, -30, 0, 0, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex X = new Regex(@"^[+-]?\d*(\,\d+)?$");
            if (X.IsMatch(e_x_text.Text) || X.IsMatch(e_y_text.Text) || X.IsMatch(e_z_text.Text) || X.IsMatch(c_x_text.Text) ||
                X.IsMatch(c_y_text.Text) || X.IsMatch(c_z_text.Text) || X.IsMatch(u_x_text.Text) || X.IsMatch(u_y_text.Text) || X.IsMatch(u_z_text.Text))
            { if (e_x_text.Text == "" || e_y_text.Text == "" || e_z_text.Text == "" || c_x_text.Text == "" || c_y_text.Text == "" || c_y_text.Text == "" ||
                  u_x_text.Text == "" || u_y_text.Text == "" || u_z_text.Text == "")
                {
                    MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    OpenGL gl = GLcontrol.OpenGL;
                    e_x = Convert.ToSingle(e_x_text.Text);
                    e_y = Convert.ToSingle(e_y_text.Text);
                    e_z = Convert.ToSingle(e_z_text.Text);
                    c_x = Convert.ToSingle(c_x_text.Text);
                    c_y = Convert.ToSingle(c_y_text.Text);
                    c_z = Convert.ToSingle(c_z_text.Text);
                    u_x = Convert.ToSingle(u_x_text.Text);
                    u_y = Convert.ToSingle(u_y_text.Text);
                    u_z = Convert.ToSingle(u_z_text.Text);
                }
            }
            else
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            

        }
    }


}

