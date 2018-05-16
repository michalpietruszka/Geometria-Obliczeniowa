using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//ctr+m+o
namespace WindowsFormsApplication2
{   
    public partial class Form1 : Form
    {
        public List<Obiekt> objects = new List<Obiekt>();
        public List<Obiekt> tranf = new List<Obiekt>();//pomocnicza
        public List<Obiekt> original = new List<Obiekt>();
        
        Obiekt obiekt = null;
        public float min_sc = 1;
      
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += mouseScale;
            this.MouseHover += mouseFocus;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
        
        public class Obiekt
        {
            public string id;
            public List<PointF> points;
            public bool war;
            public Obiekt(string ident, List<PointF> array, bool wart)
            {
                id = ident;
                points = new List<PointF>(array);
                war = wart;
            }
            public List<PointF> get_points()
            { return points; }
            public string get_ident()
            { return id; }
            public bool get_bool()
            { return war; }
            public void change_id(string nowyId)
            { id = nowyId;
            }
            public void change_war(bool nowaWar)
            {
                war = nowaWar;
            }
        }

        private void IsPoint(List<Obiekt> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].points.Count == 1 && list[i].get_ident() != "Point")
                {
                    list[i].change_id("Point");
                }
            }
        }

        OpenFileDialog ofd = new OpenFileDialog();
        string path;
    //Wybór pliku
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false; ;
            listBox1.Items.Clear();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                objects.Clear();
                textBox1.Text = ofd.SafeFileName;
                path = ofd.FileName;
                objects = read(path);
                defaultscale();
                transform();
                IsPoint(objects);
                Invalidate();
                Refresh();
            }
        }
        float x, y, minX = 0, minY = 0, maxY = 0, maxX = 0;
     //Czytanie z pliku
        private List<Obiekt> read(string path)
      {
            bool bol = true;
            string line, ident = null;
            List<PointF> punkty = new List<PointF>();
          //  tranf.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            while ((line = file.ReadLine()) != null)
            {
                if (line[0] == ';' || line[0] == ':' || line[0] == 'L')
                { }
                if (line[0] == '*')
                {
                    if (ident != null)
                    {
                        obiekt = new Obiekt(ident, punkty, false);
                        tranf.Add(obiekt);
                    }
                    if (line[1] == '5')
                    { ident = "Polygon";}
                    if (line[1] == '4')
                    { ident = "Line";}
                    if (line[1] == '1')
                    { ident = "Point";}
                    punkty.Clear();
                }
                if (line[0] == 'P')
                {
                    List<string> words = line.Split(' ').ToList();
                    y = -float.Parse(words[3], CultureInfo.InvariantCulture);
                    x = float.Parse(words[5], CultureInfo.InvariantCulture);
                    
                    if (bol == true)
                    {
                        minX = x;
                        maxX = x;
                        minY = y;
                        maxY = y;
                        bol = false;
                    }
                    else
                    {
                        minX = Math.Min(x, minX);
                        maxX = Math.Max(x, maxX);
                        minY = Math.Min(y, minY);
                        maxY = Math.Max(y, maxY);
                    }    
                    PointF punkt = new PointF(x,y);
                    punkty.Add(punkt);
                }
            }
            Obiekt obiekt2 = new Obiekt(ident, punkty, false); tranf.Add(obiekt2);
            file.Close();
            System.Console.ReadLine();

            return tranf;
}
        PointF tranl;
        PointF middle;
    //Skala i tranformacja
        private void defaultscale()
        {
            PointF pmin = new PointF(minX, minY);
            PointF pmax = new PointF(maxX, maxY);
            PointF sz_src = new PointF((pmax.X - pmin.X), (pmax.Y - pmin.Y));
            float ww = (this.Width - 200) * 0.7f;
            float hh = this.Height * 0.7f;
            min_sc = Math.Min((hh / (maxY - minY)), (ww / (maxX - minX)));
            middle = new PointF((minX + sz_src.X / 2) * min_sc, (minY + sz_src.Y / 2) * min_sc);
            tranl = new PointF((((this.Width - 200) / 2) - middle.X), ((this.Height / 2) - middle.Y));
        }

        private void transform()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                int liczbpkt = objects[i].get_points().Count;
                List<PointF> punktyAktualne = objects[i].get_points();
                PointF[] pomocnicza = new PointF[liczbpkt];
                for (int j = 0; j < liczbpkt; j++)//transformacja
                {
                    pomocnicza[j] = punktyAktualne[j];

                    pomocnicza[j].X = pomocnicza[j].X * min_sc + tranl.X;
                    pomocnicza[j].Y = pomocnicza[j].Y * min_sc + tranl.Y;
                    tranf[i].points[j] = new PointF(pomocnicza[j].X, pomocnicza[j].Y);

                }
            }
        }

        private void mouseFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void ScaleObjects(float skala)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects[i].points.Count; j++)
                {
                    objects[i].points[j] = new PointF(objects[i].points[j].X * skala, objects[i].points[j].Y * skala);
                }
            }
        }

        private void mouseScale(object sender, MouseEventArgs e)
        {
            int zoom = e.Delta / 120;
            if (zoom >= 1)
            {
                ScaleObjects(1.1f);
            }
            else if (zoom <= -1)
            {
                ScaleObjects(0.9f);
            }
            Invalidate();
            Refresh();
        }

        private Point MouseDownLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    for (int j = 0; j < objects[i].points.Count; j++)
                    {
                        objects[i].points[j] = new PointF(objects[i].points[j].X + (e.X - MouseDownLocation.X) / 10, objects[i].points[j].Y + (e.Y - MouseDownLocation.Y) / 10);
                    }
                }
                Invalidate();
                Refresh();
            }
        }

    //Rysowanie
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                int liczbpkt = objects[i].get_points().Count;
                List<PointF> punktyAktualne = objects[i].get_points();
                PointF[] pomocnicza = new PointF[liczbpkt];
                for (int j = 0; j < liczbpkt; j++)//transformacja
                {
                    pomocnicza[j] = punktyAktualne[j];
                }
                if (objects[i].get_ident() == "Polygon")
                {
                    if (objects[i].points.Count > 2)
                    { e.Graphics.DrawPolygon(Pens.Green, pomocnicza); }
                    if (objects[i].points.Count == 2)
                    { e.Graphics.DrawLine(Pens.Blue, pomocnicza[0], pomocnicza[1]); }
                }
                if (objects[i].get_ident() == "Rectangle")
                {
                    e.Graphics.DrawPolygon(Pens.YellowGreen, pomocnicza); 
                }
                if (objects[i].get_ident() == "Wielokat_Pip")
                {
                    e.Graphics.DrawPolygon(Pens.Red, pomocnicza);
                }
                if (objects[i].get_ident() == "Otoczka")
                {
                    e.Graphics.DrawPolygon(Pens.Purple, pomocnicza);
                }
                if (objects[i].get_ident() == "Line")
                {
                    if (objects[i].points.Count == 2)
                    { e.Graphics.DrawLine(Pens.Blue, pomocnicza[0], pomocnicza[1]); }
                }
                if (objects[i].get_ident() == "Point")
                {   
                    if(objects[i].get_bool() == false)
                        e.Graphics.DrawRectangle(Pens.Black, pomocnicza[0].X, pomocnicza[0].Y, 0.5f, 0.5f);
                    if (objects[i].get_bool() == true)//punkty wewnatrz wielokata
                    {
                        e.Graphics.DrawRectangle(Pens.Red, pomocnicza[0].X, pomocnicza[0].Y, 1, 1);
                    }
                }
            }
        }

        public Brush aBrush { get; set; }
    //Lista obiektów
        private void AddFromCode(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            original = read(path);
            listBox1.Items.Add("Wczytano " + original.Count + " obiektów");
            for (int i = 0; i < original.Count; i++)
            {
                List<PointF> display = new List<PointF>(original[i].get_points());
                listBox1.Items.Add(objects[i].get_ident());

                int liczbapkt = original[i].get_points().Count;
                for(int j = 0; j < liczbapkt; j++)
                {
                  listBox1.Items.Add((-display[j].Y) + " " + display[j].X);
                }
            }
            original.Clear();
        }
        
        private void ukryj_ListMenu_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            listBox1.Items.Clear();
        }
    //Minimum Bounding Rectangle
        private void pokazPunkty_MBRMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(@"
            MinX {0}  
            MaxX {1} 
            MinY {2} 
            MaxY {3}", minX, maxX, minY, maxY), "Results", MessageBoxButtons.OK); 
        }
            
        float minXo, maxXo, minYo, maxYo;
        bool bol2 = false;

        private void start_MBRMenu_Click(object sender, EventArgs e)
        {
            bool bol1 = true;
            if (bol2 == false)
            {            
                bol2 = true;
                for (int i = 0; i < objects.Count(); i++)
                {
                    if (objects[i].get_ident() != "Wielokat_Pip" && objects[i].get_ident() != "Rectangle")
                    {
                        for (int j = 0; j < objects[i].points.Count; j++)
                        {
                            if (bol1 == true)
                            {
                                minXo = objects[i].points[j].X;
                                maxXo = objects[i].points[j].X;
                                minYo = objects[i].points[j].Y;
                                maxYo = objects[i].points[j].Y;
                                bol1 = false;
                            }
                            else
                            {
                                minXo = Math.Min(objects[i].points[j].X, minXo);
                                maxXo = Math.Max(objects[i].points[j].X, maxXo);
                                minYo = Math.Min(objects[i].points[j].Y, minYo);
                                maxYo = Math.Max(objects[i].points[j].Y, maxYo);
                            }
                        }
                    }
                }
                List<PointF> punkty = new List<PointF>();
                punkty.Add(new PointF(minXo, minYo));
                punkty.Add(new PointF(maxXo, minYo));
                punkty.Add(new PointF(maxXo, maxYo));
                punkty.Add(new PointF(minXo, maxYo));
                Obiekt mbr = new Obiekt("Rectangle", punkty, false);
                objects.Add(mbr);
                Invalidate();
                Refresh();
            }
        }

        private void usuń_MBRMenu_Click(object sender, EventArgs e)
        {
            if (objects.Count() != 0)
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    if (objects[i].get_ident() == "Rectangle")
                    {
                        objects.Remove(objects[i]);
                    }
                }
            }
           bol2 = false;
           Invalidate();
           Refresh();
        }
    //Point in Polygon
        private List<PointF> polygonPoints = new List<PointF>();
        bool rys = false, g=false;       
        Graphics G;

        private void rysuj_PipMenu_Click(object sender, EventArgs e)
        {
            if (objects.Count() != 0)
            {
                rys = true;
                polygonPoints.Clear();
            }
        }

        private void DrawLine(PointF p1, PointF p2)
        {
            if (g == false)
            { 
                G = this.CreateGraphics();
                g = true;
            }
            G.DrawLine(Pens.Black, p1, p2);
        }

        private bool IsPointInPolygon(PointF[] polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (rys == true)
            {
                polygonPoints.Add(new Point(e.X, e.Y));
                if (polygonPoints.Count > 1)
                {
                    this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                }
            }
        }

        private void start_PipMenu_Click(object sender, EventArgs e)
        {
            rys = false;
            g = false;
            if (polygonPoints.Count() > 2)
            {
                Obiekt wielokat = new Obiekt("Wielokat_Pip", polygonPoints, false);
                objects.Add(wielokat);

                int liczbpkt = objects.Last().get_points().Count;
                List<PointF> punktyAktualne = objects.Last().get_points();
                PointF[] pomocnicza = new PointF[liczbpkt];
                for (int j = 0; j < liczbpkt; j++)
                {
                    pomocnicza[j] = punktyAktualne[j];
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i].get_ident() == "Point")
                    {
                        IsPointInPolygon(pomocnicza,objects[i].points[0]);                        
                        if(IsPointInPolygon(pomocnicza, objects[i].points[0])==true)
                        {
                            objects[i].change_war(true);
                        }
                    }                    
                }
                MessageBox.Show(string.Format("Punkty wewnątrz Twojego poligonu zostały pogrubione i zmieniły kolor na zielony"), "Results", MessageBoxButtons.OK); ;
            }
            else
            {
                MessageBox.Show(string.Format("Wielokąt ma conajmniej trzy wierzchołki :)"), "Results", MessageBoxButtons.OK); ;
            }
            Invalidate();
            Refresh();
        }
        
        public List<int> zapamietane = new List<int>();

        private void Wyczysc_PipMenu_Click(object sender, EventArgs e)
        {
            if (objects.Count()!=0) 
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    if (objects[i].get_ident() == "Point")
                    {
                        if (objects[i].get_bool() == true)
                        {
                            objects[i].change_war(false);
                        }
                    }
                    if (objects[i].get_ident() == "Wielokat_Pip")
                    {
                        zapamietane.Add(i);
                    }
                }
                for (int i = 0; i < zapamietane.Count(); i++)
                {
                    int r = zapamietane[i];
                    objects.Remove(objects[r-i]);
                }
             Invalidate();
            Refresh();          
            }
        }

        private void przerwij_PipMenu_Click(object sender, EventArgs e)
        {
            Obiekt wielokat = new Obiekt("Polygon", polygonPoints, false);
            objects.Add(wielokat);
            objects.Remove(objects.Last());
            Invalidate();
            Refresh();
            polygonPoints.Clear();
            rys = false;
            g = false;
        }
    //Jarvis algorithm
        Stopwatch stopwatch = new Stopwatch();

        private List<PointF> makeOnlyPoint()
        {
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < objects.Count(); i++)
            {
                if (objects[i].get_ident() == "Point")
                {
                    PointF trzeci = new PointF(objects[i].points.First().X, objects[i].points.First().Y);
                    points.Add(trzeci);
                }
            }
            return points;
        }

        const int TURN_LEFT = 1;
        const int TURN_RIGHT = -1;
        const int TURN_NONE = 0;

        public int turn(PointF p, PointF q, PointF r)
        {
            return ((q.X - p.X) * (r.Y - p.Y) - (r.X - p.X) * (q.Y - p.Y)).CompareTo(0);
        }

        public float dist(PointF p, PointF q)
        {
            float dx = q.X - p.X;
            float dy = q.Y - p.Y;
            return dx * dx + dy * dy;
        }

        public PointF nextHullPoint(List<PointF> points, PointF p)
        {
            PointF q = p;
            int t;
            foreach (PointF r in points)
            {
                t = turn(p, q, r);
                if (t == TURN_RIGHT || t == TURN_NONE && dist(p, r) > dist(p, q))
                    q = r;
            }
            return q;
        }

        public double getAngle(PointF p1, PointF p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
        }

        private void jarvisMenu_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            List<PointF> pointsJ= new List<PointF>();
            pointsJ = makeOnlyPoint();
            List<PointF> hull = new List<PointF>();
            foreach (PointF p in pointsJ)
            {
                if (hull.Count == 0)
                    hull.Add(p);
                else
                {
                    if (hull[0].X > p.X)
                        hull[0] = p;
                    else if (hull[0].X == p.X)
                        if (hull[0].Y > p.Y)
                            hull[0] = p;
                }
            }
            PointF q;
            int counter = 0;
            while (counter < hull.Count)
            {
                q = nextHullPoint(pointsJ, hull[counter]);
                if (q != hull[0])
                {
                    hull.Add(q);
                }
                counter++;
            }

            objects.Add(new Obiekt("Otoczka", hull, false));
            Invalidate();
            Refresh();
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString()+" milisekund","Czas wykonania algorytmu Jarvisa", MessageBoxButtons.OK);
        }

        public List<int> zapamietaneO = new List<int>();

        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (objects.Count() != 0)
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    if (objects[i].get_ident() == "Otoczka")
                    {
                        zapamietaneO.Add(i);
                    }
                }
                for (int i = 0; i < zapamietaneO.Count(); i++)
                {
                    int r = zapamietaneO[i];
                    objects.Remove(objects[r - i]);
                }
                Invalidate();
                Refresh();
            }
        }
    //Graham algorithm
        PointF p0;            

        private void grahamMenu_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            List<PointF> pointsG = new List<PointF>();
            pointsG=makeOnlyPoint();
            bool flaga = false;
            foreach (PointF value in pointsG)
            {
                if (flaga == false)
                {
                    p0 = value;
                    flaga = true;
                }
                else
                {
                    if (p0.Y > value.Y)
                        p0 = value;
                }
            }
            List<PointF> order = new List<PointF>();
            foreach (PointF value in pointsG)
            {
                if (p0 != value)
                    order.Add(value);
            }
            order = MergeSort(p0, order);
            List<PointF> result = new List<PointF>();
            result.Add(p0);
            result.Add(order[0]);
            result.Add(order[1]);
            order.RemoveAt(0);
            order.RemoveAt(0);
            foreach (PointF value in order)
            {
                keepLeft(result, value);
            }
            objects.Add(new Obiekt("Otoczka", result, false));
            Invalidate();
            Refresh();
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + " milisekund", "Czas wykonania algorytmu Grahama", MessageBoxButtons.OK);
        }
        
        const int TURN_LEFTg = 1;
        const int TURN_RIGHTg = -1;
        const int TURN_NONEg = 0;

        public void keepLeft(List<PointF> hull, PointF r)
        {
            while (hull.Count > 1 && turn(hull[hull.Count - 2], hull[hull.Count - 1], r) != TURN_LEFTg)
            {
                hull.RemoveAt(hull.Count - 1);
            }
            if (hull.Count == 0 || hull[hull.Count - 1] != r)
            {
                hull.Add(r);
            }
        }

        public List<PointF> MergeSort(PointF p0, List<PointF> arrPoint)
        {
            if (arrPoint.Count == 1)
            {
                return arrPoint;
            }
            List<PointF> arrSortedInt = new List<PointF>();
            int middle = (int)arrPoint.Count / 2;
            List<PointF> leftArray = arrPoint.GetRange(0, middle);
            List<PointF> rightArray = arrPoint.GetRange(middle, arrPoint.Count - middle);
            leftArray = MergeSort(p0, leftArray);
            rightArray = MergeSort(p0, rightArray);
            int leftptr = 0;
            int rightptr = 0;
            for (int i = 0; i < leftArray.Count + rightArray.Count; i++)
            {
                if (leftptr == leftArray.Count)
                {
                    arrSortedInt.Add(rightArray[rightptr]);
                    rightptr++;
                }
                else if (rightptr == rightArray.Count)
                {
                    arrSortedInt.Add(leftArray[leftptr]);
                    leftptr++;
                }
                else if (getAngle(p0, leftArray[leftptr]) < getAngle(p0, rightArray[rightptr]))
                {
                    arrSortedInt.Add(leftArray[leftptr]);
                    leftptr++;
                }
                else
                {
                    arrSortedInt.Add(rightArray[rightptr]);
                    rightptr++;
                }
            }
            return arrSortedInt;
        }
        
    }
}
