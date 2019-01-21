
///////////////////////////////////////////////////////////////////////////
//DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                   Version 2, December 2004
// 
//Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>
//
//Everyone is permitted to copy and distribute verbatim or modified
//copies of this license document, and changing it is allowed as long
//as the name is changed.
// 
//           DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//  TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
// 
// 0. You just DO WHAT THE FUCK YOU WANT TO.
///////////////////////////////////////////////////////////////////////////
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.View;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace View
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		private IPERunArgs args;
		private IPEPluginHost host;
		private IPEConnector connect;
		private IPXPmx PMX;
		public IPXPmxViewConnector PMXView;
		public IPEPMDViewConnector PMDView;
		public IPEBuilder builder;
		public IPEShortBuilder bd;
        
        public void SetHostArgs(IPERunArgs args)
        {
            this.args = args;
        }
                
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Form1FormClosing(object sender, FormClosingEventArgs e)
		{
			 if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                // フォームを非表示設定
                this.Visible = false;
            }
		}
		
		private void InitializeValue()
		{
			try
			{
				this.host = this.args.Host;;
				this.connect = this.host.Connector;
				this.PMX = this.connect.Pmx.GetCurrentState();
				this.PMDView = this.connect.View.PMDView;
				this.PMXView = this.connect.View.PmxView;
				this.builder = this.host.Builder;
				this.bd = this.host.Builder.SC;
			}
			catch
			{
				MessageBox.Show("值初始化失败");
			}
		}

	        /// <summary>
	        /// モデル・画面を更新します。
	        /// </summary>
	        public void Update()
	        {
	            this.connect.Pmx.Update(this.PMX);
	            this.connect.Form.UpdateList(PEPlugin.Pmd.UpdateObject.All);
	            this.connect.View.PMDView.UpdateModel();
	            this.connect.View.PMDView.UpdateView();
	        }
		

			
		void Button1Click(object sender, EventArgs e)
		{
			this.InitializeValue();
			
			//在此编写代码
			int w=this.PMXView.Size.Width;
			int h=this.PMXView.Size.Height;
			MessageBox.Show("View窗口 宽："+w.ToString()+" 高："+h.ToString());
			
			this.Update();
		}
		//*********************截止到此********************//
	}
}
