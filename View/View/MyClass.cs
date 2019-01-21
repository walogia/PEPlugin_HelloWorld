using PEPlugin;
using System;
using System.Windows.Forms;

namespace View
{
	public class MyClass : IPEPlugin, IDisposable, IPEPluginOption
	{
		private Form1 m_form;

		public string Description
		{
			get
			{
				return "小熊";
			}
		}

		public string Name
		{
			get
			{
				return "小熊";
			}
		}

		public IPEPluginOption Option
		{
			get
			{
				return this;
			}
		}

		public string Version
		{
			get
			{
				return "1.0 小熊";
			}
		}

		public bool Bootup
		{
			get
			{
				return false;
			}
		}

		public bool RegisterMenu
		{
			get
			{
				return true;
			}
		}

		public string RegisterMenuText
		{
			get
			{
				return "View窗口大小";
			}
		}

		public void Run(IPERunArgs args)
		{
			this.m_form = new Form1();
			this.m_form.SetHostArgs(args);
			this.m_form.Visible = true;
			try
			{
				this.CheckVersion(args, 0);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void CheckVersion(IPERunArgs args, int version = 0)
		{
			switch (version)
			{
			case 0:
				if (args.Host.Name != "PmxEditor_PluginHost")
				{
					throw new Exception("PMXE专用。");
				}
				break;
			case 1:
				if (args.Host.Name != "PMDEditor_PluginHost")
				{
					throw new Exception("PMDE专用。");
				}
				break;
			default:
				throw new Exception("无法判定Version。");
			}
		}

		public void Dispose()
		{
		}
	}
}
