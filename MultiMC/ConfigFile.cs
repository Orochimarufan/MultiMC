﻿// 
//  Copyright 2012  Andrew Okin
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MultiMC
{
	public class ConfigFile
	{
		public ConfigFile()
		{
			dict = new Dictionary<string, string>();
		}

		public virtual void Save(string path)
		{
			using (Stream stream = File.Open(path, FileMode.Create))
			{
				Save(stream);
			}
		}

		public virtual void Save(Stream stream)
		{
			string[] lines = new string[dict.Count];
			int i = 0;
			foreach (KeyValuePair<string, string> kv in dict)
			{
				//Console.WriteLine(kv.Key + "=" + kv.Value);
				lines[i++] = kv.Key + "=" + kv.Value;
			}

			using (StreamWriter writer = new StreamWriter(stream))
			{
				foreach (string line in lines)
				{
					writer.WriteLine(line);
				}
				writer.Flush();
			}
		}

		public virtual void Load(string path)
		{
			try
			{
				using (Stream stream = File.OpenRead(path))
				{
					Load(stream);
				}
			}
			catch (FileNotFoundException)
			{

			}
		}

		public virtual void Load(Stream stream)
		{
			using (StreamReader reader = new StreamReader(stream))
			{
				dict.Clear();
				string[] lines = reader.ReadToEnd().Split('\n').
					Select(l => l.TrimEnd('\n', '\r')).ToArray();
				foreach (string line in lines)
				{
					if (!line.StartsWith("#"))
					{
						string[] lineData = line.Split('=');
						if (lineData.Length >= 2)
						{
							//Console.WriteLine("{0} = {1}", lineData[0], lineData[1]);
							dict[lineData[0]] = lineData[1];
						}
					}
				}
			}
		}

		protected Dictionary<string, string> dict;

		/// <summary>
		/// Gets the property with the specified key.
		/// </summary>
		/// <param name='key'>
		/// The property's key
		/// </param>
		/// <param name='def'>
		/// The default value
		/// </param>
		public string this[string key, string def]
		{
			get
			{
				if (dict.ContainsKey(key))
					return dict[key];
				else
					return def;
			}
		}

		// Helpers to Set a value if a condition is true and Remove it otherwise
		public void ConditionalSoR(bool condition, string key, string value)
		{
			if (condition)
			{
				this.dict[key]=value;
			}
			else
			{
				if (this.dict.ContainsKey(key))
				{
					this.dict.Remove(key);
				}
			}
		}
		public void ConditionalSoR<T>(bool condition, string key, T value)
		{
			this.ConditionalSoR(condition,key,value.ToString());
		}

		public string this[string key]
		{
			get { return dict[key]; }
			set { dict[key] = value; }
		}

		public bool ContainsKey(string key)
		{
			return dict.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return dict.Remove(key);
		}

		public T ParseSetting<T>(string settingName, T defValue)
		{
			T value = defValue;

			if (!DataUtils.TryParse<T>(this[settingName, defValue.ToString()], out value))
			{
				return defValue;
			}
			return value;
		}

		public T ParseEnumSetting<T>(string settingName, T defValue) where T : struct
		{
			T value = defValue;

			if (!Enum.TryParse<T>(this[settingName, defValue.ToString()], out value))
			{
				return defValue;
			}
			return value;
		}
	}
}