using System;
using System.Drawing;
using System.Windows.Forms;

namespace ParcurgereMatrici
{
    public partial class Form1 : Form
    {
        Color[] colors = [
            Color.White,
            Color.Red,
            Color.OrangeRed,
            Color.Orange,
            Color.Yellow,
            Color.YellowGreen,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.BlueViolet
        ];
        Point colorsStartLocation = new Point(10, 10);
        Button[] colorButtons;
        PictureBox[,] matrix = new PictureBox[0, 0];

        // Am adaugat variabila asta global ca sa nu dea eroare la compilare pe constructorul tau
        int[,] matrixRotation = new int[5, 10];

        public Form1()
        {
            InitializeComponent();
            colorButtons = new Button[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                Button button = new Button();
                button.Parent = this;

                button.Size = new Size(50, 50);
                button.Location = new Point(colorsStartLocation.X + i * 55, colorsStartLocation.Y);
                button.BackColor = colors[i];
                button.BringToFront();

                button.Click += ColorButton_Click;
                colorButtons[i] = button;
            }

            Random random = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 10; j++)
                {
                    matrixRotation[i, j] = random.Next(colors.Length);
                }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                int index = Array.IndexOf(colorButtons, sender as Button);
                colors[index] = colorPicker.Color;
                (sender as Button).BackColor = colorPicker.Color;
            }
        }

        // Clear
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Parent = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Parent = null;

            string[][] textBoxText = new string[textBox1.Lines.Length][];
            for (int i = 0; i < textBox1.Lines.Length; i++)
                textBoxText[i] = textBox1.Lines[i].Split(' ');

            int n = textBoxText.Length;
            int m = textBoxText[0].Length;
            matrix = new PictureBox[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = new PictureBox();
                    matrix[i, j].Parent = pictureBox1;

                    int sizeX = pictureBox1.Width / m, sizeY = pictureBox1.Height / n;
                    matrix[i, j].Size = new Size(sizeX, sizeY);
                    matrix[i, j].Location = new Point(j * sizeX, i * sizeY);

                    int index = int.Parse(textBoxText[i][j]) % colors.Length;
                    matrix[i, j].BackColor = colors[index];
                }
        }

        private void AddMatrixToTextBox(int[,] matrix, int n, int m)
        {
            textBox1.Text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                    textBox1.Text += matrix[i, j] + " ";
                textBox1.Text += matrix[i, m - 1];
                if (i < n - 1)
                    textBox1.Text += Environment.NewLine;
            }
        }

        // Mijloace
        private void button2_Click(object sender, EventArgs e)
        {
            int n = 11;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                matrix[i, n / 2] = 1;
                matrix[n / 2, i] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Diagonale
        private void button3_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1;
                matrix[i, n - i - 1] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Mijloace si diagonale
        private void button6_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                matrix[i, n / 2] = 1;
                matrix[n / 2, i] = 1;
                matrix[i, i] = 1;
                matrix[i, n - i - 1] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // NSEV
        private void button5_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n / 2; i++)
                for (int j = i + 1; j < n - i - 1; j++)
                {
                    matrix[i, j] = 1;           // Nord
                    matrix[j, n - i - 1] = 4;   // Est
                    matrix[n - i - 1, j] = 6;   // Sud
                    matrix[j, i] = 7;           // Vest
                }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Rotire 90 grade
        private void button8_Click(object sender, EventArgs e)
        {
            int n = 5;
            int[,] matrix = new int[2 * n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i + j + 1;
                    matrix[n + i, j] = i + j + 1;
                }

            for (int i = 0; i < 2 * n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrixRotation[j, 2 * n - i - 1] = matrix[i, j];
                }

            AddMatrixToTextBox(matrixRotation, n, 2 * n);
        }

        // Spirala
        private void button4_Click(object sender, EventArgs e)
        {
            int n = 12;
            int[,] matrix = new int[n, n];
            int value = 1;

            for (int k = 0; k < n / 2; k++)
            {
                for (int i = k; i < n - k - 1; i++)
                    matrix[k, i] = value;
                value++;

                for (int i = k; i < n - k - 1; i++)
                    matrix[i, n - k - 1] = value;
                value++;

                for (int i = k; i < n - k - 1; i++)
                    matrix[n - k - 1, n - i - 1] = value;
                value++;

                for (int i = k; i < n - k - 1; i++)
                    matrix[n - i - 1, k] = value;
                value++;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Serpuit
        private void button7_Click(object sender, EventArgs e)
        {
            int value = 0;
            int n = 13;
            int[,] matrix = new int[n, n];
            bool upDirection = true;

            for (int diagonalSize = 1; diagonalSize <= n; diagonalSize++)
            {
                if (upDirection)
                    TraverseUpwards(matrix, diagonalSize, value);
                else
                    TraverseDownwards(matrix, diagonalSize, value);

                value++;
                upDirection = !upDirection;
            }

            for (int diagonalSize = n - 1; diagonalSize > 0; diagonalSize--)
            {
                if (upDirection)
                    TraverseUpwards(matrix, diagonalSize, value, true);
                else
                    TraverseDownwards(matrix, diagonalSize, value, true);

                value++;
                upDirection = !upDirection;
            }

            AddMatrixToTextBox(matrix, n, n);
        }
        private void TraverseUpwards(int[,] matrix, int diagonalSize, int value, bool isSecondHalf = false)
        {
            int i = diagonalSize - 1;
            int j = 0;
            if (isSecondHalf)
            {
                i = matrix.GetLength(0) - 1;
                j = matrix.GetLength(1) - diagonalSize;
            }

            while (diagonalSize > 0)
            {
                matrix[i, j] = value;
                i--; j++;
                diagonalSize--;
            }
        }
        private void TraverseDownwards(int[,] matrix, int diagonalSize, int value, bool isSecondHalf = false)
        {
            int i = 0;
            int j = diagonalSize - 1;
            if (isSecondHalf)
            {
                i = matrix.GetLength(0) - diagonalSize;
                j = matrix.GetLength(1) - 1;
            }

            while (diagonalSize > 0)
            {
                matrix[i, j] = value;
                i++; j--;
                diagonalSize--;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // =======================================================
        // Star
        // =======================================================
        private void button9_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];
            int mid = n / 2;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // 1. Desenam "scheletul" steagului:
                    // Diagonala principala, secundara, linia de mijloc si coloana de mijloc
                    // primesc valoarea 0 (Culoarea de baza / de separare, ex: Alb)
                    if (i == j || i + j == n - 1 || i == mid || j == mid)
                    {
                        matrix[i, j] = 0;
                    }
                    // 2. Impartim spatiul ramas in 8 "felii" de triunghi (Cadranul Stanga-Sus)
                    else if (i < mid && j < mid)
                    {
                        if (i < j) matrix[i, j] = 1; // Triunghiul de sus
                        else matrix[i, j] = 8;       // Triunghiul din stanga
                    }
                    // Cadranul Dreapta-Sus
                    else if (i < mid && j > mid)
                    {
                        if (i + j < n - 1) matrix[i, j] = 2; // Triunghiul de sus 
                        else matrix[i, j] = 3;               // Triunghiul din dreapta
                    }
                    // Cadranul Dreapta-Jos
                    else if (i > mid && j > mid)
                    {
                        if (i < j) matrix[i, j] = 4; // Triunghiul de jos
                        else matrix[i, j] = 5;       // Triunghiul din dreapta
                    }
                    // Cadranul Stanga-Jos
                    else if (i > mid && j < mid)
                    {
                        if (i + j > n - 1) matrix[i, j] = 6; // Triunghiul de jos
                        else matrix[i, j] = 7;               // Triunghiul din stanga  
                    }
                }
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        //UK Flag
        private void button10_Click_1(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];
            int mid = n / 2;

            // 1. Umplem toata matricea cu 7 (Culoarea de fundal, ex: Albastru)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = 7;

            // 2. Desenam marginile groase ale diagonalelor (Grosime 3 - folosind Math.Abs <= 1)
            // Orice se afla langa diagonale primeste 0 (Culoarea de contur, ex: Alb)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (Math.Abs(i - j) <= 1 || Math.Abs(i + j - (n - 1)) <= 1)
                        matrix[i, j] = 0;

            // 3. Pe mijlocul diagonalelor groase de mai sus, punem inapoi 1 (Culoarea stelei, ex: Rosu)
            // Asta creeaza efectul de diagonala rosie inconjurata de contur alb
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        if (i < mid && j < mid)
                        {
                            if (i == j) matrix[i, j] = 1;
                        }
                        else if (i < mid && j > mid)
                        {
                            if (i + j == n - 1) matrix[i, j] = 1;
                        }
                        else if (i > mid && j < mid)
                        {
                            if (i + j == n - 1) matrix[i, j] = 1;
                        }
                        else if (i > mid && j > mid)
                        {
                            if (i == j) matrix[i, j] = 1;
                        }
                    }
                }
            }

            // 4. Desenam crucea mare de pe mijloc (Linii si coloane). 
            // Grosime imensa de 5 elemente (Math.Abs <= 2)
            // Umplem cu 0 (Alb) ca sa spargem fundalul albastru in 4 colturi mici


            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (Math.Abs(i - mid) <= 2 || Math.Abs(j - mid) <= 2)
                        matrix[i, j] = 0;

            // 5. Pe interiorul crucii albe de mai sus, redesenam o cruce mai subtire (grosime 3)
            // cu valoarea 1 (Rosu). Asta completeaza forma stelei cu contururi perfecte!
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (Math.Abs(i - mid) <= 1 || Math.Abs(j - mid) <= 1)
                        matrix[i, j] = 1;

            AddMatrixToTextBox(matrix, n, n);
        }

    }
}