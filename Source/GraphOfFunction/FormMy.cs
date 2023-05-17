using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Drawing.Drawing2D;

namespace GraphOfFunction
{
    public partial class FormMy : Form
    {

        public FormMy()
        {
            InitializeComponent();
        }
        public double minX = -20, maxX = 20;
        public double minY = -20, maxY = 20;
        private void DrawBackGround(bool t=true)
        {
            int sizeX = panelGraphFunction.Size.Width;
            int sizeY = panelGraphFunction.Size.Height;

            minX = Convert.ToDouble(textBoxMinX.Text);
            maxX = Convert.ToDouble(textBoxMaxX.Text);
            minY = Convert.ToDouble(textBoxMinY.Text);
            maxY = Convert.ToDouble(textBoxMaxY.Text);

            Graphics g = panelGraphFunction.CreateGraphics();
            if(t)g.Clear(Color.White);
            Pen dashed_pen = new Pen(Color.Gray, 0.1f);
            dashed_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = 0; i < sizeX; i += 20)
            {
                g.DrawLine(dashed_pen , new Point(i, 0), new Point(i, sizeY));
            }
            for (int i = 0; i < sizeY; i += 20)
            {
                g.DrawLine(dashed_pen , new Point(0, i), new Point(sizeX, i));
            }
            g.DrawLine(new Pen(Color.Black), new Point(0, sizeY / 2), new Point(sizeX, sizeY / 2));
            g.DrawLine(new Pen(Color.Black, 2), new Point(sizeX - 10, sizeY / 2 - 10), new Point(sizeX, sizeY / 2));
            g.DrawLine(new Pen(Color.Black, 2), new Point(sizeX - 10, sizeY / 2 + 10), new Point(sizeX, sizeY / 2));
            g.DrawLine(new Pen(Color.Black), new Point(sizeX / 2, 0), new Point(sizeX / 2, sizeY));
            g.DrawLine(new Pen(Color.Black, 2), new Point(sizeX / 2 - 10, 0 + 10), new Point(sizeX / 2, 0));
            g.DrawLine(new Pen(Color.Black, 2), new Point(sizeX / 2 + 10, 0 + 10), new Point(sizeX / 2, 0));

            for (int i = 40; i < sizeX; i += 40)
            {
                if (i == sizeX / 2) continue;
                string st = (minX + i * ((maxX - minX) / sizeX)).ToString();
                g.DrawLine(new Pen(Color.Black, 2), new Point(i, sizeY / 2 + 5), new Point(i, sizeY / 2 - 5));
                g.DrawString(st, new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(i - 15, sizeY / 2 + 4));
            }
            for (int i = 40; i < sizeY; i += 40)
            {
                if (i == sizeY / 2) continue;
                string st = (minX + (sizeY - i) * ((maxY - minY) / sizeY)).ToString();
                g.DrawLine(new Pen(Color.Black, 2), new Point(sizeX / 2 + 5, i), new Point(sizeX / 2 - 5, i));
                g.DrawString(st, new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(sizeX / 2 - 15, i + 4));
            }
            string point = "(" + (minX + (maxX - minX) / 2) + "; " + (minX + (maxY - minY) / 2) + ")";
            g.DrawString(point, new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(sizeX / 2 - 15, sizeY / 2 + 4));



        }
        
        class GFG
        {
            public double degBetweenPoints(PointF a, PointF b)
            {
                double x1 = a.X, x2 = b.X, y1 = a.Y, y2 = b.Y;
                if (y2 == y1 && x2 == x1)
                {
                    return 0;
                }
                else if (y2 > y1 && x2 == x1)
                {
                    return 90f;
                }
                else if (y2 < y1 && x2 == x1)
                {
                    return 270f;
                }
                else if (y2 > y1 && x2 > x1)
                {
                    return (Math.Atan((y2 - y1) / (x2 - x1)) * 180f / (Math.PI)) + 0f;
                }
                else if (x2 < x1)
                {
                    return (Math.Atan((y2 - y1) / (x2 - x1)) * 180f / (Math.PI)) + 180f;
                }
                else if (y2 < y1 && x2 > x1)
                {
                    return (Math.Atan((y2 - y1) / (x2 - x1)) * 180f / (Math.PI)) + 360f;
                }
                return 0;
            }
            double dis(PointF a, PointF b)
            {
                return Math.Sqrt(Math.Pow((double)(a.X - b.X), (double)2) + Math.Pow((double)(a.Y - b.Y), (double)2));
            }
            PointF A = new PointF();
            public GFG(PointF a) : base()
            {
                A = a;
            }
            public bool Compare(PointF x, PointF y)
            {
                if(degBetweenPoints(A, x) == degBetweenPoints(A, y))
                {
                    return (dis(A, x) > dis(A, y));
                }
                if (degBetweenPoints(A, x) > degBetweenPoints(A, y))
                    return true;
                else
                    return false;
            }
        }
        public List<PointF> findPoints()
        {
            List<PointF> rawPoints = new List<PointF>();
            for (int i = 0; i < listBoxFunctions.Items.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    FunctionColor fc1 = listBoxFunctions.Items[j] as FunctionColor;
                    FunctionColor fc2 = listBoxFunctions.Items[i] as FunctionColor;
                    PointF toAdd = intersection(fc1.Function, fc2.Function);
                    if (toAdd.X != -10000 || toAdd.Y != -10000)
                    {
                        rawPoints.Add(toAdd);
                    }
                }
            }

            List<PointF> truePoints = new List<PointF>();
            for (int i = 0; i < rawPoints.Count; i++)
            {
                bool isIn = true;
                for (int j = 0; j < listBoxFunctions.Items.Count; j++)
                {
                    FunctionColor fc = listBoxFunctions.Items[j] as FunctionColor;
                    string y = fc.Function;
                    if (!applyInFunction(rawPoints[i],fc,1))
                        isIn = false;
                }
                if (isIn)
                {
                    if (rawPoints[i].X <= maxX && rawPoints[i].X >= minX && rawPoints[i].Y <= maxY && rawPoints[i].Y >= minY)
                        truePoints.Add(rawPoints[i]);
                }
            }

            if(truePoints.Count < 1)
            {
                MessageBox.Show("No fissible point !!!");
                return truePoints;
            }
            //sort
            PointF first = truePoints[0];
            for (int i = 1; i < truePoints.Count; i++)
            {
                if (truePoints[i].Y < first.Y || (truePoints[i].Y == first.Y && truePoints[i].X < first.X))
                    first = truePoints[i];
            }

            GFG gg = new GFG(first);
            for (int i = 0; i < truePoints.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (gg.Compare(truePoints[i], truePoints[j]))
                    {
                        PointF t = truePoints[i];
                        truePoints[i] = truePoints[j];
                        truePoints[j] = t;
                    }
                }
            }
            return truePoints;
        }
        private int xIndex(string a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == 'x')
                    return i;
            return -1;
        }
        private int eqIndex(string a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == '=')
                    return i;
            return -1;
        }
        PointF intersection(String y1, String y2)
        {
            double a1 = 0, a2 = 0, b1 = 0, b2 = 0;
            int j = 0;
            PointF tore = new PointF();

            ///////////////////////////////////////////////////NOT INTERSECTION
            if (y1[0] == 'x' && y2[0] == 'x')
                return new PointF(-10000, -10000);
            
            // if one is "x = c"
            if (y1[0] == 'x' || y2[0] == 'x')
            {
                string y = "";
                double c = 0;
                if (y2[0] == 'x')
                {
                    y = y1;
                    c = double.Parse(y2.Substring(4));
                }
                else
                {
                    y = y2;
                    c = double.Parse(y1.Substring(4));
                }

                j = xIndex(y);
                a1 = double.Parse(y.Substring(0, j - 1));
                b1 = double.Parse(y.Substring(j + 4));

                tore.X = (float)c;
                tore.Y = (float)(tore.X * a1 + b1);
                return tore;
            }

            j = xIndex(y1);
            a1 = double.Parse(y1.Substring(0, j - 1));
            b1 = double.Parse(y1.Substring(j + 4));

            j = xIndex(y2);
            a2 = double.Parse(y2.Substring(0, j - 1));
            b2 = double.Parse(y2.Substring(j + 4));

            ///////////////////////////////////////////////////PARALLEL
            if (doubleEquality(a1,a2)) return new PointF(-10000,-10000);

            tore.X = (float)((b2 - b1) / (a1 - a2));
            tore.Y = (float)(tore.X * a1 + b1);
            return tore;
        }
        public void drawpolygon(PointF[] points,int t=0)
        {
            int sizeX = panelGraphFunction.Size.Width;
            int sizeY = panelGraphFunction.Size.Height;
            minX = Convert.ToDouble(textBoxMinX.Text);
            maxX = Convert.ToDouble(textBoxMaxX.Text);
            minY = Convert.ToDouble(textBoxMinY.Text);
            maxY = Convert.ToDouble(textBoxMaxY.Text);

            Graphics g = panelGraphFunction.CreateGraphics();

            PointF[] pts = new PointF[points.Length];
            for (int i=0;i < points.Length ;i++)
            {
                pts[i].X  = (int)(points[i].X / ((maxX - minX) / sizeX) - minX / ((maxX - minX) / (double)sizeX));
                pts[i].Y  = (int)(sizeY - (points[i].Y / ((maxY - minY) / sizeY) - minY / ((maxY - minY) / (double)sizeY)));
            }
            LinearGradientBrush fader = new LinearGradientBrush(new Point(3, 3), new Point(5, 5), Color.Blue, Color.White);
            fader.WrapMode = WrapMode.TileFlipXY;
            g.FillPolygon(fader, pts);

            if (t==0)
                g.DrawPolygon(new Pen(Color.Red, 2), pts);
            else if(t==1)
                g.DrawPolygon(new Pen(Color.LightGreen, 4), pts);
            else
                g.DrawPolygon(new Pen(Color.Black, 6), pts);
        }

        private void DrawFunction(string fcc,int t=0)
        {
            PointF[] pts = new PointF[] { new PointF(0, 0), new PointF(0, 0) };

            //If the line is not x=c draw line between intersection with x=min and x=max
            //  otherwise draw line between intersection with y=min and y=max
            if (fcc[0] != 'x')
                pts = new PointF[] { intersection(fcc, "x = " + minX.ToString()), intersection(fcc, "x = " + maxX.ToString()) };
            else
                pts = new PointF[] { intersection(fcc, "0*x + " + minY.ToString()), intersection(fcc, "0*x + " + maxY.ToString()) };

            drawpolygon(pts, t);
        }
        private void DrawFunctions()
        {
            if (listBoxFunctions.Items.Count <= 4)
            {
                DrawBackGround();
                return;
            }

            //Clear everything
            DrawBackGround();

            //Color inside of founded polygon
            List<PointF> points = findPoints();
            if (points.Count >= 3)
                drawpolygon(points.ToArray());

            //Paint Functions again
            for (int i = 4; i < listBoxFunctions.Items.Count; i++)
            {
                string fcc = (listBoxFunctions.Items[i] as FunctionColor).Function;
                DrawFunction(fcc);
            }

            //Paint borders again, and dont clear everything
            DrawBackGround(false);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FunctionColor fc = new FunctionColor("", Color.Black, 1);
            FormFunction formFunction = new FormFunction(fc);
            if (formFunction.ShowDialog() == DialogResult.OK)
            {
                adjustSizes(fc);
                listBoxFunctions.Items.Add(fc);
                DrawFunctions();
                listBox1.Items.Add(textFunction(fc));
            }
            Button1_Click(sender, e);
        }
        private void adjustSizes(FunctionColor fc1)
        {
            for (int i = 4; i < listBoxFunctions.Items.Count; i++)
            {
                FunctionColor fc2 = listBoxFunctions.Items[i] as FunctionColor;
                PointF inter = intersection(fc1.Function, fc2.Function);
                if (inter.X != -10000 || inter.Y != -10000)
                {
                    minX = Math.Min(minX, inter.X * 1.1);
                    maxX = Math.Max(maxX, inter.X * 1.1);
                    minY = Math.Min(minY, inter.Y * 1.1);
                    maxY = Math.Max(maxY, inter.Y * 1.1);
                }
            }
            double s = Math.Ceiling(Math.Max(Math.Max(-1 * minX, maxX), Math.Max(-1 * minY, maxY)));
            minX = minY = -1 * s;
            maxX = maxY = s;
            textBoxMinX.Text = minX.ToString();
            textBoxMaxX.Text = maxX.ToString();
            textBoxMinY.Text = minY.ToString();
            textBoxMaxY.Text = maxY.ToString();
            listBoxFunctions.Items[0] = new FunctionColor("0*x + " + minY.ToString(), Color.Black, 1);
            listBoxFunctions.Items[1] = new FunctionColor("0*x + " + maxY.ToString(), Color.Black, -1);
            listBoxFunctions.Items[2] = new FunctionColor("x = " + minX.ToString(), Color.Black, 1);
            listBoxFunctions.Items[3] = new FunctionColor("x = " + maxX.ToString(), Color.Black, -1);
        }
        private string textFunction(FunctionColor fc)
        {
            string fun = fc.Function;
            string mark = (fc.Sign == -1) ? "<=" : ">=";
            string tore = "";
            if (eqIndex(fun) != -1)
                tore = fun.Substring(0, eqIndex(fun)) + mark + fun.Substring(eqIndex(fun) + 1);
            else
                tore = "y " + mark + " " + fun;


            return tore;
        }
        private void panelGraphFunction_Paint(object sender, PaintEventArgs e)
        {
            DrawFunctions();
        }
        private void BtnSolve_Click(object sender, EventArgs e)
        {
            List<PointF> points = findPoints();
            double a1 = double.Parse(textBox1.Text);
            double a2 = double.Parse(textBox2.Text);

            //Sort points in respect to a1x + a2
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comboBox1.Text != "Max Z =")
                    {
                        if (a1 * points[i].X + a2 * points[i].Y > a1 * points[j].X + a2 * points[j].Y)
                        {
                            PointF t = points[i];
                            points[i] = points[j];
                            points[j] = t;
                        }
                    }
                    else
                    {
                        if (a1 * points[i].X + a2 * points[i].Y < a1 * points[j].X + a2 * points[j].Y)
                        {
                            PointF t = points[i];
                            points[i] = points[j];
                            points[j] = t;
                        }
                    }
                }
            }
            
            //make them uniqe
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i+1; j < points.Count; j++)
                {
                    if(doubleEquality(points[i].X,points[j].X) && doubleEquality(points[i].Y, points[j].Y))
                    {
                        points.RemoveAt(j);
                        j--;
                    }
                }
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                string fun = "";
                double c = a1 * points[i].X + a2 * points[i].Y;
                if(doubleEquality(a2,0))
                    fun = "x = " + (c / a1).ToString();
                else
                    fun = (-a1 / a2).ToString() + "*x + " + (c / a2).ToString();
                DrawFunction(fun, 1);
                System.Threading.Thread.Sleep(500);
            }

            string fun2 = "";
            int lastInd = points.Count - 1;
            double c2 = a1 * points[lastInd].X + a2 * points[lastInd].Y;
            if (doubleEquality(a2, 0))
                fun2 = "x = " + (c2 / a1).ToString();
            else
                fun2 = (-a1 / a2).ToString() + "*x + " + (c2 / a2).ToString();
            DrawFunction(fun2, 2);

            //Redundant constraints
            for (int i = 4; i < listBoxFunctions.Items.Count; i++)
            {
                FunctionColor fc = listBoxFunctions.Items[i] as FunctionColor;
                string y = fc.Function;
                listBox1.Items[i - 4] = textFunction(fc);

                bool c = false;
                for (int j = 0; j < points.Count; j++)
                    if (applyInFunction(points[j], fc))
                        c = true;
                if (!c)
                    listBox1.Items[i - 4] += " (Redundant constraint) ";
            }

            //Binding constraints
            if (lastInd > 0 && doubleEquality(a1 * points[lastInd].X + a2 * points[lastInd].Y , a1 * points[lastInd-1].X + a2 * points[lastInd-1].Y) )
            {
                if ( (doubleEquality(points[lastInd].X, points[lastInd - 1].X) && (doubleEquality(points[lastInd].X, minX) || doubleEquality(points[lastInd].X, maxX)) )
                  || (doubleEquality(points[lastInd].Y, points[lastInd - 1].Y) && (doubleEquality(points[lastInd].Y, minY) || doubleEquality(points[lastInd].Y, maxY)) ) )
                {
                    // javab behin bikaran
                    MessageBox.Show("javab behin bikaran");
                }
                else
                {
                    // javab behin degarin
                    //cout masale javab behin degarin dar khat vasel (.,.) va (.,.) darad
                    MessageBox.Show("masale javab behin degarin dar khat vasel ("
                        + points[lastInd].X.ToString()+" , "+ points[lastInd].Y.ToString() + ") va ("
                        + points[lastInd-1].X.ToString() + " , " + points[lastInd-1].Y.ToString() + ") darad");

                    for (int i = 4; i < listBoxFunctions.Items.Count; i++)
                    {
                        FunctionColor fc = listBoxFunctions.Items[i] as FunctionColor;
                        if (applyInFunction(points[lastInd], fc) || applyInFunction(points[lastInd - 1], fc))
                            listBox1.Items[i - 4] += "(Binding constraint)";
                    }
                }
            }
            else
            {
                if ( doubleEquality(points[lastInd].X, minX) || doubleEquality(points[lastInd].X, maxX)
                  || doubleEquality(points[lastInd].Y, minY) || doubleEquality(points[lastInd].Y, maxY) )
                {
                    // javab behin bikaran
                    MessageBox.Show("javab behin bikaran");
                }
                else
                {
                    // javab behin monhaser be fard
                    MessageBox.Show("masale javab behin monhaser be fard dar noghte ("
                        + points[lastInd].X.ToString() + " , " + points[lastInd].Y.ToString() + ") darad");

                    for (int i = 4; i < listBoxFunctions.Items.Count; i++)
                    {
                        FunctionColor fc = listBoxFunctions.Items[i] as FunctionColor;
                        if (applyInFunction(points[lastInd], fc))
                            listBox1.Items[i - 4] += " (Binding constraint)";
                    }
                }
            }
        }
        private bool applyInFunction(PointF p,FunctionColor fc, int t=0)
        {
            // if t==0 then just check ==
            // otherwise >= , <= 
            string y = fc.Function;
            if (y[0] == 'x')
            {
                if (doubleEquality(p.X , double.Parse(y.Substring(4)))) // p.X == double.Parse(y.Substring(4))
                    return true;
                if(t == 1)
                {
                    if (fc.Sign == 1 && p.X > double.Parse(y.Substring(4)))
                        return true;
                    else if (fc.Sign == -1 && p.X < double.Parse(y.Substring(4)))
                        return true;
                }
            }
            else
            {
                //a1*x + b1
                double a1 = 0, b1 = 0;
                a1 = double.Parse(y.Substring(0, xIndex(y) - 1));
                b1 = double.Parse(y.Substring(xIndex(y) + 4));

                if (doubleEquality(p.Y , (a1 * p.X + b1))) // points[j].Y == a1 * points[j].X + b1
                    return true;

                if (t == 1)
                {
                    if (fc.Sign == 1 && p.Y > a1 * p.X + b1)
                        return true;
                    else if (fc.Sign == -1 && p.Y < a1 * p.X + b1)
                        return true;
                }
            }

            return false;
        }

        private bool doubleEquality(double a, double b)
        {
            return (Math.Abs(a - b) < 0.0001);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            List<PointF> points = findPoints();

            for (int i = 4; i < listBoxFunctions.Items.Count; i++)
            {
                FunctionColor fc = listBoxFunctions.Items[i] as FunctionColor;
                string y = fc.Function;
                listBox1.Items[i - 4] = textFunction(fc);

                bool c = false;
                for (int j = 0; j < points.Count; j++)
                    if (applyInFunction(points[j],fc))
                        c = true;

                if (!c)
                    listBox1.Items[i - 4] += " (Redundant constraint)";
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            minX = Convert.ToDouble(textBoxMinX.Text);
            maxX = Convert.ToDouble(textBoxMaxX.Text);
            minY = Convert.ToDouble(textBoxMinY.Text);
            maxY = Convert.ToDouble(textBoxMaxY.Text);
            listBoxFunctions.Items.Clear();
            listBoxFunctions.Items.Add(new FunctionColor("0*x + " + minY.ToString(), Color.Black, 1));
            listBoxFunctions.Items.Add(new FunctionColor("0*x + " + maxY.ToString(), Color.Black, -1));
            listBoxFunctions.Items.Add(new FunctionColor("x = " + minX.ToString(), Color.Black, 1));
            listBoxFunctions.Items.Add(new FunctionColor("x = " + maxX.ToString(), Color.Black, -1));
            listBox1.Items.Clear();
            DrawFunctions();
        }

        private void FormMy_Load(object sender, EventArgs e)
        {
            //Borders
            listBoxFunctions.Items.Add(new FunctionColor("0*x + " + minY.ToString(), Color.Black, 1));
            listBoxFunctions.Items.Add(new FunctionColor("0*x + " + maxY.ToString(), Color.Black, -1));
            listBoxFunctions.Items.Add(new FunctionColor("x = " + minX.ToString(), Color.Black, 1));
            listBoxFunctions.Items.Add(new FunctionColor("x = " + maxX.ToString(), Color.Black, -1));
            DrawFunctions();
        }
    }
}
