/*
 * Created by SharpDevelop.
 * User: jeffry
 * Date: 15.10.2013
 * Time: 9:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;


namespace LinkAdder.Code
{
	/// <summary>
	/// Description of Downloader.
	/// </summary>
	public class Downloader
	{
		public Downloader()
		{
		}
		
		public static string DownloadPage(string uri)
		{
			WebClient client = new WebClient ();

		    Stream data = client.OpenRead(uri);
		    StreamReader reader = new StreamReader(data);
		    string s = reader.ReadToEnd();
		    data.Close ();
		    reader.Close ();
		    
		    return s;
		}
	
	}
}
