﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;

using MultiMC;

namespace MultiMC
{
	public sealed class OldInstance
	{
		#region Fields

		/// <summary>
		/// Invalid characters that aren't allowed in an instance's name.
		/// </summary>
		const string INVALID_NAME_CHARS = "< > \n \\ &";

		/// <summary>
		/// Name of the data file inside instance folders
		/// </summary>
		static string INST_DATA_FILENAME = "instance.xml";

		/// <summary>
		/// The instance's XML data file
		/// </summary>
		XmlDocument xmlDoc;

		/// <summary>
		/// The instance's root directory
		/// </summary>
		string rootDir;

		/// <summary>
		/// If true, XML values are saved when changed.
		/// </summary>
		bool autosave;

		#endregion

		#region Static Methods

		/// <summary>
		/// Loads all instances from the specified directory
		/// </summary>
		/// <param name="instDir">Directory containing the instances</param>
		/// <returns>The instances loaded</returns>
		public static OldInstance[] LoadInstances(string instDir)
		{
			if (!Directory.Exists(instDir))
			{
				return new OldInstance[0];
			}

			ArrayList instList = new ArrayList();
			foreach (string dir in Directory.GetDirectories(instDir))
			{
				Console.WriteLine("Loading instance from " + dir + "...");
				OldInstance inst = null;
				try
				{
					inst = LoadInstance(dir);
				}
				catch (InvalidInstanceException e)
				{
					Console.WriteLine(e.Message);
				}

				if (inst != null)
					instList.Add(inst);
			}
			return (OldInstance[])instList.ToArray(typeof(OldInstance));
		}

		/// <summary>
		/// Loads the instance from the specified directory.
		/// </summary>
		/// <param name="rootDir">The instance's root directory</param>
		/// <returns>The instance loaded or null if the instance isn't valid</returns>
		public static OldInstance LoadInstance(string rootDir)
		{
			// Verify the instance
			string xmlFile = Path.Combine(rootDir, INST_DATA_FILENAME);
			if (!Directory.Exists(rootDir))
			{
				throw new InvalidInstanceException("Instance root directory '" + rootDir +
					"' not found!");
			}
			if (!File.Exists(xmlFile))
			{
				throw new InvalidInstanceException("Instance data file '" + xmlFile + "' not found!");
			}

			// Initialize a new instance from XML
			XmlDocument doc = new XmlDocument();
			doc.Load(xmlFile);
			return new OldInstance(doc, rootDir);
		}

		#endregion

		#region Methods

		public OldInstance(string name, string rootDir, bool autosave = true)
		{
			this.xmlDoc = new XmlDocument();

			this.Name = name;
			this.RootDir = rootDir;

			this.autosave = autosave;

			AutoSave();
		}

		/// <summary>
		/// Initializes a new instance from the given XML document
		/// </summary>
		/// <param name="doc">An XMLDocument containing the instance data</param>
		/// <pparam name="rootDir">The instance's root directory</pparam>
		public OldInstance(XmlDocument doc, string rootDir, bool autosave = true)
		{
			this.xmlDoc = doc;
			this.rootDir = rootDir;

			this.autosave = autosave;
		}

		/// <summary>
		/// Saves the instance's XML data
		/// </summary>
		/// <param name="file">The file to save to.
		/// If null, the default XML data file will be used.</param>
		public void SaveData(string file = null)
		{
			if (file == null)
				file = Path.Combine(RootDir, INST_DATA_FILENAME);

			if (!Directory.Exists(RootDir))
			{
				Directory.CreateDirectory(RootDir);
			}
			xmlDoc.Save(file);
		}

		private void AutoSave()
		{
			if (autosave)
				SaveData();
		}

		/// <summary>
		/// Checks if this is a valid instance
		/// </summary>
		/// <returns>True if instance is valid</returns>
		public bool IsValid()
		{
			if (!Directory.Exists(RootDir))
			{
				return false;
			}
			//if (!File.Exists(Path.Combine(RootDir, "instance.xml")))
			//{
			//    return false;
			//}
			return true;
		}

		void ProcExited(object sender, EventArgs e)
		{
			if (InstQuit != null)
				InstQuit(this, new InstQuitEventArgs((sender as Process).ExitCode,
													 (sender as Process).ExitTime));
		}

		/// <summary>
		/// Gets the XML element with the given name inside the given parent element.
		/// If the element doesn't exist, it will be created with the value specified by the 
		/// defaultValue parameter.
		/// </summary>
		/// <param name="name">Name of the element to get</param>
		/// <param name="parent">The parent element or the root element if null</param>
		/// <param name="defaultValue">The default value of the element.</param>
		/// <returns>The element</returns>
		private XmlElement GetXmlElement(string name, object defaultValue = null, XmlElement parent = null)
		{
			if (parent == null)
			{
				parent = XmlRoot;
			}
			if (parent[name] == null)
			{
				parent.AppendChild(xmlDoc.CreateElement(name));
				if (defaultValue != null)
					parent[name].InnerText = defaultValue.ToString();
			}
			return parent[name];
		}

		/// <summary>
		/// Gets the XML element with the given name inside the given parent element.
		/// If the element doesn't exist, it will be created.
		/// </summary>
		/// <param name="name">Name of the element to get</param>
		/// <param name="parent">The parent element</param>
		/// <returns>The element</returns>
		private XmlElement GetXmlElement(string name, XmlElement parent)
		{
			return GetXmlElement(name, null, parent);
		}

		#endregion

		#region Properties

		public InstanceMods InstMods
		{
			get;
			private set;
		}

		/// <summary>
		/// The root element in the instance's XML document
		/// </summary>
		private XmlElement XmlRoot
		{
			get
			{
				if (xmlDoc["instance"] == null)
				{
					xmlDoc.AppendChild(xmlDoc.CreateElement("instance"));
				}
				return xmlDoc["instance"];
			}
		}

		/// <summary>
		/// The instance's name
		/// </summary>
		public string Name
		{
			get { return GetXmlElement("name").InnerText; }
			set
			{
				GetXmlElement("name").InnerText = value;
				AutoSave();
			}
		}

		/// <summary>
		/// The image list key for this instance's icon ('grass' by default)
		/// </summary>
		public string IconKey
		{
			get { return GetXmlElement("iconKey", "default").InnerText; }
			set
			{
				GetXmlElement("iconKey", "default").InnerText = value;
				AutoSave();
			}
		}

		/// <summary>
		/// User-made notes on the instance
		/// </summary>
		public string Notes
		{
			get { return GetXmlElement("notes").InnerText; }
			set
			{
				GetXmlElement("notes").InnerText = value;
				AutoSave();
			}
		}

		public bool NeedsRebuild
		{
			get { return bool.Parse(GetXmlElement("NeedsRebuild", "false").InnerText); }
			set
			{
				DebugUtils.Print("Rebuild set to {0}", value.ToString());
				GetXmlElement("NeedsRebuild").InnerText = value.ToString();
				AutoSave();
			}
		}

		#region Directories

		/// <summary>
		/// The root directory of the instance
		/// </summary>
		public string RootDir
		{
			get { return this.rootDir; }
			set
			{
				this.rootDir = value;
				AutoSave();
			}
		}

		/// <summary>
		/// The directory where mods will be stored
		/// </summary>
		public string InstModsDir
		{
			get { return Path.Combine(RootDir, "instMods"); }
		}

		/// <summary>
		/// Gets the mod list file. This file stores a list of all the mods installed in the
		/// order that they will be installed.
		/// </summary>
		/// <value>
		/// The mod list file.
		/// </value>
		public string ModListFile
		{
			get { return Path.Combine(RootDir, Properties.Resources.ModListFileName); }
		}

		/// <summary>
		/// The instance's .minecraft folder
		/// </summary>
		public string MinecraftDir
		{
			get
			{
				if (Directory.Exists(Path.Combine(RootDir, ".minecraft")) &&
					!Directory.Exists(Path.Combine(RootDir, "minecraft")))
					return Path.Combine(RootDir, ".minecraft");
				else
					return Path.Combine(RootDir, "minecraft");
			}
		}

		/// <summary>
		/// The instance's bin folder (.minecraft\bin)
		/// </summary>
		public string BinDir
		{
			get { return Path.Combine(MinecraftDir, "bin"); }
		}

		/// <summary>
		/// The instance's minecraft.jar
		/// </summary>
		public string MCJar
		{
			get { return Path.Combine(BinDir, "minecraft.jar"); }
		}

		/// <summary>
		/// ModLoader's folder (.minecraft\mods)
		/// </summary>
		public string ModLoaderDir
		{
			get { return Path.Combine(MinecraftDir, "mods"); }
		}

		/// <summary>
		/// The texture packs folder (.minecraft\texturepacks)
		/// </summary>
		public string TexturePackDir
		{
			get { return Path.Combine(MinecraftDir, "texturepacks"); }
		}

		#endregion

		public bool CanPlayOffline
		{
			get
			{
				string vfile = Path.Combine(BinDir, "version");
				if (Directory.Exists(BinDir) && File.Exists(vfile))
				{
					string version = Tasks.GameUpdater.ReadVersionFile(vfile);
					if (version != null && version.Length > 0)
						return true;
				}
				return false;
			}
		}

		public bool ProcessDisposed
		{
			get;
			private set;
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurrs when the instance quits.
		/// </summary>
		public event EventHandler<InstQuitEventArgs> InstQuit;

		#endregion

		#region Utility Methods

		/// <summary>
		/// Checks if the given instance name is valid
		/// </summary>
		/// <param name="name">The instance name</param>
		/// <returns>true if the name is valid</returns>
		public static bool NameIsValid(string name)
		{
			foreach (char nameChar in INVALID_NAME_CHARS)
			{
				if (name.Contains(nameChar) && nameChar != ' ')
				{
					return false;
				}
			}
			return name.Length > 0;
		}

		/// <summary>
		/// Generates a valid directory name for an instance with the given name
		/// </summary>
		/// <param name="name">The name of the instance</param>
		/// <param name="instDir">The directory that will contain the instance</param>
		/// <returns>A valid directory name</returns>
		public static string GetValidDirName(string name, string instDir)
		{
			if (name.Length == 0)
				name = "Untitled";

			char[] nameChars = name.ToCharArray();
			for (int i = 0; i < nameChars.Length; i++)
			{
				char c = nameChars[i];
				if (Path.GetInvalidFileNameChars().Contains(c))
				{
					nameChars[i] = '-';
				}
				if (c == ' ')
				{
					nameChars[i] = '_';
				}
			}

			string validName;
			validName = new string(nameChars);

			if (instDir != null)
			{
				int i = 0;
				while (Directory.Exists(Path.Combine(instDir, validName)))
				{
					validName = new string(nameChars) + "_" + (++i);
				}
			}

			return validName;
		}

		#endregion
	}
}