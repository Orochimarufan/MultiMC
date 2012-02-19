
// This file has been generated by the GUI designer. Do not modify.
namespace MultiMC
{
	public partial class MainWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action aboutAction;
		private global::Gtk.Action openInstDirAction;
		private global::Gtk.Action newInstAction;
		private global::Gtk.Action refreshAction;
		private global::Gtk.Action preferencesAction;
		private global::Gtk.Action updateAction;
		private global::Gtk.VBox windowbox;
		private global::Gtk.Toolbar menuToolbar;
		private global::Gtk.IconView instIconView;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MultiMC.MainWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.aboutAction = new global::Gtk.Action ("aboutAction", "About", "About MultiMC", "gtk-about");
			this.aboutAction.ShortLabel = "About";
			w1.Add (this.aboutAction, "F1");
			this.UIManager.InsertActionGroup (w1, 0);
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Instance Actions");
			this.openInstDirAction = new global::Gtk.Action ("openInstDirAction", "_Open Instance Folder", "Open instance folder", "gtk-open");
			this.openInstDirAction.ShortLabel = "Open Folder";
			w2.Add (this.openInstDirAction, null);
			this.newInstAction = new global::Gtk.Action ("newInstAction", "_New Instance", "Create a new instance.", "gtk-new");
			this.newInstAction.ShortLabel = "New";
			w2.Add (this.newInstAction, null);
			this.refreshAction = new global::Gtk.Action ("refreshAction", "_Refresh Instance List", "Refresh instance list", "gtk-refresh");
			this.refreshAction.ShortLabel = "Refresh";
			w2.Add (this.refreshAction, "<Control>r");
			this.UIManager.InsertActionGroup (w2, 1);
			global::Gtk.ActionGroup w3 = new global::Gtk.ActionGroup ("Settings Actions");
			this.preferencesAction = new global::Gtk.Action ("preferencesAction", "_Settings", "Change your settings", "gtk-preferences");
			this.preferencesAction.ShortLabel = "_Settings";
			w3.Add (this.preferencesAction, null);
			this.updateAction = new global::Gtk.Action ("updateAction", "Check for _Updates", "Check for updates.", "gtk-ok");
			this.updateAction.ShortLabel = "_Updates";
			w3.Add (this.updateAction, null);
			this.UIManager.InsertActionGroup (w3, 2);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "MultiMC.MainWindow";
			this.Title = "MainWindow";
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.DefaultWidth = 620;
			this.DefaultHeight = 400;
			// Container child MultiMC.MainWindow.Gtk.Container+ContainerChild
			this.windowbox = new global::Gtk.VBox ();
			this.windowbox.Name = "windowbox";
			// Container child windowbox.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString (@"<ui><toolbar name='menuToolbar'><toolitem name='newInstAction' action='newInstAction'/><toolitem name='openInstDirAction' action='openInstDirAction'/><toolitem name='refreshAction' action='refreshAction'/><separator/><toolitem name='preferencesAction' action='preferencesAction'/><toolitem name='updateAction' action='updateAction'/><separator/><toolitem name='aboutAction' action='aboutAction'/></toolbar></ui>");
			this.menuToolbar = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/menuToolbar")));
			this.menuToolbar.Name = "menuToolbar";
			this.menuToolbar.ShowArrow = false;
			this.menuToolbar.ToolbarStyle = ((global::Gtk.ToolbarStyle)(0));
			this.menuToolbar.IconSize = ((global::Gtk.IconSize)(2));
			this.windowbox.Add (this.menuToolbar);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.windowbox [this.menuToolbar]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child windowbox.Gtk.Box+BoxChild
			this.instIconView = new global::Gtk.IconView ();
			this.instIconView.CanFocus = true;
			this.instIconView.Name = "instIconView";
			this.windowbox.Add (this.instIconView);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.windowbox [this.instIconView]));
			w5.Position = 1;
			this.Add (this.windowbox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.aboutAction.Activated += new global::System.EventHandler (this.OnAboutActionActivated);
			this.openInstDirAction.Activated += new global::System.EventHandler (this.OnViewFolderClicked);
			this.newInstAction.Activated += new global::System.EventHandler (this.OnNewClicked);
			this.refreshAction.Activated += new global::System.EventHandler (this.OnRefreshClicked);
			this.preferencesAction.Activated += new global::System.EventHandler (this.OnSettingsClicked);
			this.updateAction.Activated += new global::System.EventHandler (this.OnUpdateClicked);
			this.instIconView.ItemActivated += new global::Gtk.ItemActivatedHandler (this.OnInstIconViewItemActivated);
		}
	}
}
