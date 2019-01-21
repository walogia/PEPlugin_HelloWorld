/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2019/1/21 星期一
 * 时间: 9:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.View;
using PEPlugin.Vmd;
using PEPlugin.Vme;
using SlimDX;

namespace xiao
{

	/// <summary>
	
	/// Description of MyClass.
	
	/// </summary>
	
	public class MyClass:IPEPlugin, IPEPluginOption
	
	{
		        /// <summary>
	        /// PMDEditerを操作するために必要な変数群
	        /// </summary>
	        //-----------------------------------------------------------ここから-----------------------------------------------------------
	        public IPEPluginHost host;
	        public IPEBuilder builder;
	        public IPEShortBuilder bd;
	        public IPEConnector connect;
	        public IPEXPmd pex;
	        public IPXPmx PMX;
	        public IPEPmd PMD;
	        public IPEFormConnector Form;
	        public IPXPmxViewConnector PMXView;
	        public IPEPMDViewConnector PMDView;
	        //-----------------------------------------------------------ここまで-----------------------------------------------------------
	        // コンストラクタ
	
			public string Description
	
	        {
	
	                get { return "Hello World"; }
	
	        }
	
	
	
	        public string Name
	
	        {
	
	                get { return "Hello World"; }
	
	        }
	
	
	
	        public PEPlugin.IPEPluginOption Option
	
	        {
	
	                get { return this; }
	
	        }
	
	
	
	        public void Run(PEPlugin.IPERunArgs args)
	
	        {
				 try
	            {
	                //PMD/PMXファイルを操作するためにおまじない。
	                this.host = args.Host;
	                this.builder = this.host.Builder;
	                this.bd = this.host.Builder.SC;
	                this.connect = this.host.Connector;
	                this.pex = this.connect.Pmd.GetCurrentStateEx();
	                this.PMD = this.connect.Pmd.GetCurrentState();
	                this.PMX = this.connect.Pmx.GetCurrentState();
	                this.Form = this.connect.Form;
	                this.PMDView = this.connect.View.PMDView;
	                //-----------------------------------------------------------ここから-----------------------------------------------------------
	                //ここから処理開始
	                //-----------------------------------------------------------ここから-----------------------------------------------------------
					// 继续编写实现
	
					MessageBox.Show("Hello World!");
	                //-----------------------------------------------------------ここまで-----------------------------------------------------------
	                //処理ここまで
	                //-----------------------------------------------------------ここまで-----------------------------------------------------------
	                //モデル・画面を更新します。
	                this.Update();
	            }
	            catch (Exception ex)
	            {
	                MessageBox.Show(ex.Message, "报错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	            }

	        }
	
	        /// <summary>
	        /// モデル・画面を更新します。
	        /// </summary>
	        public void Update()
	        {
	            this.connect.Pmx.Update(this.PMX);
	            this.connect.Form.UpdateList(UpdateObject.All);
	            this.connect.View.PMDView.UpdateModel();
	            this.connect.View.PMDView.UpdateView();
	        }
		
	        public string Version
	
	        {
	
	                get { return "1.0 小熊"; }
	
	        }
	
	
	
	        public void Dispose()
	
	        {
	
	        }
	
	
	
	        public bool Bootup
	
	        {
	
	                get { return false; }
	
	        }
	
	
	
	        public bool RegisterMenu
	
	        {
	
	                get { return true; }
	
	        }
	
	
	
	        public string RegisterMenuText
	
	        {
	
	                get { return "Hello World"; }
	
	        }
	
	}

}
