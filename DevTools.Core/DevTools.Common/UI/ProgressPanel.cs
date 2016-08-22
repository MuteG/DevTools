using System.ComponentModel;
using System.Windows.Forms;

namespace DevTools.Common.UI
{
    /// <summary>
    /// 进度显示面板
    /// </summary>
    public partial class ProgressPanel : UserControl
    {
        private Control owner = null;

        /// <summary>
        /// 获取或者设置主要进度信息
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MainMessage
        {
            get
            {
                return this.labelMainMessage.Text;
            }
            set
            {
                this.labelMainMessage.Text = value;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 获取或者设置次要进度信息
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SubMessage
        {
            get
            {
                return this.labelSubMessage.Text;
            }
            set
            {
                this.labelSubMessage.Text = value;
                Application.DoEvents();
            }
        }

        public ProgressPanel()
        {
            InitializeComponent();

            this.Disposed += new System.EventHandler(ProgressPanel_Disposed);
        }

        private void ProgressPanel_Disposed(object sender, System.EventArgs e)
        {
            if (null != this.owner)
            {
                if (this.owner.Controls.Contains(this))
                {
                    this.owner.SizeChanged -= new System.EventHandler(owner_SizeChanged);
                    this.owner.Controls.Remove(this);
                }
            }
        }

        /// <summary>
        /// 设置主要进度条的最大值
        /// </summary>
        /// <param name="maximum">最大值</param>
        public void SetMainMaximum(int maximum)
        {
            progressBarMain.Maximum = maximum;
        }

        /// <summary>
        /// 设置主要进度条的进度值
        /// </summary>
        /// <param name="value">进度值</param>
        public void SetMainValue(int value)
        {
            progressBarMain.Value = value;
            labelMainPersent.Text = string.Format("{0:00}%", value * 100 / progressBarMain.Maximum);
            Application.DoEvents();
        }

        /// <summary>
        /// 设置次要进度条的最大值
        /// </summary>
        /// <param name="maximum">最大值</param>
        public void SetSubMaximum(int maximum)
        {
            progressBarSub.Maximum = maximum;
        }

        /// <summary>
        /// 设置次要进度条的进度值
        /// </summary>
        /// <param name="value">进度值</param>
        public void SetSubValue(int value)
        {
            progressBarSub.Value = value;
            labelSubPersent.Text = string.Format("{0:00}%", value * 100 / progressBarSub.Maximum);
            Application.DoEvents();
        }

        public void Show(Control owner)
        {
            this.owner = owner;
            if (!owner.Controls.Contains(this))
            {
                owner.Controls.Add(this);
                owner.SizeChanged += new System.EventHandler(owner_SizeChanged);
            }
            this.Left = (owner.Width - this.Width) / 2;
            this.Top = (owner.Height -this.Height) / 2;
            this.Show();
        }

        private void owner_SizeChanged(object sender, System.EventArgs e)
        {
            this.Left = (owner.Width - this.Width) / 2;
            this.Top = (owner.Height - this.Height) / 2;
        }

        public void Close()
        {
            this.Hide();
            if (!this.IsDisposed && !this.Disposing)
            {
                this.Dispose();
            }
        }
    }
}
