
// This file has been generated by the GUI designer. Do not modify.
namespace MultiMC
{
	public partial class LoginDialog
	{
		private global::Gtk.Alignment alignment;
		private global::Gtk.Table loginTable;
		private global::Gtk.CheckButton checkRememberPwd;
		private global::Gtk.CheckButton checkRememberUsername;
		private global::Gtk.ToggleButton forceToggle;
		private global::Gtk.Label labelErrorMsg;
		private global::Gtk.Label labelPassword;
		private global::Gtk.Label labelUser;
		private global::Gtk.Entry passwordEntry;
		private global::Gtk.Entry userEntry;
		private global::Gtk.Button buttonOffline;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MultiMC.LoginDialog
			this.WidthRequest = 420;
			this.HeightRequest = 160;
			this.Name = "MultiMC.LoginDialog";
			this.Title = "Login";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.DefaultHeight = 160;
			// Internal child MultiMC.LoginDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.alignment = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment.Name = "alignment";
			this.alignment.LeftPadding = ((uint)(6));
			this.alignment.TopPadding = ((uint)(6));
			this.alignment.RightPadding = ((uint)(6));
			// Container child alignment.Gtk.Container+ContainerChild
			this.loginTable = new global::Gtk.Table (((uint)(4)), ((uint)(3)), false);
			this.loginTable.Name = "loginTable";
			this.loginTable.RowSpacing = ((uint)(6));
			this.loginTable.ColumnSpacing = ((uint)(6));
			// Container child loginTable.Gtk.Table+TableChild
			this.checkRememberPwd = new global::Gtk.CheckButton ();
			this.checkRememberPwd.CanFocus = true;
			this.checkRememberPwd.Name = "checkRememberPwd";
			this.checkRememberPwd.Label = "R_emember password";
			this.checkRememberPwd.DrawIndicator = true;
			this.checkRememberPwd.UseUnderline = true;
			this.loginTable.Add (this.checkRememberPwd);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.loginTable [this.checkRememberPwd]));
			w2.TopAttach = ((uint)(3));
			w2.BottomAttach = ((uint)(4));
			w2.LeftAttach = ((uint)(2));
			w2.RightAttach = ((uint)(3));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.checkRememberUsername = new global::Gtk.CheckButton ();
			this.checkRememberUsername.CanFocus = true;
			this.checkRememberUsername.Name = "checkRememberUsername";
			this.checkRememberUsername.Label = "_Remember username";
			this.checkRememberUsername.DrawIndicator = true;
			this.checkRememberUsername.UseUnderline = true;
			this.loginTable.Add (this.checkRememberUsername);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.loginTable [this.checkRememberUsername]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.forceToggle = new global::Gtk.ToggleButton ();
			this.forceToggle.CanFocus = true;
			this.forceToggle.Name = "forceToggle";
			this.forceToggle.UseUnderline = true;
			this.forceToggle.Label = "_Force Update";
			this.loginTable.Add (this.forceToggle);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.loginTable [this.forceToggle]));
			w4.TopAttach = ((uint)(3));
			w4.BottomAttach = ((uint)(4));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.labelErrorMsg = new global::Gtk.Label ();
			this.labelErrorMsg.Name = "labelErrorMsg";
			this.labelErrorMsg.Xalign = 0F;
			this.labelErrorMsg.LabelProp = "Error";
			this.loginTable.Add (this.labelErrorMsg);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.loginTable [this.labelErrorMsg]));
			w5.RightAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.labelPassword = new global::Gtk.Label ();
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Xalign = 1F;
			this.labelPassword.LabelProp = "_Password: ";
			this.labelPassword.UseUnderline = true;
			this.loginTable.Add (this.labelPassword);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.loginTable [this.labelPassword]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.labelUser = new global::Gtk.Label ();
			this.labelUser.Name = "labelUser";
			this.labelUser.Xalign = 1F;
			this.labelUser.LabelProp = "_Username: ";
			this.labelUser.UseUnderline = true;
			this.loginTable.Add (this.labelUser);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.loginTable [this.labelUser]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.passwordEntry = new global::Gtk.Entry ();
			this.passwordEntry.CanFocus = true;
			this.passwordEntry.Name = "passwordEntry";
			this.passwordEntry.IsEditable = true;
			this.passwordEntry.ActivatesDefault = true;
			this.passwordEntry.Visibility = false;
			this.passwordEntry.InvisibleChar = '●';
			this.loginTable.Add (this.passwordEntry);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.loginTable [this.passwordEntry]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(3));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child loginTable.Gtk.Table+TableChild
			this.userEntry = new global::Gtk.Entry ();
			this.userEntry.CanFocus = true;
			this.userEntry.Name = "userEntry";
			this.userEntry.IsEditable = true;
			this.userEntry.ActivatesDefault = true;
			this.userEntry.InvisibleChar = '●';
			this.loginTable.Add (this.userEntry);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.loginTable [this.userEntry]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			this.alignment.Add (this.loginTable);
			w1.Add (this.alignment);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(w1 [this.alignment]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Internal child MultiMC.LoginDialog.ActionArea
			global::Gtk.HButtonBox w12 = this.ActionArea;
			w12.Name = "dialog1_ActionArea";
			w12.Spacing = 10;
			w12.BorderWidth = ((uint)(5));
			w12.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOffline = new global::Gtk.Button ();
			this.buttonOffline.CanFocus = true;
			this.buttonOffline.Name = "buttonOffline";
			this.buttonOffline.UseUnderline = true;
			this.buttonOffline.Label = "P_lay Offline";
			this.AddActionWidget (this.buttonOffline, -2);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12 [this.buttonOffline]));
			w13.Expand = false;
			w13.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w14 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12 [this.buttonCancel]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w15 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12 [this.buttonOk]));
			w15.Position = 2;
			w15.Expand = false;
			w15.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 423;
			this.labelPassword.MnemonicWidget = this.passwordEntry;
			this.labelUser.MnemonicWidget = this.userEntry;
			this.Show ();
			this.Shown += new global::System.EventHandler (this.OnShown);
			this.userEntry.Activated += new global::System.EventHandler (this.OnUserEntryActivated);
			this.passwordEntry.Activated += new global::System.EventHandler (this.OnPasswordEntryActivated);
			this.checkRememberUsername.Clicked += new global::System.EventHandler (this.OnCheckRememberUsernameClicked);
		}
	}
}
