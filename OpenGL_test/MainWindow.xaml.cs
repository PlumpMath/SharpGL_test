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
        public bool p_flag;
        public bool clock;

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
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, new float[] { 3.0f, 40f, -58f, 3.3f });
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_SPOT_CUTOFF, 180.0f);
            



        }
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

            OpenGL gl = GLcontrol.OpenGL;
            
            IntPtr quad = gl.NewQuadric();

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            if (p_flag == true)
            {
                gl.LookAt(e_x, e_y, e_z, c_x, c_y, c_z, u_x, u_y, u_z);
            }
            if (rot_flag == true)
                
            {

                if (clock == true)
                {
                    gl.Rotate(rotation, 0.0f, 0.0f, 1.0f);
                }
                else
                {
                    gl.Rotate(rotation, 1.0f, 1.0f, 1.0f);
                }
            }

            gl.Translate(0.0f, 0.0f, 0.0f);
            if (kb.IsChecked == true||Z_o.IsChecked==true)
            {
                gl.Scale(40.3, 40.3, 40.3);
            }
            gl.Scale(0.3, 0.3, 0.3);
            gl.PushMatrix();
            gl.Color(1.0f, 1.0f, 0.0f);
            if (zil.IsChecked == true)
            {
                gl.Cylinder(quad, 50, 30, 30, 20, 20);
                clock = false;
                
            }
            if (sf.IsChecked == true)
            {
                gl.Sphere(quad, 50, 100, 100);
                clock = false;
            }
            if (ds.IsChecked == true)
            {
                gl.Disk(quad, 40, 50, 50, 50);
                clock = false;

            }
            if(ds_m.IsChecked==true)
            {
                gl.PartialDisk(quad, 40, 50, 50, 50, 50, 50);
                clock = false;
            }
            if(tp.IsChecked==true)
            {    
                Teapot tp = new Teapot();
                tp.Draw(gl, 50, 51, OpenGL.GL_FILL);
                clock = false;

            }
            if(kb.IsChecked==true)
            {
                Cube cube = new Cube();
                cube.Render(gl, RenderMode.Render);
                clock = false;
            }
            if(Z_o.IsChecked==true)
            {
                clock = false;
                int i, N = 20;
                float angleStep = 360.0f / N;
                float angleCurrent = 0f;
                float Radius1 = 1.0f;
                for (i = 0; i < N; i++)
                {
                    angleCurrent = i * angleStep * 3.14f / 180;
                    gl.PushMatrix();
                    gl.Translate(Radius1 * Math.Sin(angleCurrent), 0, Radius1 * Math.Cos(angleCurrent));
                    gl.Sphere(quad,0.3, 24, 24);
                    gl.PopMatrix();
                }

            }
            if(S_S.IsChecked==true)
            {
                clock = false;
                //рисуем солнце
                gl.Color(1.0, 1.0, 0.0);
                gl.Sphere(quad, 30, 50, 50);
                gl.Translate(60, 0, 0);
                // Рисуем планету
                gl.Color(0.0, 1.0, 0.0);
                gl.Sphere(quad, 10, 50, 50);
                gl.PopMatrix();
                gl.Flush();
            }
            if(O_O.IsChecked==true)
            {
                clock = false;
                gl.Color(0.7, 0.1, 0.0);
                gl.Sphere(quad, 30, 40, 40);
                gl.Translate(0, 0, 0);
                gl.Color(0.1, 0.3, 0.9);
                int i, N = 20;
                float angleStep = 360.0f / N;
                float angleCurrent = 0f;
                float Radius1 = 45.0f;
                for (i = 0; i < N; i++)
                {
                    angleCurrent = i * angleStep * 3.14f / 180;
                    gl.PushMatrix();
                    gl.Translate(Radius1 * Math.Sin(angleCurrent), 0, Radius1 * Math.Cos(angleCurrent));
                    gl.Sphere(quad, 9.9, 40, 40);
                    gl.PopMatrix();
                }
                gl.LookAt(1.1, 1.1, 1.5, 1.1, 1.1, 5.7, 1.1, 0, 0);
                for (i = 0; i < N; i++)
                {
                    angleCurrent = i * angleStep * 3.14f / 180;
                    gl.PushMatrix();
                    gl.Translate(Radius1 * Math.Sin(angleCurrent), 0, Radius1 * Math.Cos(angleCurrent));
                    gl.Sphere(quad, 9.9, 40, 40);
                    gl.PopMatrix();
                }


            }
            if(O_k.IsChecked==true)
            {
                clock = false;
                gl.LineWidth(2.5f);
                gl.Scale(50.3, 50.3, 50.3);
                gl.Begin(OpenGL.GL_LINES);
                
                gl.Color(1.0, 0.0, 0.0);
                gl.Vertex(-1, -1, 0); //х
                gl.Vertex(1, -1, 0);

                gl.Vertex(-1, 1, 0); //у
                gl.Vertex(-1, -1, 0);

                gl.Vertex(-1, -1, 0);//z
                gl.Vertex(-1, -1, 2);
                
                
                gl.End();
            }
            if(kv.IsChecked==true)
            {
                clock = false;
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                gl.LoadIdentity();
                gl.PushMatrix();
                gl.Rotate(rotation, 0.0, 0.0, 1.0);
                gl.Color(1.0, 1.0, 1.0);
                gl.Rect(-20.0, -20.0, 20.0, 20.0);
                gl.PopMatrix();



            }
            if(asd.IsChecked==true)
            {
                clock = false;
                gl.LineWidth(3.5f);
                gl.Scale(20.3, 20.3, 20.3);
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT |OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.Rotate(rotation, 0.0, 0.0, 1.0);
                gl.Color(1.0, 0.0, 0.0);
                gl.Vertex(0, 0);
                gl.Vertex(0, 3);
                gl.Vertex(2, 2);
                gl.Vertex(4, 3);
                gl.Vertex(4, 0);
                gl.Vertex(3, 0);
                gl.Vertex(3, 1);
                gl.Vertex(1, 1);
                gl.Vertex(1, 0);
                gl.Vertex(0, 0);
                gl.End();
            }
            if(cl.IsChecked==true)
            {
                clock = false;
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                gl.LoadIdentity();
                gl.PushMatrix();
                gl.Rotate(rotation, 0.0, 0.0, 1.0);
                gl.Color(1.0, 1.0, 1.0);
                gl.Rect(-0.91, -20.9, 1.0, 1.0);
                gl.PopMatrix();
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);

                for (int i = 0; i < 100; i++)
                {
                    double a = (float)i / 25.0f * 3.1415f * 2.0f;
                    gl.Vertex(Math.Cos(a) * 28.0f, Math.Sin(a) * 28.0f);
                }
                gl.End();
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(-21, 0);
                gl.Vertex(-25, 0);
                gl.Vertex(-21, 3);
                gl.Vertex(-25, 6);
                gl.Vertex(-21, 6);
                gl.End();
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(25, 0);
                gl.Vertex(21, 0);
                gl.Vertex(21, 3);
                gl.Vertex(25, 3);
                gl.Vertex(25, 6);
                gl.Vertex(21, 6);
                gl.Vertex(21, 3);

                gl.End();




            }
            gl.PopMatrix();
            rotation += Convert.ToSingle(sl.Value);


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
                    p_flag = true;
                }
            }
            else
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            

        }
    }


}

