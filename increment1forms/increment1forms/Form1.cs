using System.ComponentModel;
using System.Threading.Tasks;
using NLua;
using static System.Net.Mime.MediaTypeNames;

namespace increment1forms
{
    public partial class Form1 : Form
    {
        EducationalPlatform educationalPlatform;
        Label title;
        PictureBox dot1;
        Label dotCoordinates1;
        PictureBox dot2;
        Label dotCoordinates2;
        PictureBox xLine;
        PictureBox yLine;
        bool animating1;
        bool animating2;
        bool animating3;
        bool animating4;
        bool animating5;
        Button tryBtn;
        PictureBox tryDot1;
        Label tryCoordinates1;
        PictureBox tryDot2;
        Label tryCoordinates2;
        PictureBox tryDot3;
        Label tryCoordinates3;
        TextBox[] matrixCells;
        HScrollBar slider;
        String selectedLesson;
        //ACTIVITY ENVIRONMENT
        Lua state = new Lua();
        RichTextBox editor;
        ListBox output;
        Label instructions;
        //COORDINATE SYSTEMS ACTIVITY OBJECTS
        PictureBox spriteA;
        PictureBox spriteB;
        public Form1()
        {
            InitializeComponent();
            educationalPlatform = new EducationalPlatform();
            Course vectormath = new Course("Vector Math");
            educationalPlatform.addCourse(vectormath);
            vectormath.addStudent(new Student());
            //ADD COURSE LESSONS
            vectormath.addLesson(new Lesson("Coordinate Systems"));
            vectormath.addLesson(new Lesson("Advanced Vector Math"));
            vectormath.addLesson(new Lesson("Matrices and Transforms"));
            vectormath.addLesson(new Lesson("Interpolation"));
            vectormath.addLesson(new Lesson("Beziers, Curves, and Paths"));
            vectormathPage();
            selectedLesson = "Vector Math";
            runBtn.Visible = false;
            backBtn.Visible = false;
            return;
        }

        private void titler(String titleText)
        {
            animating1 = false;
            animating2 = false;
            animating3 = false;
            animating4 = false;
            animating5 = false;
            Thread.Sleep(60);
            panel1.Controls.Clear();
            //CREATES A NEW TITLE LABEL
            title = new Label();
            title.Location = new Point(0, 0);
            title.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            title.Size = new Size(1400, 50);
            title.Text = titleText;
            panel1.Controls.Add(title);
            return;
        }

        private Label describer(int y, int height)
        {
            //CREATES A NEW DESCRIPTION LABEL
            Label label = new Label();
            label.Location = new Point(0, y);
            label.Font = new Font("Segoe UI", 10);
            label.Size = new Size(1400, height);
            panel1.Controls.Add(label);
            return label;
        }

        private void vectormathPage()
        {
            startactivityBtn.Visible = false;
            panel1.AutoScrollPosition = new Point(0, 0);
            //VECTOR MATH PAGE
            titler("Vector Math");
            Label vmText1 = describer(50, 70);
            vmText1.Text = "This course is a short and practical introduction to linear algebra as it applies to " +
                "game development. Linear algebra is the study of vectors and their uses.\n" +
                "Vectors have many applications in both 2D and 3D development. Developing a good understanding of " +
                "vector math is essential to becoming a strong game developer.";
            vmText1.Font = new Font("Segoe UI", 12);
            vmText1.Size = new Size(1600, 70);
            PictureBox frontPageVisual = new PictureBox();
            frontPageVisual.Image = Properties.Resources.VectorMathVisual;
            frontPageVisual.Location = new Point(0, 150);
            frontPageVisual.Size = new Size(1450, 950);
            frontPageVisual.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Controls.Add(frontPageVisual);
            return;
        }

        private void vectormathBtn_Click(object sender, EventArgs e)
        {
            selectedLesson = "Vector Math";
            vectormathPage();
            return;
        }

        private void drawTwoAxes(int x, int y)
        {
            PictureBox xAxis = new PictureBox();
            xAxis.Location = new Point(x, y);
            xAxis.Image = Properties.Resources.BlackSquare;
            xAxis.Size = new Size(300, 2);
            panel1.Controls.Add(xAxis);
            PictureBox yAxis = new PictureBox();
            yAxis.Location = new Point(x, y);
            yAxis.Image = Properties.Resources.BlackSquare;
            yAxis.Size = new Size(2, 300);
            panel1.Controls.Add(yAxis);
            return;
        }

        private PictureBox drawDot(int x, int y, String color)
        {
            PictureBox dot = new PictureBox();
            dot.Location = new Point(x, y);
            switch (color)
            {
                case "black":
                    dot.Image = Properties.Resources.BlackCircle;
                    break;
                case "red":
                    dot.Image = Properties.Resources.RedCircle;
                    break;
                case "green":
                    dot.Image = Properties.Resources.GreenCircle;
                    break;
                case "blue":
                    dot.Image = Properties.Resources.BlueCircle;
                    break;
            }
            dot.SizeMode = PictureBoxSizeMode.Zoom;
            dot.Size = new Size(10, 10);
            panel1.Controls.Add(dot);
            return dot;
        }

        private void coodinatesystemsBtn_Click(object sender, EventArgs e)
        {
            startactivityBtn.Visible = true;
            panel1.AutoScrollPosition = new Point(0, 0);
            selectedLesson = "Coordinate Systems";
            titler(selectedLesson);
            Label csText1 = describer(50, 50);
            csText1.Text = "In 2D space, coordinates are defined using a horizontal axis (x) and a vertical " +
                "axis (y). A particular position in 2D space is written as a pair of values such as (4, 3).";
            //DRAW AXES 1
            drawTwoAxes(50, 100);
            //DRAW DOT 1
            dot1 = drawDot(0, 0, "black");
            dotCoordinates1 = new Label();
            dotCoordinates1.Font = new Font("Segoe UI", 10);
            panel1.Controls.Add(dotCoordinates1);
            //DRAW X LINE
            xLine = new PictureBox();
            xLine.Image = Properties.Resources.RedSquare;
            panel1.Controls.Add(xLine);
            //DRAW Y LINE
            yLine = new PictureBox();
            yLine.Image = Properties.Resources.RedSquare;
            panel1.Controls.Add(yLine);
            //TEXT 2
            Label csText2 = describer(420, 120);
            csText2.Text = "If you're new to computer graphics, it might seem odd that the positive y axis points " +
                "downwards instead of upwards, as you probably learned in math class. However, this is common in " +
                "most computer graphics applications.\n\n" +
                "Try running the code below to add two vectors.";
            //GUIDE EDITOR
            editor = new RichTextBox();
            editor.Font = new Font("Segoe UI", 10);
            editor.Location = new Point(0, 550);
            editor.Size = new Size(600, 200);
            panel1.Controls.Add(editor);
            editor.Text = "aX = 10\naY = 20\nbX = 30\nbY = 40\n\nx = aX + bX\ny = aY + bY";
            //GUIDE BUTTON
            tryBtn = new Button();
            tryBtn.Text = "Try";
            tryBtn.Font = new Font("Segoe UI", 10);
            tryBtn.Location = new Point(530, 770);
            tryBtn.Size = new Size(70, 40);
            panel1.Controls.Add(tryBtn);
            tryBtn.Click += TryBtn_Click1;
            //DRAW AXES 2
            drawTwoAxes(700, 550);
            //TRY DOT 1
            tryDot1 = drawDot(700, 550, "blue");
            tryCoordinates1 = new Label();
            tryCoordinates1.Location = new Point(700, 550);
            tryCoordinates1.Font = new Font("Segoe UI", 10);
            tryCoordinates1.Text = "";
            panel1.Controls.Add(tryCoordinates1);
            //TRY DOT 2
            tryDot2 = drawDot(700, 550, "green");
            tryCoordinates2 = new Label();
            tryCoordinates2.Location = new Point(700, 550);
            tryCoordinates2.Font = new Font("Segoe UI", 10);
            tryCoordinates2.Text = "";
            panel1.Controls.Add(tryCoordinates2);
            //TEXT 3
            Label csText3 = describer(890, 50);
            csText3.Text = "Any position in the 2D plane can be identified by a pair of numbers in this way. " +
                "However, we can also think of the position (4, 3) as an offset from the (0, 0) point, or origin.";
            //DRAW AXES 3
            drawTwoAxes(50, 960);
            //DRAW VECTOR DOT
            PictureBox vectorDot = drawDot(110, 1000, "black");
            //VECTOR DOT COORDINATES
            Label vectorCoordinates = new Label();
            vectorCoordinates.Location = new Point(130, 1005);
            vectorCoordinates.Font = new Font("Segoe UI", 10);
            vectorCoordinates.Text = "(4, 3)";
            panel1.Controls.Add(vectorCoordinates);
            Label csText4 = describer(1300, 200);
            csText4.Text = "This is a vector. A vector represents a lot of useful information. As well as telling " +
                "us that the point is at (4, 3), we can also think of it as an angle theta and a length " +
                "(or magnitude) m. In this case, the arrow is a position vector - it denotes a position in space, " +
                "relative to the origin.\n\n" +
                "A very important point to consider about vectors is that they only represent relative direction " +
                "and magnitude. There is no concept of a vector's position.";
            //ANIMATE
            animating1 = true;
            BackgroundWorker bw1 = new BackgroundWorker();
            bw1.DoWork += new DoWorkEventHandler(bw1_DoWork1);
            bw1.RunWorkerAsync();
            return;
        }

        private void TryBtn_Click1(object sender, EventArgs e)
        {
            //LUA
            try
            {
                state.DoString(editor.Text);
                int aX = Int32.Parse(state["aX"].ToString());
                int aY = Int32.Parse(state["aY"].ToString());
                int bX = Int32.Parse(state["bX"].ToString());
                int bY = Int32.Parse(state["bY"].ToString());
                int x = Int32.Parse(state["x"].ToString());
                int y = Int32.Parse(state["y"].ToString());
                tryCoordinates1.Text = "(" + aX + ", " + aY + ")";
                int baseY = title.Location.Y;
                if (aX > 300) aX = 300;
                if (aY > 300) aY = 300;
                if (aX < 0) aX = 0;
                if (aY < 0) aY = 0;
                tryDot1.Location = new Point(700 + aX, 550 + aY + baseY);
                tryCoordinates1.Location = new Point(700 + aX, 555 + aY + baseY);
                tryCoordinates2.Text = "(" + x + ", " + y + ")";
                if (x > 300) x = 300;
                if (y > 300) y = 300;
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                tryDot2.Location = new Point(700 + x, 550 + y + baseY);
                tryCoordinates2.Location = new Point(700 + x, 555 + y + baseY);
            }
            catch (NLua.Exceptions.LuaScriptException ex)
            {
                return;
            }
            return;
        }

        private void bw1_DoWork1(object sender, DoWorkEventArgs e)
        {
            int amplitude = 50;
            double theta = 0;
            while (animating1)
            {
                int x = (int)(200 + amplitude * Math.Cos(theta));
                int y = (int)(250 + amplitude * Math.Sin(theta));
                int baseY = title.Location.Y;
                dot1.Location = new Point(x, baseY + y);
                dotCoordinates1.Location = new Point(x + 20, baseY + y - 8);
                dotCoordinates1.Text = "(" + (x / 20) + "," + (y / 20) + ")";
                xLine.Location = new Point(x + 5, baseY + 100);
                xLine.Size = new Size(1, y - 100);
                yLine.Location = new Point(50, baseY + y + 5);
                yLine.Size = new Size(x - 50, 1);
                theta += 0.1;
                if (theta > 6.28)
                {
                    theta = 0;
                }
                Thread.Sleep(50);
            }
            return;
        }

        private void advancedvectormathBtn_Click(object sender, EventArgs e)
        {
            startactivityBtn.Visible = true;
            panel1.AutoScrollPosition = new Point(0, 0);
            selectedLesson = "Advanced Vector Math";
            titler(selectedLesson);
            Label avmText1 = describer(50, 50);
            avmText1.Text = "The dot product has another interesting property with unit vectors. Imagine that " +
                "perpendicular to that vector (and through the origin) passes a plane. Planes divide the entire " +
                "space into positive (over the plane) and negative (under the plane), and (contrary to popular " +
                "belief) you can also use their math in 2D:";
            //DRAW AXES 1
            drawTwoAxes(50, 110);
            //NORMAL LINE
            for (int x = 50; x < 350; x += 3)
            {
                PictureBox segment = new PictureBox();
                segment.Location = new Point(x, 60 + x);
                segment.Image = Properties.Resources.RedSquare;
                segment.Size = new Size(3, 3);
                panel1.Controls.Add(segment);
            }
            //DOT 1
            tryDot1 = drawDot(230, 200, "black");
            tryCoordinates1 = new Label();
            tryCoordinates1.Font = new Font("Segoe UI", 10);
            panel1.Controls.Add(tryCoordinates1);
            //DOT 2
            tryDot2 = drawDot(250, 200, "green");
            tryCoordinates2 = new Label();
            tryCoordinates2.Font = new Font("Segoe UI", 10);
            panel1.Controls.Add(tryCoordinates2);
            //DOT 3
            tryDot3 = drawDot(270, 200, "blue");
            tryCoordinates3 = new Label();
            tryCoordinates3.Font = new Font("Segoe UI", 10);
            panel1.Controls.Add(tryCoordinates3);
            //TEXT 2
            Label avmText2 = describer(420, 210);
            avmText2.Text = "Unit vectors that are perpendicular to a surface (so, they describe the orientation " +
                "of the surface) are called unit normal vectors. Though, usually they are just abbreviated as " +
                "normals. Normals appear in planes, 3D geometry (to determine where each face or vertex is " +
                "siding), etc. A normal is a unit vector, but it's called normal because of its usage. (Just like " +
                "we call (0,0) the Origin!).\n\n" +
                "The plane passes by the origin and the surface of it is perpendicular to the unit vector " +
                "(or normal). The side towards the vector points to is the positive half-space, while the other " +
                "side is the negative half-space. In 3D this is exactly the same, except that the plane is an " +
                "infinite surface (imagine an infinite, flat sheet of paper that you can orient and is pinned to " +
                "the origin) instead of a line.\n\n" +
                "Try running the code below to determine the dot product between two vectors.";
            //GUIDE EDITOR
            editor = new RichTextBox();
            editor.Font = new Font("Segoe UI", 10);
            editor.Location = new Point(0, 650);
            editor.Size = new Size(600, 200);
            panel1.Controls.Add(editor);
            editor.Text = "aX = 70\naY = 30\nbX = 40\nbY = 80\n\nDotProduct = aX * bX + aY * bY";
            //GUIDE BUTTON
            tryBtn = new Button();
            tryBtn.Text = "Try";
            tryBtn.Font = new Font("Segoe UI", 10);
            tryBtn.Location = new Point(530, 870);
            tryBtn.Size = new Size(70, 40);
            panel1.Controls.Add(tryBtn);
            tryBtn.Click += TryBtn_Click2;
            //DRAW AXES 2
            drawTwoAxes(700, 650);
            //DRAW DOT 1
            dot1 = drawDot(770, 680, "blue");
            dotCoordinates1 = new Label();
            dotCoordinates1.Font = new Font("Segoe UI", 10);
            dotCoordinates1.Location = new Point(770, 685);
            dotCoordinates1.Text = "(70, 30)";
            panel1.Controls.Add(dotCoordinates1);
            //DRAW DOT 2
            dot2 = drawDot(740, 730, "green");
            dotCoordinates2 = new Label();
            dotCoordinates2.Font = new Font("Segoe UI", 10);
            dotCoordinates2.Location = new Point(740, 735);
            dotCoordinates2.Text = "(40, 80)";
            panel1.Controls.Add(dotCoordinates2);
            //DOT PRODUCT LABEL
            instructions = new Label();
            instructions.Font = new Font("Segoe UI", 10);
            instructions.Location = new Point(700, 625);
            instructions.Size = new Size(300, 35);
            instructions.Text = "Dot Product: ";
            panel1.Controls.Add(instructions);
            //DISTANCE TO PLANE
            Label distancetoplane = new Label();
            distancetoplane.Location = new Point(0, 1000);
            distancetoplane.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            distancetoplane.Size = new Size(1400, 20);
            distancetoplane.Text = "Distance to plane";
            panel1.Controls.Add(distancetoplane);
            //TEXT 3
            Label avmText3 = describer(1050, 220);
            avmText3.Text = "Now that it's clear what a plane is, let's go back to the dot product. The dot " +
                "product between a unit vector and any point in space (yes, this time we do dot product between " +
                "vector and position), returns the distance from the point to the plane:\n\n" +
                "Dot Product = aX * bX + aY * bY\n\n" +
                "But not just the absolute distance, if the point is in the negative half space the distance will " +
                "be negative, too. This allows us to tell which side of the plane a point is.";
            //ANIMATE
            animating2 = true;
            BackgroundWorker bw2 = new BackgroundWorker();
            bw2.DoWork += new DoWorkEventHandler(bw2_DoWork2);
            bw2.RunWorkerAsync();
            return;
        }

        private void TryBtn_Click2(object sender, EventArgs e)
        {
            //LUA
            try
            {
                state.DoString(editor.Text);
                int aX = Int32.Parse(state["aX"].ToString());
                int aY = Int32.Parse(state["aY"].ToString());
                int bX = Int32.Parse(state["bX"].ToString());
                int bY = Int32.Parse(state["bY"].ToString());
                int dotProduct = Int32.Parse(state["DotProduct"].ToString());
                dotCoordinates1.Text = "(" + aX + ", " + aY + ")";
                dotCoordinates2.Text = "(" + bX + ", " + bY + ")";
                int baseY = title.Location.Y;
                if (aX > 300) aX = 300;
                if (aY > 300) aY = 300;
                if (aX < 0) aX = 0;
                if (aY < 0) aY = 0;
                if (bX > 300) bX = 300;
                if (bY > 300) bY = 300;
                if (bX < 0) bX = 0;
                if (bY < 0) bY = 0;
                dot1.Location = new Point(700 + aX, 650 + aY + baseY);
                dot2.Location = new Point(700 + bX, 650 + bY + baseY);
                dotCoordinates1.Location = new Point(700 + aX, 655 + aY + baseY);
                dotCoordinates2.Location = new Point(700 + bX, 655 + bY + baseY);
                instructions.Text = "Dot Product: " + dotProduct;
            }
            catch (NLua.Exceptions.LuaScriptException ex)
            {
                return;
            }
            return;
        }

        private void bw2_DoWork2(object sender, DoWorkEventArgs e)
        {
            int originX = 50;
            int originY = 110;
            double theta = 0;
            while (animating2)
            {
                double alpha = Math.Abs(Math.Cos(theta));
                int x1 = (int)(originX + 100 + 60 * alpha);
                int y1 = (int)(originY + 100 - 60 * alpha);
                int x2 = (int)(originX + 200 - 70 * alpha);
                int y2 = (int)(originY + 200 + 70 * alpha);
                int x3 = (int)(originX + 250 + 50 * alpha);
                int y3 = (int)(originY + 250 - 50 * alpha);
                int baseY = title.Location.Y;
                tryDot1.Location = new Point(x1, baseY + y1);
                tryDot2.Location = new Point(x2, baseY + y2);
                tryDot3.Location = new Point(x3, baseY + y3);
                tryCoordinates1.Location = new Point(x1 + 20, baseY + y1 - 8);
                tryCoordinates2.Location = new Point(x2 - 32, baseY + y2 - 8);
                tryCoordinates3.Location = new Point(x3 + 20, baseY + y3 - 8);
                tryCoordinates1.Text = "" + (int)(60 * alpha);
                tryCoordinates2.Text = "" + (int)(70 * alpha);
                tryCoordinates3.Text = "" + (int)(50 * alpha);
                theta += 0.1;
                if (theta > 6.28)
                {
                    theta = 0;
                }
                Thread.Sleep(50);
            }
            return;
        }

        private void matricesandtransformsBtn_Click(object sender, EventArgs e)
        {
            startactivityBtn.Visible = true;
            panel1.AutoScrollPosition = new Point(0, 0);
            selectedLesson = "Matrices and Transforms";
            titler(selectedLesson);
            Label mtText1 = describer(50, 260);
            mtText1.Text = "Before reading this tutorial, we recommend that you thoroughly read and understand " +
                "the Vector math tutorial, as this tutorial requires a knowledge of vectors.\n\n" +
                "This tutorial is about transformations and how we represent them in Godot using matrices. " +
                "It is not a full in-depth guide to matrices. Transformations are most of the time applied as " +
                "translation, rotation, and scale, so we will focus on how to represent those with matrices. " +
                "Most of this guide focuses on 2D, using Transform2D and Vector2, but the way things work in 3D " +
                "is very similar.\n\n" +
                "As mentioned in the previous tutorial, it is important to remember that the Y axis points down in " +
                "2D. This is the opposite of how most schools teach linear algebra, with the Y axis pointing up.\n\n" +
                "The convention is that the X axis is red, the Y axis is green, and the Z axis is blue. This " +
                "tutorial is color-coded to match these conventions, but we will also represent the origin vector " +
                "with a blue color.";
            Label matrixcomponents = new Label();
            matrixcomponents.Location = new Point(0, 330);
            matrixcomponents.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            matrixcomponents.Size = new Size(1400, 20);
            matrixcomponents.Text = "Matrix components and the Identity matrix";
            panel1.Controls.Add(matrixcomponents);
            Label mtText2 = describer(370, 50);
            mtText2.Text = "The identity matrix represents a transform with no translation, no rotation, and no " +
                "scale. Let's start by looking at the identity matrix and how its components relate to how it " +
                "visually appears.";
            //TEXT 3
            Label mtText3 = describer(440, 280);
            mtText3.Text = "Matrices have rows and columns, and a transformation matrix has specific conventions " +
                "on what each does.\n\n" +
                "In the image above, we can see that the red X vector is represented by the first column of the " +
                "matrix, and the green Y vector is likewise represented by the second column. A change to the " +
                "columns will change these vectors. We will see how they can be manipulated in the next few " +
                "examples.\n\n" +
                "You should not worry about manipulating rows directly, as we usually work with columns. However, " +
                "you can think of the rows of the matrix as showing which vectors contribute to moving in a given " +
                "direction.\n\n" +
                "When we refer to a value such as t.x.y, that's the Y component of the X column vector. In other " +
                "words, the bottom-left of the matrix. Similarly, t.x.x is top-left, t.y.x is top-right, and t.y.y " +
                "is bottom-right, where t is the 2D Transform.\n\n" +
                "Try doing the matrix-vector multiplication below.";
            //MATRIX BRACKETS
            Label equals = new Label();
            equals.Font = new Font("Segoe UI", 25);
            equals.Text = "=";
            equals.Size = new Size(30, 40);
            equals.Location = new Point(340, 790);
            panel1.Controls.Add(equals);
            int[] bracketLocations = new int[] { 50, 210, 250, 310, 390, 450 };
            PictureBox[] brackets = new PictureBox[6];
            for (int i = 0; i < 6; i++)
            {
                brackets[i] = new PictureBox();
                brackets[i].Image = Properties.Resources.MatrixBracket;
                brackets[i].Size = new Size(20, 150);
                brackets[i].SizeMode = PictureBoxSizeMode.Zoom;
                if (i % 2 != 0)
                {
                    System.Drawing.Image imgBracket = brackets[i].Image;
                    imgBracket.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    brackets[i].Image = imgBracket;
                }
                brackets[i].Location = new Point(bracketLocations[i], 750);
                panel1.Controls.Add(brackets[i]);
            }
            //MATRIX CELLS
            int[,] cellValues = new int[,]
            {
                { 1, 2, 5 },
                { 3, 4, 6 }
            };
            int[] cellPositions = new int[] { 80, 150, 270, 410 };
            matrixCells = new TextBox[8];
            for (int i = 0; i < 8; i++)
            {
                matrixCells[i] = new TextBox();
                matrixCells[i].Location = new Point(cellPositions[i / 2], 775 + 60 * (i % 2));
                matrixCells[i].Size = new Size(50, 100);
                matrixCells[i].Font = new Font("Segoe UI", 15);
                matrixCells[i].TextAlign = HorizontalAlignment.Center;
                if (i < 6)
                {
                    matrixCells[i].Text = "" + cellValues[i % 2, i / 2];
                }
                panel1.Controls.Add(matrixCells[i]);
            }
            //GUIDE BUTTON
            tryBtn = new Button();
            tryBtn.Text = "Try";
            tryBtn.Font = new Font("Segoe UI", 10);
            tryBtn.Location = new Point(395, 905);
            tryBtn.Size = new Size(70, 40);
            panel1.Controls.Add(tryBtn);
            tryBtn.Click += TryBtn_Click3;
            //TEXT 4
            Label mtText4 = describer(1200, 50);
            return;
        }

        private void TryBtn_Click3(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(matrixCells[0].Text);
                double b = double.Parse(matrixCells[2].Text);
                double c = double.Parse(matrixCells[1].Text);
                double d = double.Parse(matrixCells[3].Text);
                double x = double.Parse(matrixCells[4].Text);
                double y = double.Parse(matrixCells[5].Text);
                matrixCells[6].Text = "" + (a * x + b * y);
                matrixCells[7].Text = "" + (c * x + d * y);
            }
            catch
            {
                return;
            }
            return;
        }

        private void interpolationBtn_Click(object sender, EventArgs e)
        {
            startactivityBtn.Visible = true;
            panel1.AutoScrollPosition = new Point(0, 0);
            selectedLesson = "Interpolation";
            titler(selectedLesson);
            Label iText1 = describer(50, 500);
            iText1.Text = "Interpolation is a very basic operation in graphics programming. It's good to become " +
                "familiar with it in order to expand your horizons as a graphics developer.\n\n" +
                "The basic idea is that you want to transition from A to B. A value t, represents the states " +
                "in-between.\n\n" +
                "For example, if t is 0, then the state is A. If t is 1, then the state is B. Anything in-between " +
                "is an interpolation.\n\n" +
                "Between two real (floating-point) numbers, an interpolation can be described as:\n\n" +
                "interpolation = A * (1 - t) + B * t\n\n" +
                "And often simplified to:\n\n" +
                "interpolation = A + (B - A) * t\n\n" +
                "The name of this type of interpolation, which transforms a value into another at constant speed " +
                "is linear. So, when you hear about Linear Interpolation, you know they are referring to this " +
                "formula.\n\nThere are other types of interpolations, which will not be covered here. A " +
                "recommended read afterwards is the Bezier page.\n\n" +
                "Try moving the slider below to see interpolation in action.";
            //SLIDER VALUE
            dotCoordinates1 = new Label();
            dotCoordinates1.Text = "Interpolation: 0";
            dotCoordinates1.Font = new Font("Segoe UI", 15);
            dotCoordinates1.Size = new Size(1000, 40);
            dotCoordinates1.Location = new Point(50, 550);
            panel1.Controls.Add(dotCoordinates1);
            //SLIDER
            slider = new HScrollBar();
            slider.Location = new Point(50, 600);
            slider.Size = new Size(500, 30);
            panel1.Controls.Add(slider);
            Thread.Sleep(100);
            //DRAW DOT 1
            tryDot1 = drawDot(100, 800, "blue");
            tryCoordinates1 = new Label();
            tryCoordinates1.Location = new Point(20, 810);
            tryCoordinates1.Font = new Font("Segoe UI", 10);
            tryCoordinates1.Text = "(100, 800)";
            tryCoordinates1.Size = new Size(90, 20);
            panel1.Controls.Add(tryCoordinates1);
            //DRAW DOT 2
            tryDot2 = drawDot(900, 700, "green");
            tryCoordinates2 = new Label();
            tryCoordinates2.Location = new Point(910, 685);
            tryCoordinates2.Font = new Font("Segoe UI", 10);
            tryCoordinates2.Text = "(900, 700)";
            panel1.Controls.Add(tryCoordinates2);
            //DRAW DOT 3
            tryDot3 = drawDot(100, 800, "red");
            tryDot3.Size = new Size(20, 20);
            tryCoordinates3 = new Label();
            tryCoordinates3.Location = new Point(100, 805);
            tryCoordinates3.Font = new Font("Segoe UI", 10);
            tryCoordinates3.Text = "(100, 800)";
            panel1.Controls.Add(tryCoordinates3);
            //TEXT 2
            iText1 = describer(1200, 50);
            //ANIMATE
            animating4 = true;
            BackgroundWorker bw4 = new BackgroundWorker();
            bw4.DoWork += new DoWorkEventHandler(bw4_DoWork4);
            bw4.RunWorkerAsync();
            return;
        }

        private void bw4_DoWork4(object sender, DoWorkEventArgs e)
        {
            while (animating4)
            {
                double lerp = (slider.Value / 91.0) * 100;
                lerp = ((int)lerp) / 100.0;
                dotCoordinates1.Text = "Interpolation: " + lerp;
                int x = (int)(100 + lerp * 800);
                int y = (int)(800 - lerp * 100);
                int baseY = title.Location.Y;
                tryDot3.Location = new Point(x, y + baseY);
                tryCoordinates3.Location = new Point(x + 10, y + 15 + baseY);
                tryCoordinates3.Text = "(" + x + ", " + y + ")";
                Thread.Sleep(10);
            }
            return;
        }

        private void bezierscurvesandpathsBtn_Click(object sender, EventArgs e)
        {
            startactivityBtn.Visible = true;
            panel1.AutoScrollPosition = new Point(0, 0);
            selectedLesson = "Beziers, Curves, and Paths";
            titler(selectedLesson);
            Label bcpText1 = describer(50, 140);
            bcpText1.Text = "Bezier curves are a mathematical approximation of natural geometric shapes. We use " +
                "them to represent a curve with as little information as possible and with a high level of " +
                "flexibility.\n\n" +
                "Unlike more abstract mathematical concepts, Bezier curves were created for industrial design. " +
                "They are a popular tool in the graphics software industry.\n\n" +
                "They rely on interpolation, which we saw in the previous article, combining multiple steps to " +
                "create smooth curves. To better understand how Bezier curves work, let's start from its simplest " +
                "form: Quadratic Bezier.";
            Label quadraticbezier = new Label();
            quadraticbezier.Location = new Point(0, 210);
            quadraticbezier.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            quadraticbezier.Size = new Size(1400, 20);
            quadraticbezier.Text = "Quadratic Bezier";
            panel1.Controls.Add(quadraticbezier);
            //TEXT 2
            Label bcpText2 = describer(250, 140);
            bcpText2.Text = "Take three points, the minimum required for Quadratic Bezier to work:\n\n" +
                "To draw a curve between them, we first interpolate gradually over the two vertices of each of " +
                "the two segments formed by the three points, using values ranging from 0 to 1. This gives us two " +
                "points that move along the segments as we change the value of t from 0 to 1.\n\n" +
                "Try moving the slider below to see the Quadratic Bezier in action.";
            //SLIDER VALUE
            dotCoordinates1 = new Label();
            dotCoordinates1.Text = "Interpolation: 0";
            dotCoordinates1.Font = new Font("Segoe UI", 15);
            dotCoordinates1.Size = new Size(1000, 40);
            dotCoordinates1.Location = new Point(50, 450);
            panel1.Controls.Add(dotCoordinates1);
            //SLIDER
            slider = new HScrollBar();
            slider.Location = new Point(50, 500);
            slider.Size = new Size(500, 30);
            panel1.Controls.Add(slider);
            //DRAW DOTS
            PictureBox dotA = drawDot(100, 850, "black");
            PictureBox dotB = drawDot(400, 600, "black");
            PictureBox dotC = drawDot(900, 800, "black");
            tryDot1 = drawDot(100, 850, "blue");
            tryDot2 = drawDot(400, 600, "green");
            tryDot3 = drawDot(100, 850, "red");
            tryDot3.Size = new Size(20, 20);
            //LINES
            for (double i = 0; i < 1; i += 0.05)
            {
                PictureBox segment1 = new PictureBox();
                segment1.Location = new Point((int)(4 + 100 + 300 * i), (int)(4 + 850 - 250 * i));
                segment1.Image = Properties.Resources.BlueSquare;
                segment1.Size = new Size(3, 3);
                panel1.Controls.Add(segment1);
                PictureBox segment2 = new PictureBox();
                segment2.Location = new Point((int)(4 + 400 + 500 * i), (int)(4 + 600 + 200 * i));
                segment2.Image = Properties.Resources.GreenSquare;
                segment2.Size = new Size(3, 3);
                panel1.Controls.Add(segment2);
                int aX = 100;
                int aY = 850;
                int bX = 400;
                int bY = 600;
                int cX = 900;
                int cY = 800;
                int abX = (int)(aX + i * (bX - aX));
                int abY = (int)(aY + i * (bY - aY));
                int bcX = (int)(bX + i * (cX - bX));
                int bcY = (int)(bY + i * (cY - bY));
                int x = (int)(abX + i * (bcX - abX));
                int y = (int)(abY + i * (bcY - abY));
                PictureBox segment3 = new PictureBox();
                segment3.Location = new Point(4 + x, 4 + y);
                segment3.Image = Properties.Resources.RedSquare;
                segment3.Size = new Size(3, 3);
                panel1.Controls.Add(segment3);
            }
            //TEXT 3
            Label bcpText3 = describer(1200, 50);
            //ANIMATE
            animating5 = true;
            BackgroundWorker bw5 = new BackgroundWorker();
            bw5.DoWork += new DoWorkEventHandler(bw5_DoWork5);
            bw5.RunWorkerAsync();
            return;
        }

        private void bw5_DoWork5(object sender, DoWorkEventArgs e)
        {
            while (animating5)
            {
                double lerp = (slider.Value / 91.0) * 100;
                lerp = ((int)lerp) / 100.0;
                dotCoordinates1.Text = "Interpolation: " + lerp;
                int aX = 100;
                int aY = 850;
                int bX = 400;
                int bY = 600;
                int cX = 900;
                int cY = 800;
                int abX = (int)(aX + lerp * (bX - aX));
                int abY = (int)(aY + lerp * (bY - aY));
                int bcX = (int)(bX + lerp * (cX - bX));
                int bcY = (int)(bY + lerp * (cY - bY));
                int x = (int)(abX + lerp * (bcX - abX));
                int y = (int)(abY + lerp * (bcY - abY));
                int baseY = title.Location.Y;
                tryDot1.Location = new Point(abX, abY + baseY);
                tryDot2.Location = new Point(bcX, bcY + baseY);
                tryDot3.Location = new Point(x, y + baseY);
                Thread.Sleep(10);
            }
            return;
        }

        private void startactivityBtn_Click(object sender, EventArgs e)
        {
            if (selectedLesson == "Vector Math")
            {
                return;
            }
            animating1 = false;
            animating2 = false;
            animating3 = false;
            animating4 = false;
            animating5 = false;
            panel1.Controls.Clear();
            //HIDE COURSE BUTTONS
            vectormathBtn.Visible = false;
            coordinatesystemsBtn.Visible = false;
            advancedvectormathBtn.Visible = false;
            matricesandtransformsBtn.Visible = false;
            interpolationBtn.Visible = false;
            bezierscurvesandpathsBtn.Visible = false;
            startactivityBtn.Visible = false;
            documentationBtn.Visible = false;
            panel1.Location = new Point(600, 52);
            panel1.Size = new Size(1657, 800);
            backBtn.Location = new Point(1793, 12);
            backBtn.Visible = true;
            runBtn.Visible = true;
            runBtn.Location = new Point(200, 900);
            //EDITOR, OUTPUT, AND INSTRUCTIONS
            editor = new RichTextBox();
            editor.Location = new Point(10, 60);
            editor.Size = new Size(500, 800);
            editor.Font = new Font("Segoe UI", 10);
            this.Controls.Add(editor);
            output = new ListBox();
            output.Location = new Point(600, 880);
            output.Size = new Size(1200, 100);
            output.Font = new Font("Segoe UI", 10);
            this.Controls.Add(output);
            instruct();
            //ACTIVITY ENVIRONMENT
            switch (selectedLesson)
            {
                case "Coordinate Systems":
                    editor.Text = "tankX = 800\ntankY = 200\nrobotX = 200\nrobotY = 500\n\nx = ?\ny = ?";
                    coordinatesystemsActivity(800, 200, 200, 500);
                    break;
                case "Advanced Vector Math":
                    editor.Text = "playerX = 800\nplayerY = 200\nzombieX = 200\nzombieY = 500\n" +
                        "pointingX = playerX - zombieX\npointingY = playerY - zombieY\nfacingX = 1\nfacingY = 0\n\n" +
                        "DotProduct = ?";
                    advancedvectormathActivity(800, 200, 200, 500, 1, 0);
                    break;
                case "Matrices and Transforms":
                    editor.Text = "matrix = {}\n" +
                        "matrix[1] = { }\n" +
                        "matrix[2] = { }\n" +
                        "matrix[1][1] = 0\n" +
                        "matrix[1][2] = -1\n" +
                        "matrix[2][1] = 1\n" +
                        "matrix[2][2] = 0\n" +
                        "\n" +
                        "oldCircle = { }\n" +
                        "oldCircle[1] = 800\n" +
                        "oldCircle[2] = 500\n" +
                        "oldSquare = { }\n" +
                        "oldSquare[1] = 300\n" +
                        "oldSquare[2] = 400\n" +
                        "newCircle = { }\n" +
                        "newSquare = { }\n" +
                        "\n" +
                        "newCircle[1] = matrix[?][?] * oldCircle[?] +\n" +
                        "matrix[?][?] * oldCircle[?]\n" +
                        "\n" +
                        "newCircle[2] = matrix[?][?] * oldCircle[?] +\n" +
                        "matrix[?][?] * oldCircle[?]\n" +
                        "\n" +
                        "newSquare[1] = ?\n" +
                        "\n" +
                        "newSquare[2] = ?\n" +
                        "\n" +
                        "circleX = newCircle[1] + 1000\n" +
                        "circleY = newCircle[2] - 200\n" +
                        "squareX = newSquare[1] + 1000\n" +
                        "squareY = newSquare[2] - 200";
                    matricesandtransformsActivity(800, 500, 300, 400);
                    break;
                case "Interpolation":
                    editor.Text = "aX = 200\naY = 600\nbX = 800\nbY = 200\n\nlerp = ?\n\ncircleX = ?\ncircleY = ?";
                    interpolationActivity(200, 600, 800, 200, 0.25, 350, 350);
                    break;
                case "Beziers, Curves, and Paths":
                    editor.Text = "aX = 100\naY = 500\nbX = 400\nbY = 100\ncX = 900\ncY = 600\n\nlerp = 0.5\n\n" +
                        "abX = ?\nabY = ?\nbcX = ?\nbcY = ?\n\nx = ?\ny = ?";
                    instructions.Text = "Complete the code to draw any Quadratic Bezier Curve you want.";
                    break;
            }
            return;
        }

        private void instruct()
        {
            instructions = new Label();
            instructions.Location = new Point(0, 10);
            instructions.Size = new Size(1200, 100);
            instructions.Font = new Font("Segoe UI", 10);
            panel1.Controls.Add(instructions);
            return;
        }

        private void coordinatesystemsActivity(int tankX, int tankY, int robotX, int robotY)
        {
            instructions.Text = "In this scenario, you have a tank that wishes to point its turret at a " +
                "robot. Subtracting the tank's position from the robot's position gives the vector " +
                "pointing from the tank to the robot.";
            spriteA = new PictureBox();
            spriteA.Location = new Point(tankX, tankY);
            spriteA.Size = new Size(150, 150);
            spriteA.SizeMode = PictureBoxSizeMode.Zoom;
            spriteA.Image = Properties.Resources.RedTank;
            panel1.Controls.Add(spriteA);
            Label tankPos = new Label();
            tankPos.Location = new Point(tankX + 30, tankY + 180);
            tankPos.Text = "(" + tankX + ", " + tankY + ")";
            panel1.Controls.Add(tankPos);
            spriteB = new PictureBox();
            spriteB.Location = new Point(robotX, robotY);
            spriteB.Size = new Size(200, 200);
            spriteB.SizeMode = PictureBoxSizeMode.Zoom;
            spriteB.Image = Properties.Resources.YellowRobot;
            panel1.Controls.Add(spriteB);
            Label robotPos = new Label();
            robotPos.Location = new Point(robotX + 60, robotY + 220);
            robotPos.Text = "(" + robotX + ", " + robotY + ")";
            panel1.Controls.Add(robotPos);
            return;
        }

        private void advancedvectormathActivity(int playerX, int playerY, int zombieX, int zombieY, int facingX, int facingY)
        {
            instructions.Text = "We can use the dot product to detect whether an object is facing toward another " +
                "object. Below, the player is trying to avoid the zombie. Assuming a zombie's field of view is " +
                "180 degrees, can they see the player?";
            spriteA = new PictureBox();
            spriteA.Location = new Point(playerX, playerY);
            spriteA.Size = new Size(180, 180);
            spriteA.SizeMode = PictureBoxSizeMode.Zoom;
            spriteA.Image = Properties.Resources.PlayerSprite;
            panel1.Controls.Add(spriteA);
            Label playerPos = new Label();
            playerPos.Location = new Point(playerX + 50, playerY + 190);
            playerPos.Text = "(" + playerX + ", " + playerY + ")";
            panel1.Controls.Add(playerPos);
            spriteB = new PictureBox();
            spriteB.Location = new Point(zombieX, zombieY);
            spriteB.Size = new Size(200, 200);
            spriteB.SizeMode = PictureBoxSizeMode.Zoom;
            spriteB.Image = Properties.Resources.ZombieSprite;
            panel1.Controls.Add(spriteB);
            Label zombiePos = new Label();
            zombiePos.Location = new Point(zombieX + 60, zombieY + 200);
            zombiePos.Text = "(" + zombieX + ", " + zombieY + ")";
            panel1.Controls.Add(zombiePos);
            for (double i = 0; i < 1; i += 0.025)
            {
                PictureBox segment = new PictureBox();
                segment.Location = new Point((int)(zombieX + 100 + 500 * facingX * i), (int)(zombieY + 100 + 500 * facingY * i));
                segment.Image = Properties.Resources.RedSquare;
                segment.Size = new Size(3, 3);
                panel1.Controls.Add(segment);
            }
            if (facingX < 0)
            {
                System.Drawing.Image imgZombie = spriteB.Image;
                imgZombie.RotateFlip(RotateFlipType.RotateNoneFlipX);
                spriteB.Image = imgZombie;
            }
            else if (facingX == 0 && facingY > 0)
            {
                System.Drawing.Image imgZombie = spriteB.Image;
                imgZombie.RotateFlip(RotateFlipType.Rotate90FlipNone);
                spriteB.Image = imgZombie;
            }
            else if (facingX == 0 && facingY < 0)
            {
                System.Drawing.Image imgZombie = spriteB.Image;
                imgZombie.RotateFlip(RotateFlipType.Rotate90FlipNone);
                imgZombie.RotateFlip(RotateFlipType.Rotate180FlipNone);
                spriteB.Image = imgZombie;
            }
            return;
        }

        private void matricesandtransformsActivity(int circleX, int circleY, int squareX, int squareY)
        {
            instructions.Text = "Use matrix multiplication to rotate a circle and a square around a center.";
            spriteA = new PictureBox();
            spriteA.Location = new Point(circleX, circleY);
            spriteA.Size = new Size(150, 150);
            spriteA.SizeMode = PictureBoxSizeMode.Zoom;
            spriteA.Image = Properties.Resources.GreenCircle;
            panel1.Controls.Add(spriteA);
            Label circlePos = new Label();
            circlePos.Location = new Point(circleX + 40, circleY + 160);
            circlePos.Text = "(" + circleX + ", " + circleY + ")";
            panel1.Controls.Add(circlePos);
            spriteB = new PictureBox();
            spriteB.Location = new Point(squareX, squareY);
            spriteB.Size = new Size(150, 150);
            spriteB.SizeMode = PictureBoxSizeMode.Zoom;
            spriteB.Image = Properties.Resources.BlueSquare;
            panel1.Controls.Add(spriteB);
            Label squarePos = new Label();
            squarePos.Location = new Point(squareX + 40, squareY + 160);
            squarePos.Text = "(" + squareX + ", " + squareY + ")";
            panel1.Controls.Add(squarePos);
            return;
        }

        private void interpolationActivity(int aX, int aY, int bX, int bY, double lerp, int circleX, int circleY)
        {
            instructions.Text = "The circle can be positioned anywhere between point A and point B. " +
                "Try setting its position to be halfway in between.";
            spriteA = new PictureBox();
            spriteA.Location = new Point(circleX, circleY);
            spriteA.Size = new Size(50, 50);
            spriteA.SizeMode = PictureBoxSizeMode.Zoom;
            spriteA.Image = Properties.Resources.RedCircle;
            panel1.Controls.Add(spriteA);
            Label circlePos = new Label();
            circlePos.Location = new Point(circleX - 10, circleY + 60);
            circlePos.Text = "(" + circleX + ", " + circleY + ")";
            panel1.Controls.Add(circlePos);
            Label pointA = new Label();
            pointA.Location = new Point(aX, aY);
            pointA.Text = "A (" + aX + ", " + aY + ")";
            panel1.Controls.Add(pointA);
            Label pointB = new Label();
            pointB.Location = new Point(bX, bY);
            pointB.Text = "B (" + bX + ", " + bY + ")";
            panel1.Controls.Add(pointB);
            return;
        }

        private void bezierscurvesandpathsActivity(int aX, int aY, int bX, int bY, int cX, int cY, double lerp, int circleX, int circleY)
        {
            instructions.Text = "bezier";
            PictureBox pointA = drawDot(aX, aY, "red");
            pointA.Size = new Size(20, 20);
            PictureBox pointB = drawDot(bX, bY, "green");
            pointB.Size = new Size(20, 20);
            PictureBox pointC = drawDot(cX, cY, "blue");
            pointC.Size = new Size(20, 20);
            spriteA = new PictureBox();
            spriteA.Location = new Point(circleX, circleY);
            spriteA.Size = new Size(50, 50);
            spriteA.SizeMode = PictureBoxSizeMode.Zoom;
            spriteA.Image = Properties.Resources.BlackCircle;
            panel1.Controls.Add(spriteA);
            return;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            //LUA
            switch (selectedLesson)
            {
                case "Coordinate Systems":
                    try
                    {
                        state.DoString(editor.Text);
                        output.Items.Clear();
                        int tankX = Int32.Parse(state["tankX"].ToString());
                        int tankY = Int32.Parse(state["tankY"].ToString());
                        int robotX = Int32.Parse(state["robotX"].ToString());
                        int robotY = Int32.Parse(state["robotY"].ToString());
                        int x = Int32.Parse(state["x"].ToString());
                        int y = Int32.Parse(state["y"].ToString());
                        bool positive = tankX >= 0 && tankY >= 0 && robotX >= 0 && robotY >= 0;
                        if (positive && x == robotX - tankX && y == robotY - tankY)
                        {
                            panel1.Controls.Clear();
                            instruct();
                            coordinatesystemsActivity(tankX, tankY, robotX, robotY);
                            output.Items.Add("Correct!");
                            for (double i = 0; i < 1; i += 0.025)
                            {
                                PictureBox segment = new PictureBox();
                                segment.Location = new Point((int)(tankX + 100 + x * i), (int)(tankY + 100 + y * i));
                                segment.Image = Properties.Resources.RedSquare;
                                segment.Size = new Size(3, 3);
                                panel1.Controls.Add(segment);
                            }
                        }
                        else
                        {
                            output.Items.Clear();
                            output.Items.Add("Wrong!");
                        }
                    }
                    catch (NLua.Exceptions.LuaScriptException ex)
                    {
                        output.Items.Add(ex.Message);
                    }
                    break;
                case "Advanced Vector Math":
                    try
                    {
                        state.DoString(editor.Text);
                        output.Items.Clear();
                        int playerX = Int32.Parse(state["playerX"].ToString());
                        int playerY = Int32.Parse(state["playerY"].ToString());
                        int zombieX = Int32.Parse(state["zombieX"].ToString());
                        int zombieY = Int32.Parse(state["zombieY"].ToString());
                        int pointingX = Int32.Parse(state["pointingX"].ToString());
                        int pointingY = Int32.Parse(state["pointingY"].ToString());
                        int facingX = Int32.Parse(state["facingX"].ToString());
                        int facingY = Int32.Parse(state["facingY"].ToString());
                        int dotProductAnswer = Int32.Parse(state["DotProduct"].ToString());
                        int dotProductKey = pointingX * facingX + pointingY * facingY;
                        bool positive = playerX >= 0 && playerY >= 0 && zombieX >= 0 && zombieY >= 0;
                        if (positive && dotProductAnswer == dotProductKey)
                        {
                            panel1.Controls.Clear();
                            instruct();
                            advancedvectormathActivity(playerX, playerY, zombieX, zombieY, facingX, facingY);
                            if (dotProductAnswer > 0)
                            {
                                output.Items.Add("Zombie can see Player!");
                            }
                            else
                            {
                                output.Items.Add("Zombie cannot see Player!");
                            }
                        }
                        else
                        {
                            output.Items.Clear();
                            output.Items.Add("Wrong!");
                        }
                    }
                    catch (NLua.Exceptions.LuaScriptException ex)
                    {
                        output.Items.Add(ex.Message);
                    }
                    break;
                case "Matrices and Transforms":
                    try
                    {
                        state.DoString(editor.Text);
                        output.Items.Clear();
                        int circleX = Int32.Parse(state["circleX"].ToString());
                        int circleY = Int32.Parse(state["circleY"].ToString());
                        int squareX = Int32.Parse(state["squareX"].ToString());
                        int squareY = Int32.Parse(state["squareY"].ToString());
                        panel1.Controls.Clear();
                        instruct();
                        matricesandtransformsActivity(circleX, circleY, squareX, squareY);
                        output.Items.Add("Correct!");
                    }
                    catch (NLua.Exceptions.LuaScriptException ex)
                    {
                        output.Items.Add(ex.Message);
                    }
                    break;
                case "Interpolation":
                    try
                    {
                        state.DoString(editor.Text);
                        output.Items.Clear();
                        int aX = Int32.Parse(state["aX"].ToString());
                        int aY = Int32.Parse(state["aY"].ToString());
                        int bX = Int32.Parse(state["bX"].ToString());
                        int bY = Int32.Parse(state["bY"].ToString());
                        double lerp = double.Parse(state["lerp"].ToString());
                        double circleX = double.Parse(state["circleX"].ToString());
                        double circleY = double.Parse(state["circleY"].ToString());
                        bool positive = aX >= 0 && aY >= 0 && bX >= 0 && bY >= 0;
                        if (positive && lerp >= 0 && lerp <= 1 && circleX == aX + lerp * (bX - aX) && circleY == aY + lerp * (bY - aY))
                        {
                            panel1.Controls.Clear();
                            instruct();
                            interpolationActivity(aX, aY, bX, bY, lerp, (int)circleX, (int)circleY);
                            if (lerp == 0.5)
                            {
                                output.Items.Add("Correct!");
                            }
                            else
                            {
                                output.Items.Add("Not quite halfway...but that's fine!");
                            }
                            for (double i = 0.05; i <= 0.95; i += 0.025)
                            {
                                PictureBox segment = new PictureBox();
                                segment.Location = new Point((int)(20 + aX + i * (bX - aX)), (int)(20 + aY + i * (bY - aY)));
                                if (i < lerp)
                                {
                                    segment.Image = Properties.Resources.BlueSquare;
                                }
                                else
                                {
                                    segment.Image = Properties.Resources.GreenSquare;
                                }
                                segment.Size = new Size(4, 4);
                                panel1.Controls.Add(segment);
                            }
                        }
                        else
                        {
                            output.Items.Add("Wrong!");
                        }
                    }
                    catch (NLua.Exceptions.LuaScriptException ex)
                    {
                        output.Items.Add(ex.Message);
                    }
                    break;
                case "Beziers, Curves, and Paths":
                    try
                    {
                        state.DoString(editor.Text);
                        output.Items.Clear();
                        int aX = Int32.Parse(state["aX"].ToString());
                        int aY = Int32.Parse(state["aY"].ToString());
                        int bX = Int32.Parse(state["bX"].ToString());
                        int bY = Int32.Parse(state["bY"].ToString());
                        int cX = Int32.Parse(state["cX"].ToString());
                        int cY = Int32.Parse(state["cY"].ToString());
                        double lerp = double.Parse(state["lerp"].ToString());
                        double abX = double.Parse(state["abX"].ToString());
                        double abY = double.Parse(state["abY"].ToString());
                        double bcX = double.Parse(state["bcX"].ToString());
                        double bcY = double.Parse(state["bcY"].ToString());
                        double x = double.Parse(state["x"].ToString());
                        double y = double.Parse(state["y"].ToString());
                        bool positive = aX >= 0 && aY >= 0 && bX >= 0 && bY > 0 && cX >= 0 && cY >= 0;
                        double abXkey = aX + lerp * (bX - aX);
                        double abYkey = aY + lerp * (bY - aY);
                        double bcXkey = bX + lerp * (cX - bX);
                        double bcYkey = bY + lerp * (cY - bY);
                        double xkey = abX + lerp * (bcX - abX);
                        double ykey = abY + lerp * (bcY - abY);
                        bool correct = abX == abXkey && abY == abYkey && bcX == bcXkey && bcY == bcYkey && x == xkey && y == ykey;
                        if (positive && correct)
                        {
                            panel1.Controls.Clear();
                            instruct();
                            instructions.Text = "Complete the code to draw any Quadratic Bezier Curve you want.";
                            output.Items.Add("Correct!");
                            for (double i = 0; i <= 1; i += 0.025)
                            {
                                abX = aX + i * (bX - aX);
                                abY = aY + i * (bY - aY);
                                bcX = bX + i * (cX - bX);
                                bcY = bY + i * (cY - bY);
                                x = abX + i * (bcX - abX);
                                y = abY + i * (bcY - abY);
                                PictureBox segment = new PictureBox();
                                segment.Location = new Point((int)x, (int)y);
                                segment.Image = Properties.Resources.RedCircle;
                                segment.Size = new Size(10, 10);
                                segment.SizeMode = PictureBoxSizeMode.Zoom;
                                panel1.Controls.Add(segment);
                            }
                        }
                        else
                        {
                            output.Items.Add("Wrong!");
                        }
                    }
                    catch (NLua.Exceptions.LuaScriptException ex)
                    {
                        output.Items.Add(ex.Message);
                    }
                    break;
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            backBtn.Visible = false;
            editor.Visible = false;
            output.Visible = false;
            runBtn.Visible = false;
            vectormathBtn.Visible = true;
            coordinatesystemsBtn.Visible = true;
            advancedvectormathBtn.Visible = true;
            matricesandtransformsBtn.Visible = true;
            interpolationBtn.Visible = true;
            bezierscurvesandpathsBtn.Visible = true;
            documentationBtn.Visible = true;
            panel1.Location = new Point(268, 52);
            panel1.Size = new Size(1657, 1006);
            vectormathPage();
            selectedLesson = "Vector Math";
        }

        private void documentationBtn_Click(object sender, EventArgs e)
        {
            startactivityBtn.Visible = false;
            panel1.AutoScrollPosition = new Point(0, 0);
            selectedLesson = "Documentation";
            titler(selectedLesson);
            Label dText1 = describer(70, 50);
            dText1.Text = "How To Code";
            dText1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Label dText2 = describer(120, 200);
            dText2.Text = "Initialize a variable by typing its name directly and setting its value. Variables can be set " +
                "in terms of other variables and can accommodate numbers and text. For example:\n\n" +
                "x = 5\n" +
                "y = 2 * x + 3\n" +
                "z = \"Hello World!\"\n\n" +
                "For the purposes of learning vector math, the code editor will simply fetch the variables and " +
                "execute events in the back-end.\n" +
                "Pre-set variables typically start with default values, but you can change those values to " +
                "experiment with the code.\n\n" +
                "Make sure to avoid setting variables with fractional values or decimal places. The code editor " +
                "will prefer integer values.\n\n";
            Label dText3 = describer(340, 20);
            dText3.Text = "Conditional Statements and While Loops";
            dText3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Label dText4 = describer(380, 280);
            dText4.Text = "If statements are followed by a condition and the keyword 'then'. After enclosing a body" +
                "of code, end the block with the keyword 'end'. 'Else' can also be inserted within the conditional " +
                "code. As for while loops, a condition is likewise required, followed by the main code, then 'end'.\n\n" +
                "For example:\n\n" +
                "x = 7\n" +
                "while x > 1 do\n" +
                "   if x % 2 == 0 then\n" +
                "      x = x / 2\n" +
                "   else\n" +
                "      x = (x * 3) + 1\n" +
                "   end\n" +
                "end";
            Label dText5 = describer(690, 50);
            dText5.Text = "Navigating The Platform";
            dText5.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Label dText6 = describer(740, 100);
            dText6.Text = "The course Vector Math has 5 lessons: Coordinate Systems, Advanced Vector Math, Matrices and Transforms, Interpolation, and Beziers, Curves, and Paths.\n" +
                "Navigate the course's 5 lessons using the hierarchy on the left, interact experimentally with the lesson guides, and try the activities";
        }
    }
}