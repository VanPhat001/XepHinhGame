using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformAppConsole_
{
    public partial class Form1 : Form
    {
        #region Properties
        PictureBox tempPtb = null;
        List<Button> btnBoard;
        Point imgStartPoint = new Point(-1, -1);
        int index = -1;
        int countTrueIndex = 0;
        int row = 10;
        int col = 10;
        const int maxWidth = 500;
        const int maxHeight = 500;
        #endregion

        public Form1()
        {
            InitializeComponent();

            btnBoard = new List<Button>();

            InitGame();
        }

        #region Events  
        private void Ptb_MouseMove(object sender, MouseEventArgs e)
        {
            if (tempPtb != null)
            {
                Point poitntoclient = PointToClient(MousePosition);

                tempPtb.Location = new Point(poitntoclient.X - pnlChessBoard.Location.X, poitntoclient.Y - pnlChessBoard.Location.Y);

                foreach (var btn in btnBoard)
                {
                    if (InRange(tempPtb.Location.X, tempPtb.Location.Y, btn.Location, btn.Width, btn.Height))
                    {
                        index = (int)btn.Tag;
                        return;
                    }
                }

                index = -1;
            }
        }

        private void Ptb_MouseUp(object sender, MouseEventArgs e)
        {
            if (index != -1)
            {
                tempPtb.Location = btnBoard[index].Location;

                if (index == (int)tempPtb.Tag)
                {
                    countTrueIndex++;
                    if (countTrueIndex == row * col)
                    {
                        MessageBox.Show("Trò chơi kết thúc!");

                        SetAllControl(false);
                    }
                }
            }
            else
            {
                // trả về vị trí ban đầu
                tempPtb.Location = imgStartPoint;
            }

            // trạng thái huỷ
            tempPtb = null;
            index = -1;
        }

        private void Ptb_MouseDown(object sender, MouseEventArgs e)
        {
            tempPtb = sender as PictureBox;
            imgStartPoint = (sender as PictureBox).Location;
            index = -1;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllControl(true);
            InitGame();
        }

        private void tstxb_imgSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                mns_newGame.PerformClick();
            }
        }
        #endregion


        #region Methods
        void InitGame()
        {
            try
            {
                row = int.Parse(txbRow.Text);
                col = int.Parse(txbCol.Text);
            }
            catch { }

            if (row * col > 1500)
            {
                MessageBox.Show("Không thể cắt ảnh vượt qua mức 1500!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            countTrueIndex = 0;
            pnlChessBoard.Controls.Clear();

            try
            {
                Image img = Image.FromFile(tstxb_imgSource.Text); 

                if (img.Width > maxWidth || img.Height > maxHeight)
                {
                    MessageBox.Show("Kích thước hình ảnh quá lớn! Vui lòng chọn ảnh có kích thước tối đa là 500x500", "Lỗi tải hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                CreateImageBoard(img);
                CreateButtonBoard(img.Width, img.Height);
            }
            catch 
            {
                MessageBox.Show("Hình ảnh không tồn tại! Yêu cầu xem lại đường dẫn!", "Lỗi tải hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

        void SetAllControl(bool enable)
        {
            foreach (var item in pnlChessBoard.Controls)
            {
                try
                {
                    if ((item as Button) != null)
                    {
                        (item as Button).Enabled = enable;
                    }
                    else if ((item as PictureBox) != null)
                    {
                        (item as PictureBox).Enabled = enable;
                    }
                }
                catch
                {

                }
            }
        }

        bool InRange(int x, int y, Point startPoint, int width, int height)
        {
            return startPoint.X <= x && x <= startPoint.X + width && startPoint.Y <= y && y <= startPoint.Y + height;
        }

        Bitmap DropImage(Image img, int X, int Y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(X, Y, width, height), GraphicsUnit.Pixel);
            g.Dispose();

            return bmp;
        }

        List<Thongtin> SplitImage(Image img, int row, int col)
        {
            List<Thongtin> ptbList = new List<Thongtin>();

            int cutHeight = (int)(img.Height * 1.0 / row);
            int cutWidth = (int)(img.Width * 1.0 / col);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Point p = new Point(j * cutWidth, i * cutHeight);

                    PictureBox ptb = new PictureBox()
                    {
                        Image = DropImage(img, p.X, p.Y, cutWidth, cutHeight),
                        Width = cutWidth,
                        Height = cutHeight,
                        Tag = i * col + j,
                        //Location = new Point(p.X + j, p.Y + i)
                    };

                    ptb.MouseDown += Ptb_MouseDown;
                    ptb.MouseUp += Ptb_MouseUp;
                    ptb.MouseMove += Ptb_MouseMove;

                    ptbList.Add(new Thongtin(ptb, i * col + j));
                }
            }

            return ptbList;
        }

        void CreateImageBoard(Image img)
        {
            int cutHeight = (int)(img.Height * 1.0 / row);
            int cutWidth = (int)(img.Width * 1.0 / col);
            List<Thongtin> temp = SplitImage(img, row, col);
            List<Thongtin> map = new List<Thongtin>();

            Random rand = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int index = rand.Next(temp.Count);
                    Thongtin t = temp[index];
                    t.Ptb.Location = new Point(j * (cutWidth + 1), i * (cutHeight + 1));
                    map.Add(t);
                    temp.RemoveAt(index);
                }
            }

            foreach (var item in map)
            {
                pnlChessBoard.Controls.Add(item.Ptb);
            }
        }

        void CreateButtonBoard(int imgWidth, int imgHeight)
        {
            btnBoard.Clear();

            int cutHeight = (int)(imgHeight * 1.0 / row);
            int cutWidth = (int)(imgWidth * 1.0 / col);

            Point startPoint = new Point(pnlChessBoard.Width - imgWidth, 0);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Button btn = new Button()
                    {
                        Width = cutWidth,
                        Height = cutHeight,
                        Tag = i * col + j,
                        Location = new Point(startPoint.X + j * cutWidth, startPoint.Y + i * cutHeight)
                    };

                    btnBoard.Add(btn);
                    pnlChessBoard.Controls.Add(btn);
                }
            }

        }
        #endregion

    }

    public class Thongtin
    {
        public PictureBox Ptb { get; set; }
        public int Index { get; set; }

        public Thongtin(PictureBox ptb, int index)
        {
            this.Ptb = ptb;
            this.Index = index;
        }
    }
}
