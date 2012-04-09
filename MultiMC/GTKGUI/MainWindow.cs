﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gtk;
using Glade;

using MultiMC.GUI;
using MultiMC.Tasks;

namespace MultiMC.GTKGUI
{
	public class MainWindow : GTKWindow, IMainWindow
	{
		ListStore instListStore;

		Dictionary<int, ProgressBar> taskProgBars;

		public MainWindow()
		{
			XML gxml = new XML(null, "MultiMC.GTKGUI.MainWindow.glade", 
				"mainVBox", null);
			gxml.Toplevel = this;
			gxml.Autoconnect(this);

			XML gxml2 = new XML(null, "MultiMC.GTKGUI.InstContextMenu.glade",
				"instContextMenu", null);
			gxml2.Autoconnect(this);

			this.Add(mainVBox);

			ShowAll();

			this.WidthRequest = 620;
			this.HeightRequest = 380;

			DeleteEvent += (o, args) => Application.Quit();

			// Set up the instance icon view
			instListStore = new ListStore(
				typeof(string), typeof(Gdk.Pixbuf), typeof(Instance));

			instView.Model = instListStore;
			instView.TextColumn = 0;
			instView.PixbufColumn = 1;

			instView.ButtonPressEvent += (o, args) =>
				{
					if (args.Event.Button == 3 &&
						instView.GetPathAtPos((int)args.Event.X,
											  (int)args.Event.Y) != null)
					{
						instView.SelectPath(instView.GetPathAtPos(
							(int)args.Event.X, (int)args.Event.Y));
						instContextMenu.Popup();
					}
				};

			// Set up the task list
			EventfulList<Task> tList = new EventfulList<Task>();
			tList.Added += TaskAdded;
			tList.Removed += TaskRemoved;

			TaskList = tList;
			taskProgBars = new Dictionary<int, ProgressBar>();

			// Set up the instance list
			EventfulList<Instance> iList = new EventfulList<Instance>();
			iList.Added += InstAdded;
			iList.Removed += InstRemoved;

			InstanceList = iList;
		}

		void InstAdded(object sender, ItemAddRemoveEventArgs<Instance> e)
		{
			Instance inst = e.Item;
			instListStore.AppendValues(
				inst.Name, _imageList.ImgList[inst.IconKey], inst);
		}

		void InstRemoved(object sender, ItemAddRemoveEventArgs<Instance> e)
		{
			TreeIter iter;
			instListStore.GetIterFirst(out iter);

			do
			{
				if (e.Item == instListStore.GetValue(iter, 2))
				{
					instListStore.Remove(ref iter);
					return;
				}
			} while (instListStore.IterNext(ref iter));
		}

		void TaskAdded(object sender, ItemAddRemoveEventArgs<Task> e)
		{
			if (IsTaskIDTaken(e.Item.TaskID))
				e.Item.TaskID = GetAvailableTaskID();
			TaskAdded(e.Item);
		}

		void TaskAdded(Task task)
		{
			ProgressBar tProgBar = new ProgressBar();
			tProgBar.Text = task.Status;
			taskProgBars.Add(task.TaskID, tProgBar);
			progBarVBox.PackEnd(tProgBar, false, true, 0);

			task.StatusChange += new Task.StatusChangeEventHandler(TaskStatusChange);

			task.ProgressChange += new Task.ProgressChangeEventHandler(TaskProgressChange);

			tProgBar.Visible = true;
		}

		void TaskProgressChange(object sender, Task.ProgressChangeEventArgs e)
		{
			Invoke((o, args) => 
				{
					double pbarFraction = (float)e.Progress / 100f;
					if (pbarFraction > 1.0)
						pbarFraction = 1;

					taskProgBars[e.TaskID].Fraction = pbarFraction;
				});
			
		}

		void TaskStatusChange(object sender, Task.TaskStatusEventArgs e)
		{
			Invoke((o, args) =>
				{
					taskProgBars[e.TaskID].Text = e.Status;
				});
		}

		void TaskRemoved(object sender, ItemAddRemoveEventArgs<Task> e)
		{
			Invoke((o, args) =>
			{
				//mainVBox.Remove(taskProgBars[e.Item.TaskID]);
				taskProgBars.Remove(e.Item.TaskID);
			});
		}

		#region Glade Handlers
		// Menu Bar
		void OnNewInstanceClicked(object sender, EventArgs e)
		{
			if (NewInstClicked != null)
				NewInstClicked(this, EventArgs.Empty);
		}

		void OnViewFolderClicked(object sender, EventArgs e)
		{
			if (ViewFolderClicked != null)
				ViewFolderClicked(this, EventArgs.Empty);
		}

		void OnRefreshClicked(object sender, EventArgs e)
		{
			if (RefreshClicked != null)
				RefreshClicked(this, EventArgs.Empty);
		}


		void OnSettingsClicked(object sender, EventArgs e)
		{
			if (SettingsClicked != null)
				SettingsClicked(this, EventArgs.Empty);
		}

		void OnCheckUpdatesClicked(object sender, EventArgs e)
		{
			if (CheckUpdatesClicked != null)
				CheckUpdatesClicked(this, EventArgs.Empty);
		}


		void OnHelpClicked(object sender, EventArgs e)
		{
			if (HelpClicked != null)
				HelpClicked(this, EventArgs.Empty);
		}

		void OnAboutClicked(object sender, EventArgs e)
		{
			if (AboutClicked != null)
				AboutClicked(this, EventArgs.Empty);
		}


		// Instance Menu
		void OnPlayClicked(object sender, EventArgs e)
		{
			if (InstanceLaunched != null)
				InstanceLaunched(this, new InstActionEventArgs(SelectedInst));
		}

		void OnChangeIconClicked(object sender, EventArgs e)
		{
			if (ChangeIconClicked != null)
				ChangeIconClicked(this, new InstActionEventArgs(SelectedInst));
		}

		void OnEditNotesClicked(object sender, EventArgs e)
		{
			if (EditNotesClicked != null)
				EditNotesClicked(this, new InstActionEventArgs(SelectedInst));
		}

		void OnEditModsClicked(object sender, EventArgs e)
		{
			if (EditModsClicked != null)
				EditModsClicked(this, new InstActionEventArgs(SelectedInst));
		}

		void OnRebuildClicked(object sender, EventArgs e)
		{
			if (RebuildJarClicked != null)
				RebuildJarClicked(this, new InstActionEventArgs(SelectedInst));
		}

		void OnViewInstFolderClicked(object sender, EventArgs e)
		{
			if (ViewInstFolderClicked != null)
				ViewInstFolderClicked(this, new InstActionEventArgs(SelectedInst));
		}

		void OnDeleteClicked(object sender, EventArgs e)
		{
			if (DeleteInstClicked != null)
				DeleteInstClicked(this, new InstActionEventArgs(SelectedInst));
		}


		// Other
		void OnItemActivated(object sender, ItemActivatedArgs e)
		{
			OnPlayClicked(sender, e);
		}
		#endregion

		#region Glade Widgets
		//[Widget]
		//ToolButton newInstButton = null;

		//[Widget]
		//ToolButton viewInstFolderButton = null;

		//[Widget]
		//ToolButton refreshButton = null;

		//[Widget]
		//ToolButton settingsButton = null;
		
		//[Widget]
		//ToolButton updateButton = null;

		//[Widget]
		//ToolButton helpButton = null;
		
		//[Widget]
		//ToolButton aboutButton = null;

		[Widget]
		IconView instView = null;

		[Widget]
		VBox mainVBox = null;

		[Widget]
		VBox progBarVBox = null;

		[Widget]
		Menu instContextMenu = null;
		#endregion

		public void LoadInstances()
		{
			InstanceList.Clear();
			foreach (Instance inst in Instance.LoadInstances(AppSettings.Main.InstanceDir))
			{
				InstanceList.Add(inst);
			}
		}

		public IList<Task> TaskList
		{
			get;
			protected set;
		}

		public IList<Instance> InstanceList
		{
			get;
			protected set;
		}

		public event EventHandler NewInstClicked;

		public event EventHandler ViewFolderClicked;

		public event EventHandler RefreshClicked;

		public event EventHandler SettingsClicked;

		public event EventHandler CheckUpdatesClicked;

		public event EventHandler HelpClicked;

		public event EventHandler AboutClicked;

		public event EventHandler<InstActionEventArgs> InstanceLaunched;

		public event EventHandler<InstActionEventArgs> ChangeIconClicked;

		public event EventHandler<InstActionEventArgs> EditNotesClicked;

		public event EventHandler<InstActionEventArgs> EditModsClicked;

		public event EventHandler<InstActionEventArgs> RebuildJarClicked;

		public event EventHandler<InstActionEventArgs> ViewInstFolderClicked;

		public event EventHandler<InstActionEventArgs> DeleteInstClicked;

		public IImageList ImageList
		{
			get { return _imageList; }
			set
			{
				if (value is GTKImageList)
				{
					_imageList = value as GTKImageList;
				}
				else if (value != null)
					throw new InvalidOperationException("GTK# needs a GTKImageList.");
				else
					throw new ArgumentNullException("value");
			}
		}
		GTKImageList _imageList;

		public Instance SelectedInst
		{
			get
			{
				if (instView.SelectedItems.Length <= 0)
					return null;

				TreeIter iter;
				instListStore.GetIter(out iter, instView.SelectedItems[0]);
				return instListStore.GetValue(iter, 2) as Instance;
			}
		}

		public Tasks.Task GetTaskByID(int taskID)
		{
			return TaskList.First(task => task.TaskID == taskID);
		}

		public bool IsTaskIDTaken(int taskID)
		{
			return TaskList.Any(task => task.TaskID == taskID);
		}

		public int GetAvailableTaskID()
		{
			int i = 0;
			while (IsTaskIDTaken(i))
			{
				i++;
			}
			return i;
		}
	}
}
