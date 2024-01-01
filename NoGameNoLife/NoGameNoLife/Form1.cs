using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace NoGameNoLife
{
    public partial class Form1 : Form
    {
        #region 参数
        //全局
        bool[,] map;//存储整个世界地图
        int maplength = 2500;//世界地图的长度
        int interval = 500;//时钟刷新间隔
        int length = 750;//画布长度
        int size = 5;//单个细胞大小
        int count;//每行每列细胞数量
        int x = 1250;//地图中心x坐标
        int y = 1250;//地图中心y坐标
        int percent = 5;//生成细胞的概率
        //状态
        bool edit = false;//是否编辑状态
        bool slidepaint = false;//移动绘制
        int gen = 0;//繁衍代数
        #endregion
        #region 初始化
        public Form1()
        {
            InitializeComponent();
            Init();
            ForBeginner();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //添加概率调整项
            probability.Items.Clear();
            for (int i = 0; i <= 9; i++) probability.Items.Add(i.ToString());
            probability.SelectedIndex = 6;
            //添加细胞尺寸调整项
            cellsize.Items.Clear();
            string[] sizelist = { "1", "5", "10", "15", "20", "25", "30" };
            cellsize.Items.AddRange(sizelist);
            cellsize.SelectedIndex = 1;
            //速度条调整
            speed.Maximum = 1000;
            speed.Minimum = 1;
            speed.SmallChange = 10;
            speed.TabIndex = 13;
            speed.Value = 500;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            //创建空白画布
            draw();
        }
        public void ForBeginner()//游戏介绍
        {
            MessageBox.Show("生命游戏是英国数学家约翰·何顿·康威在1970年发明的细胞自动机。\n 它最初于1970年10月在《科学美国人》杂志上发布。","需要知道的规则",MessageBoxButtons.OK);
            MessageBox.Show("作为一个模拟仿真游戏你有几个要记住的规则。", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("每个细胞有两种状态 - 存活或死亡，每个细胞与以自身为中心的周围八格细胞产生互动（如图，黑色为存活，白色为死亡）", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("当前细胞为存活状态时，当周围的存活细胞低于2个时（不包含2个），该细胞变成死亡状态。（模拟生命数量稀少）", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("当前细胞为存活状态时，当周围有2个或3个存活细胞时，该细胞保持原样。", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("当前细胞为存活状态时，当周围有超过3个存活细胞时，该细胞变成死亡状态。（模拟生命数量过多）", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("当前细胞为死亡状态时，当周围有3个存活细胞时，该细胞变成存活状态。（模拟繁殖）", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("记住了吗？没记住也没关系。\n我会把它张贴在游戏内。", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("总之，现在开始创造你的第一个生命吧！", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("哦对了,还有一件事", "需要知道的规则", MessageBoxButtons.OK);
            MessageBox.Show("\"我是上帝,你也是\"\n----雷善水", "需要知道的规则", MessageBoxButtons.OK);
        }
        public void Init()//初始化
        {
            //参数初始化
            timer.Interval = interval;//初始化时钟间隔
            count = length / size;//计算细胞数量
            map = new bool[maplength, maplength];//初始化世界地图
            int sumcount = 0;
            //控件初始化
            GameStart.Enabled = true;//推演
            GameStop.Enabled = false;//停止推演
            EditStart.Enabled = true;//开始编辑
            EditEnd.Enabled = false;//停止编辑
            label.Text = $"整体存活细胞:{sumcount}";//细胞数
            //地图初始化
            for (int i = 0; i < maplength; i++)
                for (int j = 0; j < maplength; j++)
                    map[i, j] = false;
        }
        #endregion
        #region 核心功能函数_衍化
        public void draw()//绘制
        {
            Bitmap myImage = new Bitmap(length, length);//建立像素画布
            Graphics g = Graphics.FromImage(myImage);//建立graphics类，从而对map进行更改
            g.Clear(Color.White);//清空
            int cellcount = 0;//活细胞数
            lock (map)//统一刷新
            {
                for (int i = x - count / 2; i < x + count / 2; i++)//绘制
                {
                    for (int j = y - count / 2; j < y + count / 2; j++)
                    {
                        if (map[i, j])
                        {
                            g.FillRectangle(Brushes.Black, (i - x + count / 2) * size, (j - y + count / 2) * size, size, size);
                            cellcount++;//统计细胞数
                        }
                    }
                }
            }
            g.Dispose();//释放graphic类，节约内存，聊胜于无
            Graphics g2 = this.panel.CreateGraphics();//绘制到panel上
            g2.DrawImage(myImage, 0, 0);

        }
        public void nextgen()//繁衍函数
        {
            int[,] count = new int[maplength + 2, maplength + 2];//单个细胞周边细胞数计数
            int sumcount = 0;
            for (int i = 0; i < maplength; i++)//遍历
            {
                for (int j = 0; j < maplength; j++)
                {
                    if (map[i, j])//若存活，周围的细胞的“周围细胞数”均增一
                    {
                        count[i, j]++; count[i, j + 1]++; count[i, j + 2]++;
                        count[i + 1, j]++; count[i + 1, j + 2]++;
                        count[i + 2, j]++; count[i + 2, j + 1]++; count[i + 2, j + 2]++;
                        sumcount++;
                    }
                }
            }
            for (int i = 0; i < maplength; i++)//count[1,1]对应map[0,0]
            {
                for (int j = 0; j < maplength; j++)
                {
                    switch (count[i + 1, j + 1])
                    {
                        case 0:
                        case 1:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            map[i, j] = false; break;//多了或者少了死去
                        case 3: map[i, j] = true; break;//繁殖或者保持，case2即default保持
                    }
                }
            }
            gen++;
            label.Text = $"整体存活细胞:{sumcount}";
        }//tips：时间度太复杂了，遍历两次，考虑优化算法
        public int Randomize()//随机化世界
        {
            int sumcount = 0;//总体细胞数
            Random rd = new Random();//初始化随机数生成器
            for (int i = 0; i < maplength; i++)//初始化地图
            {
                for (int j = 0; j < maplength; j++)
                {
                    map[i, j] = rd.Next(0, 10) < percent;//概率生成：生成10个数，小于percent返回true，否则false，percent不可大于9
                    if (map[i, j])
                        sumcount++;
                }
            }
            return sumcount;
        }
        #endregion
        #region 编辑模式
        private void EditStart_Click(object sender, EventArgs e)
        {
            edit = true;//正在编辑
            timer.Enabled = false;//停止推演
            GameStart.Enabled = false;//失能推演
            GameStop.Enabled = false;//失能停止推演
            EditStart.Enabled = false;//失能编辑
            EditEnd.Enabled = true;//使能停止编辑
            probability.Enabled = false;
            cellsize.Enabled = false;
        }
        private void EditEnd_Click(object sender, EventArgs e)
        {
            edit = false;//停止编辑
            EditStart.Enabled = true;//使能开始编辑
            EditEnd.Enabled = false;//失能停止编辑
            GameStart.Enabled = true;//使能推演
            GameStop.Enabled = true;//使能停止推演
            probability.Enabled = true;
            cellsize.Enabled = true;
            draw();
        }
        private void panel_MouseClick(object sender, MouseEventArgs e)//点击修改
        {
            if(edit)
            {
                int X = e.X / size + x - count / 2;
                int Y = e.Y / size + y - count / 2;
                map[X, Y] = !map[X, Y];//翻转
                Graphics g = this.panel.CreateGraphics();
                g.FillRectangle((map[X, Y] ? Brushes.Black : Brushes.White), (e.X / size) * size, (e.Y / size) * size, size, size);
            }
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)//滑动修改
        {
            if (edit)//正在编辑模式
            {
                if (slidepaint)//进入图画模式
                {
                    int X = e.X / size + x - count / 2;
                    int Y = e.Y / size + y - count / 2;
                    map[X, Y] = true;//一概设为真
                    Graphics g = this.panel.CreateGraphics();
                    g.FillRectangle((map[X, Y] ? Brushes.Black : Brushes.White), (e.X / size) * size, (e.Y / size) * size, size, size);//内部
                }
            }
        }
        private void panel_MouseDown(object sender, MouseEventArgs e)//开始编辑模式
        {
            if (edit)slidepaint = true;
        }
        private void panel_MouseUp(object sender, MouseEventArgs e)//结束编辑模式
        {
            if (edit)slidepaint = false;
        }
        //没搞懂eventhandler什么意思，虽然能跑。
        //大概是在事件栈或者队列里添加一个事件，那原先的事件或者说栈底队列头的事件是什么？就是空吗？会不会占内存？2 
        //可以从控件的行为窗口添加事件，会自动在designer生成eventhandler，也可以写好后在designer绑定
        #endregion
        #region 控件事件
        private void GameStart_Click(object sender, EventArgs e)
        {
            GameStart.Enabled = false;
            GameStop.Enabled = true;
            EditStart.Enabled = false;
            EditEnd.Enabled = false;
            random.Enabled = false;
            CLR.Enabled = false;
            probability.Enabled = false;
            cellsize.Enabled = false;
            timer.Enabled = true;
            draw();
        }

        private void CLR_Click(object sender, EventArgs e)
        {
            gen = 0;
            for (int i = 0; i < maplength; i++)
                for (int j = 0; j < maplength; j++)
                    map[i, j] = false;
            label.Text = $"整体存活细胞:0";
            draw();
        }

        private void GameStop_Click(object sender, EventArgs e)
        {
            GameStart.Enabled = true;
            EditStart.Enabled = true;
            EditEnd.Enabled = true;
            random.Enabled = true;
            CLR.Enabled = true;
            probability.Enabled = true;
            cellsize.Enabled = true;
            GameStop.Enabled = false;
            timer.Enabled = false;
            draw();
        }

        private void random_Click(object sender, EventArgs e)
        {
            gen = 0;
            int sumcount = Randomize();//初始化世界
            label.Text = $"整体存活细胞:{sumcount}";//细胞数
            draw();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            nextgen();
            draw();
        }

        private void cellsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Convert.ToInt32(cellsize.SelectedItem);
        }

        private void probability_SelectedIndexChanged(object sender, EventArgs e)
        {
            percent = Convert.ToInt32(probability.SelectedItem);
        }

        private void speed_Scroll(object sender, EventArgs e)
        {
            interval = 1001 - speed.Value;
            timer.Interval = interval;
        }
        #endregion
    }
}
