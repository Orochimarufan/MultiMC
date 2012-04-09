﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MultiMC.GUI;

namespace MultiMC.WinGUI
{
	public class WinFormsGUIManager : IGUIManager
	{
		public void Initialize()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
		}

		public IMainWindow MainWindow()
		{
			return new WinGUI.MainForm();
		}


		public IImageList LoadInstIcons()
		{
			Dictionary<string, System.Drawing.Image> imgDict =
				   new Dictionary<string, System.Drawing.Image>();
			imgDict.Add("grass", Properties.Resources.grass);
			imgDict.Add("brick", Properties.Resources.brick);
			imgDict.Add("diamond", Properties.Resources.diamond);
			imgDict.Add("dirt", Properties.Resources.dirt);
			imgDict.Add("gold", Properties.Resources.gold);
			imgDict.Add("iron", Properties.Resources.iron);
			imgDict.Add("planks", Properties.Resources.planks);
			imgDict.Add("tnt", Properties.Resources.tnt);

			return new WinFormsImageList(
				Properties.Resources.UserIconDir,
				imgDict, Properties.Resources.grass);
		}

		public IDialog AboutDialog()
		{
			return new AboutForm();
		}

		public IConsoleWindow ConsoleWindow(Instance inst)
		{
			return new ConsoleForm(inst);
		}

		public IAddInstDialog AddInstDialog()
		{
			return new NewInstDialog();
		}

		public IDialog SettingsWindow()
		{
			return new SettingsForm();
		}

		public IChangeIconDialog ChangeIconDialog()
		{
			return new ChangeIconForm();
		}

		public INotesDialog NotesDialog()
		{
			return new NotesForm();
		}

		public IEditModsDialog EditModsDialog(Instance inst)
		{
			return new EditModsForm(inst);
		}

		public void Run(IMainWindow mainWindow)
		{
			Application.Run(mainWindow as MainForm);
		}

		public IDialog DeleteDialog()
		{
			return new DeleteConfirmForm();
		}

		public ILoginDialog LoginDialog(string errMsg)
		{
			return new LoginForm(errMsg);
		}

		public IDialog InstanceOptionsDialog(Instance inst)
		{
			return new InstanceOptions(inst);
		}

	}
}
