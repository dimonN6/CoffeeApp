using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Form1 : Form
    {
        private Image[] images;
        private int[] currentOrder;
        private int errorCount = 0;
        private bool blocked = false;
        private PictureBox dragSource = null;

        public Form1()
        {
            InitializeComponent();
            if (!LoadImagesFromFolder())
            {
                MessageBox.Show("Не найдены картинки в папке Images/\n" +
                                "Требуются файлы: 1.png, 2.png, 3.png, 4.png",
                                "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            foreach (var pb in boxes)
            {
                pb.MouseDown += PictureBox_MouseDown;
                pb.DragEnter += PictureBox_DragEnter;
                pb.DragDrop += PictureBox_DragDrop;
            }
            btnCheck.Click += BtnCheck_Click;
            ShuffleAndLoadImages();
        }

        private bool LoadImagesFromFolder()
        {
            images = new Image[4];
            string folder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(folder))
                return false;

            for (int i = 0; i < 4; i++)
            {
                string filePath = Path.Combine(folder, $"{i + 1}.png");
                if (File.Exists(filePath))
                    images[i] = Image.FromFile(filePath);
                else
                    return false;
            }
            return true;
        }

        private void ShuffleAndLoadImages()
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            currentOrder = new int[] { 1, 2, 3, 4 };
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = rnd.Next(i, 4);
                int temp = currentOrder[i];
                currentOrder[i] = currentOrder[j];
                currentOrder[j] = temp;
            }

            bool isCorrect = true;
            for (int i = 0; i < 4; i++)
                if (currentOrder[i] != i + 1) { isCorrect = false; break; }
            if (isCorrect)
            {
                int temp = currentOrder[0];
                currentOrder[0] = currentOrder[1];
                currentOrder[1] = temp;
            }

            for (int i = 0; i < 4; i++)
            {
                int imageIndex = currentOrder[i] - 1;
                boxes[i].Image = images[imageIndex];
                boxes[i].Tag = i;
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (blocked) return;
            dragSource = sender as PictureBox;
            if (dragSource != null)
                dragSource.DoDragDrop(dragSource, DragDropEffects.Move);
        }

        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (blocked)
                e.Effect = DragDropEffects.None;
            else if (e.Data.GetDataPresent(typeof(PictureBox)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (blocked) return;

            PictureBox target = sender as PictureBox;
            PictureBox source = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            if (source == null || target == null || source == target) return;

            int srcIdx = (int)source.Tag;
            int tgtIdx = (int)target.Tag;

            Image tempImg = source.Image;
            source.Image = target.Image;
            target.Image = tempImg;

            int tempOrder = currentOrder[srcIdx];
            currentOrder[srcIdx] = currentOrder[tgtIdx];
            currentOrder[tgtIdx] = tempOrder;
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (blocked)
            {
                MessageBox.Show("Пазл заблокирован. Перезапустите приложение.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isCorrect = true;
            for (int i = 0; i < 4; i++)
                if (currentOrder[i] != i + 1) { isCorrect = false; break; }

            if (isCorrect)
            {
                MessageBox.Show("Пазл собран правильно! Переход к авторизации.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenLoginForm();
            }
            else
            {
                errorCount++;
               
                MessageBox.Show($"Неправильный порядок! Ошибок: {errorCount}/3", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (errorCount >= 3)
                {
                    blocked = true;
                    btnCheck.Enabled = false;
                    PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
                    foreach (var pb in boxes)
                        pb.Enabled = false;
                   
                    MessageBox.Show("Вы набрали 3 ошибки. Пазл заблокирован.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void OpenLoginForm()
        {
            Form2 login = new Form2();
            login.Show();
            this.Hide();
        }
    }
}